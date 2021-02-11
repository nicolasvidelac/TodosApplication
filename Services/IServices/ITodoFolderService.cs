using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DTO;
using TodoList.Models;

namespace TodoList.Services.IServices
{
    public interface ITodoFolderService
    {
        Task<IEnumerable<TodoFolder>> List(string userId);
        Task<TodoFolder> Create(TodoFolderDTO todoFolderD, string userId);
        Task<bool> Remove(int id);
    }
}
