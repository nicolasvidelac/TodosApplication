using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTO;

namespace TodoList.Services.IServices
{
    public interface IAuthService
    {
        public Task<string> SignIn(UserDTO userDTO);
        public Task<bool> SignUp(UserDTO userDTO);
    }
}
