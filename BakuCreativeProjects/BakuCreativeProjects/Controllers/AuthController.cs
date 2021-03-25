﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BakuCreativeProjects.DTO.User;
using BakuCreativeProjects.Models;
using BakuCreativeProjects.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BakuCreativeProjects.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository authRepository,IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult>Register(UserForRegisterDto userForRegisterDto )
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _authRepository.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("user already exists");
            }
            var newUser = new User
            {
                Name = userForRegisterDto.Username,
                Email = userForRegisterDto.Email
            };
            var createdUser = _authRepository.Register(newUser, userForRegisterDto.Password);
           //return Ok(createdUser);
            return StatusCode(201);
        }
        
        
        [HttpPost("login")]
        public async Task<IActionResult>Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo =await _authRepository.Login(userForLoginDto);
            if (userFromRepo == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config
                .GetSection("Appsettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriber = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials=creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriber);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
    
        }
    }
    }
