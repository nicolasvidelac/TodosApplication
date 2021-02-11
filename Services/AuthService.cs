using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

using System.Text;
using System.Threading.Tasks;
using TodoList.DTO;
using TodoList.Extras;
using TodoList.Models;
using TodoList.Repository;
using TodoList.Services.IServices;

namespace TodoList.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISearcher<User> _userSearcher;

        public AuthService(ISearcher<User> userSearcher)
        {
            _userSearcher = userSearcher;
        }

        public async Task<string> SignIn(UserDTO userDTO)
        {

            userDTO.Username = userDTO.Username.ToLower();
            userDTO.Password = Constants.EncryptPwd(userDTO.Password);

            var result = await _userSearcher.GetBy(x => x.Username == userDTO.Username && x.Password == userDTO.Password);

            if (result != null)
            {
                var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                var key = new SymmetricSecurityKey(secretBytes);

                var algorithm = SecurityAlgorithms.HmacSha256;

                var signingCredentials = new SigningCredentials(key, algorithm);

                var token = new JwtSecurityToken(
                    Constants.Issuer,
                    Constants.Audiance,
                    claims: new Claim[] { new Claim("userId", result.Id) },
                    notBefore: DateTime.Now,

                    expires: DateTime.Now.AddDays(1),
                    signingCredentials
                );


                var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenJson;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> SignUp(UserDTO userDTO)
        {
            userDTO.Username = userDTO.Username.ToLower();

            var users = await _userSearcher.ListBy(null);

            foreach (var item in users)
            {
                if (item.Username == userDTO.Username)
                {
                    return false;
                }
            }

            User entity = new User() { Password = Constants.EncryptPwd(userDTO.Password), Username = userDTO.Username };

            await _userSearcher.Insert(entity);
            return true;
        }
    }
}
