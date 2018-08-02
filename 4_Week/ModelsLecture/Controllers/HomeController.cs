using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLecture.Models;

namespace ModelsLecture.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // Pass some data
            Friend friend1 = new Friend()
            {
                Name = "Devon",
                Location = "Washington"
            };
            Friend friend2 = new Friend()
            {
                Name = "Richard",
                Location = "Virginia"
            };
            return View(new Friend[]
            {
                friend1, friend2
            });
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Friend myNewFriend)
        {
            if(myNewFriend.Name == "Devon")
                ModelState.AddModelError("Name", "NO DEVONS ALLOWED");

            
            
            if(ModelState.IsValid)
                return Json(myNewFriend);
                
            return View("New", myNewFriend);
        }
        
    }
}
