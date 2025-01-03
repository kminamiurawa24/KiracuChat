﻿using KiracuFlyerAPI.Auth;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("user")] // ルートパスを "user" に変更
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserController(IUserService userService, JwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.AuthenticateUserAsync(request);
            if (user == null)
            {
                return Unauthorized(); // 認証失敗
            }

            var token = _jwtTokenGenerator.GenerateToken(user); // トークンを生成
            return Ok(new { User = user, Token = token }); // ユーザー情報とトークンを返す        }
        }
    }
}