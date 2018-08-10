using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperFun.Models;

namespace DapperFun.Controllers
{
    public class HomeController : Controller
    {
        private UserFactory _userFactory;
        public HomeController(UserFactory userFactoryService)
        {
            _userFactory = userFactoryService;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            IEnumerable<User> recentUsers = _userFactory.MostRecentFive();
            
            return View(recentUsers);
        }
        [HttpGet("users/{id}")]
        public IActionResult Show(int id)
        {
            return View(_userFactory.GetUserById(id));
        }

        [HttpPost("register")]
        public IActionResult Registration(User user)
        {
            if(ModelState.IsValid)
            {
                if(!_userFactory.EmailIsUnique(user.email))
                    ModelState.AddModelError("email", "Email is not unique!");

                // ALL THE REG THING
                _userFactory.CreateUser(user);
            }

            return RedirectToAction("Index");
        }

    }
}
