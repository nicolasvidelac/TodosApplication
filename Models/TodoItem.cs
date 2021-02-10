using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Models;

namespace TodoList.Context
{
    public class TodoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public TodoFolder Folder{ get; set; }
    }
}
