using Microsoft.AspNetCore.Mvc;
using Routing.Models;
namespace Routing
{
    public class HomeController : Controller
    {
        // GET: localhost:5000
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("somewhere/{place}")]
        public IActionResult Somewhere(string place)
        {
            if(place == "cool")
                return RedirectToAction("Index");

            ViewBag.Errors = "AN error is here!";
            return View("Index");

        }
        [HttpGet("cool")]
        public IActionResult Cool()
        {
            return RedirectToAction("Somewhere", new {place = "Hawaii"});
        }
        [HttpGet("create")]
        public IActionResult Register(User user)
        {
            // stuff
            return Json(user);
        }
    }
}