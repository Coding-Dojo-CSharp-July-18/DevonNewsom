using System.Collections.Generic;
using System.Linq;
using DojoSecrets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DojoSecrets.Controllers
{
    
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        private void logEmIn(int userId)
        {
            HttpContext.Session.SetInt32("user", userId);
        }
        private bool emailExists(string email) => _dbContext.Users.Any(u => u.Email == email);
        public HomeController(MyContext context)
        {
            _dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult RegisterNewUser(LogRegModel model)
        {
            RegistrationUser user = model.Registration;
            if(ModelState.IsValid)
            {
                // Verify unique email

                if(_dbContext.Users.Any(u => u.Email == user.email))
                    ModelState.AddModelError("Registration.email", "Email already in use");

                else
                {
                    // Hash PW if email is unique
                    PasswordHasher<RegistrationUser> hasher = new PasswordHasher<RegistrationUser>();
                    string hashedPW = hasher.HashPassword(user, user.password);
                    DSUser newUser = DSUser.Create(user, hashedPW);

                    _dbContext.Users.Add(newUser);
                    _dbContext.SaveChanges();
                    logEmIn(newUser.UserId);
                  
                    return RedirectToAction("Index", "Secret");
                }
            }

            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult PerformLogin(LogRegModel model)
        {
            LoginUser user = model.Login;
            if(ModelState.IsValid)
            {
                // Validate existing email  
                if(!emailExists(user.email))
                    ModelState.AddModelError("Login.email", "Invalid Email/Password");
                
                else
                {
                    DSUser theUser = _dbContext.Users.SingleOrDefault(u => u.Email == user.email);
                    
                    // Compare Hashed PW
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, theUser.Password, user.password);

                    if(result == PasswordVerificationResult.Failed)
                        ModelState.AddModelError("Login.email", "Invalid Email/Password");

                    if(ModelState.IsValid)
                    {
                        logEmIn(theUser.UserId);
                        return RedirectToAction("Index", "Secret");
                    }
                        
                }
            }
            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");   
        }       
    }
}