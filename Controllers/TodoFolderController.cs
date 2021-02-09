using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoFolderController : Controller
    {
        private readonly AppDbContext _context;

        public TodoFolderController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult> ListAsync()
        {
            return Ok(await _context.todoFolders.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(TodoFolder item)
        {
            if (item.Description != "" && item.Description != null)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return Ok(await _context.todoFolders.ToListAsync());
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAsync(int id, TodoFolder item)
        {
            var entity = await _context.todoFolders.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Description = item.Description;
                await _context.SaveChangesAsync();
                return Ok(await _context.todoFolders.ToListAsync());
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await _context.todoFolders.FindAsync(id);
            _context.todoFolders.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok(await _context.todoFolders.ToListAsync());
        }
    }
}
