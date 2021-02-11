using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.DTO;
using TodoList.Models;
using TodoList.Repository;
using TodoList.Services.IServices;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class TodoFolderController : Controller
    {
        private readonly ITodoFolderService _todoFoldersService;

        public TodoFolderController(ITodoFolderService todoFoldersService)
        {
            _todoFoldersService = todoFoldersService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ListAsync()
        {
            
            string userId = User.FindFirst("userId")?.Value;
            var result = await  _todoFoldersService.List(userId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(TodoFolderDTO item)
        {
            if (!string.IsNullOrWhiteSpace(item.Description))
            {
                try
                {
                    await _todoFoldersService.Create(item, @User.FindFirst("userId").Value);
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
                await _todoFoldersService.Remove(id);
                return Ok(true);
            }
            catch (System.Exception)
            {
                return BadRequest("Can't delete non existing Folder");
            }
        }
    }

}
