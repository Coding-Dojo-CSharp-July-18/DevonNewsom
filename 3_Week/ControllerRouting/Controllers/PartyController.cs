using Microsoft.AspNetCore.Mvc;

namespace ControllerRouting.Controllers
{
    [Route("party")]
    public class PartyController : Controller
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
    }
}