using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.DTO;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoItemController : Controller
    {
        ISearcher<TodoItem> _itemSearcher;
        ISearcher<TodoFolder> _folderSearcher;

        public TodoItemController(ISearcher<TodoItem> itemSearcher, ISearcher<TodoFolder> folderSearcher)
        {
            _folderSearcher = folderSearcher;
            _itemSearcher = itemSearcher;

        }

        [HttpGet("{idFolder}")]
        [Authorize]
        public async Task<ActionResult> ListAsync(int idFolder)
        {
            var result = await _itemSearcher.ListBy(s => s.Folder.Id == idFolder);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(TodoItemDTO itemDTO)
        {
            try
            {
                TodoItem newItem = new TodoItem();
                newItem.Description = itemDTO.Description;
                newItem.Folder = await _folderSearcher.GetById(itemDTO.Folder.Id);
                

                return Ok(await _itemSearcher.Insert(newItem));
            } 
            catch
            {
                return BadRequest("Description cannot be empty");
            }

        }

        [HttpPatch("item/{id}")]
        [Authorize]

        public async Task<ActionResult> PatchAsync(int id, TodoItemDTO itemDTO)
        {
            var entity = await _itemSearcher.GetById(id);

            try
            {
                entity.Description = itemDTO.Description;
                entity.Completed = itemDTO.Completed;

                await _itemSearcher.Update(id, entity);

                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest("Can't change non existing Item");
            }

        }

        [HttpDelete("item/{id}")]
        [Authorize]

        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _itemSearcher.Remove(id);
                return Ok(true);
            }
            catch (System.Exception)
            {
                return BadRequest("Can't delete non existing item");
            }

        }
    }
}
