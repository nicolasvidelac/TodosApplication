using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.DTO;
using TodoList.Models;
using TodoList.Repository;
using TodoList.Services.IServices;

namespace TodoList.Services
{
    public class TodoFolderService : ITodoFolderService
    {
        private readonly ISearcher<TodoFolder> _folderSearcher;
        private readonly ISearcher<TodoItem> _itemSearcher;
        private readonly ISearcher<User> _userSearcher;

        public TodoFolderService(ISearcher<TodoFolder> folderSearcher, ISearcher<TodoItem> itemSearcher, ISearcher<User> userSearcher)
        {
            _folderSearcher = folderSearcher;
            _itemSearcher = itemSearcher;
            _userSearcher = userSearcher;
        }

        public async Task<TodoFolder> Create(TodoFolderDTO itemDTO, string userId)
        {
            TodoFolder item = new TodoFolder() { Description = itemDTO.Description};
            item.user = await _userSearcher.GetBy(x => x.Id == userId);
            return await _folderSearcher.Insert(item);
        }

        public async Task<IEnumerable<TodoFolder>> List(string userId)
        {
            return await _folderSearcher.ListBy(x => x.user.Id == userId);
        }

        public async Task<bool> Remove(int id)
        {
            var folderItems = await _itemSearcher.ListBy(s => s.Folder.Id == id);

            foreach (var item in folderItems)
            {
                await _itemSearcher.Remove(item.Id);
            }

            await _folderSearcher.Remove(id);
            return true;
        }
    }
}
