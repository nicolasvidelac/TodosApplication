using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
