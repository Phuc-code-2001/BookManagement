using AutoMapper;
using DataLayer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.DTOs;
using WebApi.Models.Identities;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        IMapper _mapper;
        IConfiguration _configuration;
        AppDbContext _context;

        public IdentityController(IConfiguration configuration, AppDbContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult RequiredToken(LoginModel request)
        {

            AppUser user = _context.Users.Include(u => u.Role)
                .FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);
            if(user == null)
            {
                return Unauthorized("Email or Password incorrect!");
            }

            JwtSecurityToken token = GenerateSecurityToken(user);

            return Ok(new TokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                User = _mapper.Map<AppUserDTO>(user),
            });

        }

        private JwtSecurityToken GenerateSecurityToken(AppUser user)
        {
            string role = user.Role.Description.ToString();
            var authClaims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)); ;

            return token;
        }

        public class TokenResponse
        {
            public string AccessToken { get; set; }
            public AppUserDTO User { get; set; }
        }


    }
}
