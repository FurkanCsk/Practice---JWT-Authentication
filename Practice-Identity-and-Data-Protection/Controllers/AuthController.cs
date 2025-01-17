﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_Identity_and_Data_Protection.Dtos;
using Practice_Identity_and_Data_Protection.Jwt;
using Practice_Identity_and_Data_Protection.Models;
using Practice_Identity_and_Data_Protection.Services;

namespace Practice_Identity_and_Data_Protection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestModel request)
        {
            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };

            var result = await _userService.AddUser(addUserDto);

            if(result.IsSucceed)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var loginUserDto = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.LoginUser(loginUserDto);

            if(!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }

            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwt(new JwtDto
            {
              Id = user.Id,
              Email = user.Email,
              UserType = user.UserType,
              SecretKey = configuration["Jwt:SecretKey"]!,
              Issuer = configuration["Jwt:Issuer"]!,
              Audience = configuration["Jwt:Audience"]!,
              ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });



            return Ok(new LoginResponse
            {
                Message = "Login succesful.",
                Token = token
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminPanel()
        {
            return Ok("Welcome to the Admin Panel");
        }
    }
}
