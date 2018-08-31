using System.Collections.Generic;
using System.Linq;
using DojoSecrets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DojoSecrets.Controllers
{
    [Route("secrets")]
    public class SecretController : Controller
    {
        private bool NotInSession
        {
            get { return HttpContext.Session.GetInt32("user") == null; }
        }
        private MyContext _dbContext;
        public SecretController(MyContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(NotInSession)
                return RedirectToAction("Index", "Home");

            IEnumerable<Secret> recent = _dbContext.Secrets
                .Include(s => s.Likes)
                .OrderByDescending(s => s.CreatedAt)
                .Take(10);

            bool userHasLikedASecret = recent.First().Likes.Any(l => l.UserId == 1);

            DashboardViewModel model = new DashboardViewModel()
            {
                ActiveUserId = (int)HttpContext.Session.GetInt32("user"),
                RecentSecrets = recent
            };
            return View(model);
        }
        [HttpGet("like/{secretId}")]
        public IActionResult Like(int secretId)
        {
            // create a like from secretId and HttpContext.Session.GetInt32("user")
            return RedirectToAction("Index");
        }
        [HttpGet("delete/{secretId}")]
        public IActionResult Delete(int secretId)
        {
            // query for like with secretId and HttpContext.Session.GetInt32("user")
            // _dbContext.Likes.Remove(like);
            // _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}