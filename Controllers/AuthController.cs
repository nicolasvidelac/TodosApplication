using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoList.Extras;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        [Route("login"), HttpPost]
        public IActionResult Login ([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else if (user.Username == "johndoe" && user.Password == "1234")
            {
                var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                var key = new SymmetricSecurityKey(secretBytes);

                var algorithm = SecurityAlgorithms.HmacSha256;

                var signingCredentials = new SigningCredentials(key, algorithm);

                var token = new JwtSecurityToken(
                    Constants.Issuer,
                    Constants.Audiance,
                    claims: new List<Claim>(),
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials
                );


                var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { access_token = tokenJson });
            }
            else
            {
                return Unauthorized();
            }
        }
        
    }
}
