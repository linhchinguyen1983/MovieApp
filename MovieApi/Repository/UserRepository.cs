
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Data;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(MovieDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var users = await _dbContext.Users.Where(u => u.Email == username).ToListAsync();
            if (users.IsNullOrEmpty() || users.Count != 1)
            {
                return null;
            }
            try
            {
                var user = users.First();
                if (string.Equals(password, user.Password))
                    return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;

        }

        public async Task<string> GenerateTokenAsync(User user)
        {

            // Create claim
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };

            //select user's role from db
            var userRoles = await (from ur in _dbContext.UserRoles
                                   join r in _dbContext.Roles on ur.RoleId equals r.Id
                                   where ur.UserId == user.Id
                                   select new
                                   {
                                       RoleName = r.Name
                                   }).ToListAsync();

            // iterating in userRoles and add role to claims
            foreach (var role in userRoles)
            {
                Console.WriteLine(role);
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public async Task<bool> GivePermission(User user, List<string> permissions)
        {
            permissions = permissions.Distinct().ToList();
            foreach (var permission in permissions)
            {
                // Check if the permission already exists
                var roleId = await _dbContext.Roles.Where(role => role.Name.ToLower() == permission.ToLower()).Select(role => role.Id).FirstOrDefaultAsync();

                UserRole useRole = new()
                {
                    UserId = user.Id,
                    RoleId = roleId,
                };
                try
                {
                    await _dbContext.UserRoles.AddAsync(useRole);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }


        public async Task<User?> RegisterAsync(User user)
        {
            var checkUser = _dbContext.Users.Where(u => u.Email == user.Email);
            // Return null if email has been registed
            if (checkUser.Any())
            {
                return null;
            }
            try
            {
                var entityEntry = await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return entityEntry.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string? GetUserIdFromTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            return userIdClaim?.Value;
        }

        public async Task<User> UpdateUserAsync(Guid id, UpdateUserDto user)
        {
            try
            {
                var exitingUser = await _dbContext.Users.FindAsync(id);
                if (exitingUser != null)
                {
                    exitingUser.Name = string.IsNullOrEmpty(user.Name) ? exitingUser.Name : user.Name;
                    exitingUser.Email = string.IsNullOrEmpty(user.Email) ? exitingUser.Email : user.Email;
                    exitingUser.Password = string.IsNullOrEmpty(user.Password) ? exitingUser.Password : user.Password;
                    exitingUser.PhoneNumber = string.IsNullOrEmpty(user.PhoneNumber) ? exitingUser.PhoneNumber : user.PhoneNumber;
                    exitingUser.BirthDate = user.BirthDate.HasValue ? user.BirthDate : exitingUser.BirthDate;

                    await _dbContext.SaveChangesAsync();

                    return exitingUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
