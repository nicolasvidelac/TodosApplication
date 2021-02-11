using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.DTO;
using TodoList.Extras;
using TodoList.Models;
using TodoList.Repository;
using TodoList.Services.IServices;

namespace TodoList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("signin"), HttpPost]
        public async Task<IActionResult> SignIn (UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            var result = await _authService.SignIn(userDTO);
            if (result == null)
            {
            
                return Unauthorized();
            }
            else
            {
                return Ok(new { access_token = result, username = userDTO.Username });
            }
        }
        [Route("signup"), HttpPost]
        public async Task<IActionResult> SingUp (UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Username) || string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest();
            }

            if (await _authService.SignUp(userDTO))
            {
            return Ok();

            } else
            {
                return BadRequest();
            }
        }
    }
}
