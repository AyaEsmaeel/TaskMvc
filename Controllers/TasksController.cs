using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        ApplicationDbcontext context = new ApplicationDbcontext();

        public IActionResult CreateNewItem()
        {
            return View();
        }

        public IActionResult Index(string name)
        {
            var client = context.client.FirstOrDefault(c => c.ClientName == name);
            if (client != null)
            {
                var tasks = context.tasks.Where(t => t.ClientsId == client.ClientsId).ToList();
                ViewBag.ClientName = name;
                return View(tasks);
            }
            else
            {
                ViewBag.ErrorMessage = "Client not found";
                return View(new List<Tasks>());
            }
        }

        public IActionResult Edit(int id)
        {
            var result = context.tasks.Find(id);
            return View(result);
        }
        public IActionResult SaveEdit(Tasks task)
        {
            context.tasks.Update(task);
            context.SaveChanges();

            var clientName = context.client.FirstOrDefault(c => c.ClientsId == task.ClientsId)?.ClientName;

            return RedirectToAction("Index", new { name = clientName });
        }
        public IActionResult Delete(int id)
        {
            
            var result = context.tasks.Find(id);
            context.tasks.Remove(result);
            context.SaveChanges();

            var ClientId = result.ClientsId;
            var clientName = context.client.FirstOrDefault(c => c.ClientsId == ClientId)?.ClientName;

            return RedirectToAction("Index", new { name = clientName });
        }
        public IActionResult CreateNew(int id)
        {
            var result = context.tasks.Find(id);
            return View(result);
        }
        public IActionResult SaveNew(Tasks task)
        {
                context.tasks.Add(task);
                context.SaveChanges();

                var clientName = context.client.FirstOrDefault(c => c.ClientsId == task.ClientsId)?.ClientName;

                return RedirectToAction("Index", new { name = clientName });
        }
    }
}
