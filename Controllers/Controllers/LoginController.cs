using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Controller.Models;
using Controller.Models.DTO;
using AutoMapper;
using Nexus.Data;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Claims;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IMapper _mapper;
        private NexusContext _db;

        public LoginController(IConfiguration config, IMapper mapper, NexusContext db)
        {
            _mapper = mapper;
            _db = db;
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserDTO DTO)
        {
            IActionResult response = Unauthorized();

            User login = _mapper.Map<User>(DTO);

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("EmployeeId", Convert.ToString(userInfo.EmployeeId))
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              null,
              expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User? AuthenticateUser(User login)
        {


            User? user = null;

            //Validate the User Credentials
            user = _db.Users.FirstOrDefault(u => u.Username.ToLower() == login.Username.ToLower());

            if (user == null)
            {
                return null;
            }


            login.Password = Password.HashPassword(login.Password, user.Salt);

            if (login.Password == user.Password)
            {
                return user;
            }

            return null;
        }



    }
}

