using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskSystemApi.Models;

namespace TaskSystemApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login) 
        {

            if (login.Login == "admin" && login.Password == "admin") 
            {

                var token = GenerateJWTToken();

                return Ok(new { token });
                
            }

            return BadRequest(new { message = "Invalid credentials. Please check your username and password." });

        }

        private string GenerateJWTToken() 
        {

            string secretKey = "54c3a8c4-0398-482d-9f1f-e896c10fa4f5";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {

                new Claim("login", "admin"),
                new Claim("name", "System Administrator")

            };

            var token = new JwtSecurityToken(

                issuer: "company",
                audience: "aplication",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential

            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}
