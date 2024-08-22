using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Middlewares;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;
using System;
using System.Net;
using System.Security.Claims;

namespace MovieApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterDto requestRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(requestRegister);
            var newUser = await _userRepository.RegisterAsync(user);
            if (newUser != null)
            {
                await _userRepository.GivePermission(newUser, requestRegister.Roles);
                return Ok(newUser);
            }

            return BadRequest("Something is wrong!");

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var user = await _userRepository.AuthenticateAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return BadRequest("Email or password is in correct!");
            }

            var token = await _userRepository.GenerateTokenAsync(user);

            return Ok(new LoginResponse
            {
                Status = true,
                Token = token
            });
        }

        //Chạy ứng dụng của bạn và mở Swagger UI(thường có địa chỉ là https://localhost:5001/swagger).
        //Đăng nhập để lấy JWT token.
        //Sử dụng nút "Authorize" trong Swagger UI để nhập token vào trường Authorization. Định dạng: Bearer [token]
        //Sau đó, bạn có thể thực hiện yêu cầu GET đến endpoint profile mà không cần truyền tham số, Swagger sẽ tự động thêm token vào header.
        /// <summary>
        /// Lấy thông tin người dùng từ token JWT.
        /// </summary>
        /// <returns>
        /// Trả về thông tin của người dùng nếu token hợp lệ, 
        /// hoặc phản hồi lỗi nếu token không hợp lệ hoặc người dùng không tồn tại.
        /// </returns>
        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> GetUserFromTokenAsync()
        {
            // Lấy ID người dùng từ token
            var userId = GetUserIdFromToken();

            // Kiểm tra xem userId có hợp lệ không
            if (userId == Guid.Empty) return Unauthorized();

            // Truy vấn cơ sở dữ liệu để lấy thông tin người dùng
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.Password = "";

            return Ok(user);
        }


        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id,[FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepository.UpdateUserAsync(id, updateUserDto);
            if (user == null) return StatusCode(500);
            return Ok(_mapper.Map<User>(user));
        }

        /// <summary>
        /// Lấy ID người dùng từ token xác thực hiện tại.
        /// Trả về Guid.Empty nếu không tìm thấy claim "NameIdentifier" trong token.
        /// </summary>
        /// <returns>ID người dùng dạng Guid</returns>
        private Guid GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(userIdClaim.Value);
        }
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUserList()
        {
            var users = await _userRepository.GetUserListAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }

    }
}
