using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoLeagueEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DojoLeagueEF.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        public HomeController(MyContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // Test Queries:
            

            return View(new HomeViewModel()
            {
                AllDojos = _dbContext.Dojos,
                AllNinjas = _dbContext.Ninjas
            });
        }
        [HttpGet("ninja/new")]
        public IActionResult NewNinja()
        {
            ViewBag.Dojos = _dbContext.Dojos;
            return View();
        }

        [HttpGet("ninja/{id}")]
        public IActionResult Ninja(int id)
        {

            // Query for ONE Ninja, with Dojo
            Ninja ninjaModel = _dbContext.Ninjas
                .Include(n => n.MyDojo)
                .SingleOrDefault(n => n.NinjaId == id);

            return View(ninjaModel);
        }

        [HttpGet("dojo/{id}")]
        public IActionResult Dojo(int id)
        {

            // Query for ONE Dojo, with Ninjas
            Dojo dojoModel = _dbContext.Dojos
                .Include(d => d.Ninjas)
                .SingleOrDefault(d => d.DojoId == id);

            return View(dojoModel);
        }
    }
}
