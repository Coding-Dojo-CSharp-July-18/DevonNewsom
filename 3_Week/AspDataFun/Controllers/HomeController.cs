using Microsoft.AspNetCore.Mvc;

namespace AspDataFun.Controllers 
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            string[] words = new string[]
            {
                "Apple", "Orange", "Cherries"
            };

            ViewBag.Name = "Bow Wow";

            ViewBag.Fruits = words;
            return View();
        }
        [HttpPost("doit")]
        public IActionResult DoIt(string name, string location, string fruits)
        {
            object anon = new 
            {
                TheName = name,
                TheLocation = location,
                TheFruit = fruits
            };

            return Json(anon);
        }
    }
}