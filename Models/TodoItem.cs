using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.Context
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public TodoFolder Folder{ get; set; }
    }
}
