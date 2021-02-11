using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.DTO;

namespace TodoList.Services
{
    public interface ITodoItemsService
    {
        Task<IEnumerable<TodoItem>> List(int id);
        Task<TodoItem> Create(TodoItemDTO todoItemDTO);
        Task<TodoItem> Update(int id, TodoItemDTO itemDTO);
        Task<bool> Remove(int id);
    }
}
