using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class TodoFolderController : Controller
    {
        ISearcher<TodoFolder> _folderSearcher;
        ISearcher<TodoItem> _itemSearcher;

        public TodoFolderController(ISearcher<TodoFolder> folderSearcher, ISearcher<TodoItem> itemSearcher)
        {
            _folderSearcher = folderSearcher;
            _itemSearcher = itemSearcher;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ListAsync()
        {
            return Ok(await _folderSearcher.ListBy(null));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(TodoFolder item)
        {
            if (item.Description != "" && item.Description != null)
            {
                return Ok(await _folderSearcher.Insert(item));
            }
            else
            {
                return BadRequest("Description cannot be empty");
            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var folderItems = await _itemSearcher.ListBy(s => s.Folder.Id == id);

                foreach (var item in folderItems)
                {
                    await _itemSearcher.Remove(item.Id);
                }

                await _folderSearcher.Remove(id);
                return Ok(true);
            }
            catch (System.Exception)
            {
                return BadRequest("Can't delete non existing Folder");
            }
        }
    }

}
