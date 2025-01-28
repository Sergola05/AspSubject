using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kt1.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            ViewBag.Message = "Добро пожаловать!";
            ViewBag.CurrentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return View();
        }
        [Route("Page/Greet/{name}")]
        public IActionResult Greet(string name)
        {
            ViewBag.Name = name;
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(string message)
        {
            ViewBag.Message = message; 
            return View("EditResult");
        }
    }
}
