using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class TodoFolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public User user { get; set; }

    }
}
