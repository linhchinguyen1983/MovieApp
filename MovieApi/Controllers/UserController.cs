﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Middlewares;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;
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

        [HttpGet]
        [Route("test")]
        [SessionRequirement("reader")]
        public async Task<IActionResult> TestAuthorization()
        {
            return Ok("Run success");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser ([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userRepository.UpdateUserAsync(id, updateUserDto);
            if (user == null) return StatusCode(500);
            return Ok(_mapper.Map<User>(user));
        }
    }
}
