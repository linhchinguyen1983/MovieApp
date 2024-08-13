using Microsoft.IdentityModel.Tokens;
using MovieApi.Model.DomainModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApi.Middlewares
{
    public class HandleToken
    {
        public readonly IConfiguration _configuration;
        public HandleToken(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public static List<string>? HanleToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenSplit = token.Split(' ');
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(tokenSplit[1]);
                if(jwtToken.ValidTo > DateTime.UtcNow)
                {
                    var roles = jwtToken.Claims
                                .Where(claim => claim.Type == ClaimTypes.Role)
                                .Select(claim => claim.Value)
                                .ToList();
                    return roles;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }  
        
    }
}
