using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ToDoList.Models
{
    public class Tasks
    {
        [Key]
        public int TasksId { get; set; }
        public int ClientsId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }

        public Clients client { get; set; } = null!;
    }
}
