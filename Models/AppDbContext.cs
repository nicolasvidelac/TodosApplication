using Microsoft.EntityFrameworkCore;
using TodoList.Context;

namespace TodoList.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> todoItems { get; set; }
    }


}
