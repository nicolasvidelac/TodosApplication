using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
