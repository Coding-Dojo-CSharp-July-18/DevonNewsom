using Microsoft.AspNetCore.Mvc;
using Routing.Models;
namespace Routing
{
    [Route("dashboard")]
    public class WallController : Controller
    {
        // GET: localhost:5000/dashboard
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: localhost:5000/dashboard/create
        [HttpPost("create")]
        public IActionResult Create()
        {
            return Json("");
        }
    }
}