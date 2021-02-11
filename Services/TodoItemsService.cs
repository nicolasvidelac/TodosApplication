using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.DTO;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        ISearcher<TodoItem> _itemSearcher;
        ISearcher<TodoFolder> _folderSearcher;

        public TodoItemsService(ISearcher<TodoItem> itemSearcher, ISearcher<TodoFolder> folderSearcher)
        {
            _folderSearcher = folderSearcher;
            _itemSearcher = itemSearcher;

        }
        public async Task<TodoItem> Create(TodoItemDTO itemDTO)
        {
            TodoItem newItem = new TodoItem
            {
                Description = itemDTO.Description,
                Folder = await _folderSearcher.GetById(itemDTO.Folder.Id)
            };

            return await _itemSearcher.Insert(newItem);
        }



        public async Task<IEnumerable<TodoItem>> List(int id)
        {
            return await _itemSearcher.ListBy(s => s.Folder.Id == id);
        }


        public async Task<bool> Remove(int id)
        {
            await _itemSearcher.Remove(id);
            return true;
        }


        public async Task<TodoItem> Update(int id, TodoItemDTO itemDTO)
        {
            var entity = await _itemSearcher.GetById(id);

            entity.Description = itemDTO.Description;
            entity.Completed = itemDTO.Completed;

            return await _itemSearcher.Update(id, entity);
        }
    }
}
