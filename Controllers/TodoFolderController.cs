using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly ISearcher<TodoFolder> _folderSearcher;
        private readonly ISearcher<TodoItem> _itemSearcher;
        private readonly ISearcher<User> _userSearcher;

        public TodoFolderController(ISearcher<TodoFolder> folderSearcher, ISearcher<TodoItem> itemSearcher, ISearcher<User> userSearcher)
        {
            _folderSearcher = folderSearcher;
            _itemSearcher = itemSearcher;
            _userSearcher = userSearcher;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ListAsync()
        {
            
            var userId = User.FindFirst("userId")?.Value;

            return Ok(await _folderSearcher.ListBy(x => x.user.Id == userId));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(TodoFolder item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                try
                {
                    item.user = await _userSearcher.GetBy(x => x.Id == User.FindFirst("userId").Value);
                    await _folderSearcher.Insert(item);
                    return Ok();
                }
                catch (System.Exception)
                {

                    throw;
                }

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
