using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Clients
    {
        [Required] public int ClientsId {  get; set; }
        public string? ClientName { get; set; }
        public List<Tasks> tasks { get; set; }= new List<Tasks>();
    }
}
