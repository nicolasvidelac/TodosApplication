using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoList.Context;
using TodoList.Models;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoItemController : Controller
    {
        private readonly AppDbContext _context;

        public TodoItemController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult> ListAsync()
        {
            return Ok(await _context.todoItems.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(TodoItem item)
        {
            if (item.Description != "" && item.Description != null)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return Ok(await _context.todoItems.ToListAsync());
            } 
            else
            {
                return BadRequest();
            }

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync(int id, TodoItem item)
        {
            var entity = await _context.todoItems.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Description = item.Description;
                entity.Completed = item.Completed;
                await _context.SaveChangesAsync();
                return Ok(await _context.todoItems.ToListAsync());
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await _context.todoItems.FindAsync(id);
            _context.todoItems.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(await _context.todoItems.ToListAsync());
        }
    }
}
