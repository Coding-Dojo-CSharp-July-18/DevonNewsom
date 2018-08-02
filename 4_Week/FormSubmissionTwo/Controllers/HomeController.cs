using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmissionTwo.Models;

namespace FormSubmissionTwo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User theUser)
        {
            // Validate DOB

            if(DateTime.Now < theUser.DOB)
                ModelState.AddModelError("DOB", "Date must be in past!");

            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }
        [HttpGet("success")]
        public string Success()
        {
            return "SUCCESS";
        }

    }
}
