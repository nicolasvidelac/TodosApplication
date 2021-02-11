using TodoList.Models;

namespace TodoList.DTO
{
    public class TodoItemDTO
    {
        public string Description { get; set; }
        public TodoFolder Folder { get; set; }
        public bool Completed { get; set; }
    }
}
