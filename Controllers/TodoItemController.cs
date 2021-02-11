using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoList.DTO;
using TodoList.Services;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        [HttpGet("{idFolder}")]
        [Authorize]
        public async Task<ActionResult> ListAsync(int idFolder)
        {
            var result = await _todoItemsService.List(idFolder);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(TodoItemDTO itemDTO)
        {
            try
            {
                var result = await _todoItemsService.Create(itemDTO);
                return Ok(result);
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


            try
            {
                await _todoItemsService.Update(id, itemDTO);
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
                await _todoItemsService.Remove(id);
                return Ok(true);
            }
            catch (System.Exception)
            {
                return BadRequest("Can't delete non existing item");
            }

        }
    }
}
