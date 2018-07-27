using Microsoft.AspNetCore.Mvc;

namespace ControllerRouting.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpGet("goto")]
        public IActionResult TheParty()
        {
            return RedirectToAction("Index", "Party");
        }
    }
}