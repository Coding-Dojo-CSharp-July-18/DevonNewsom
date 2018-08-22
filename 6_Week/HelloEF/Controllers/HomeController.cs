using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloEF.Models;
using Microsoft.AspNetCore.Hosting;

namespace HelloEF.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        public HomeController(MyContext contextService, DummyService dummy)
        {
            _dbContext = contextService;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // Most recent 10
            ViewBag.Friends = _dbContext.Friends
                .OrderByDescending(f => f.UpdatedAt)
                .Take(10);

            return View();
        }
        // Show
        [HttpGet("{friendId}")]
        public IActionResult Show(int friendId)
        {
            // Query ONE friend with id
            Friend oneFriend = _dbContext.Friends.SingleOrDefault(f => f.FriendId == friendId);

            return View(oneFriend);
        }
        // Create
        [HttpPost("create")]
        public IActionResult Create(Friend friend)
        {
            if(ModelState.IsValid)
            {
                // Create a friend
                _dbContext.Friends.Add(friend);
                _dbContext.SaveChanges();
                return Json(friend);
            }
            ViewBag.Friends = _dbContext.Friends;
            return View("Index");
        }
        // Update
        [HttpPost("update/{friendId}")]    
        public IActionResult Update(Friend friend, int friendId)
        {
            if(ModelState.IsValid)
            {
                // Update a friend
                // query a friend
                Friend toUpdate = _dbContext.Friends.SingleOrDefault(
                    f => f.FriendId == friendId
                );
                toUpdate.Name = friend.Name;
                toUpdate.UpdatedAt = DateTime.Now;
                _dbContext.SaveChanges();
                return Json(friend);
            }
            return View("Show");
        }
        // Delete
        [HttpGet("delete/{friendId}")]
        public IActionResult Delete(int friendId)
        {
            // delete a friend
            // query for friend with id
            Friend toDelete = _dbContext.Friends.SingleOrDefault(
                f => f.FriendId == friendId
            );

            _dbContext.Friends.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
