using System.Collections.Generic;
using System.Linq;
using LoginFun.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginFun.Controllers
{
    
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult RegisterNewUser(RegistrationUser user)
        {
            if(ModelState.IsValid)
            {
                // Verify unique email

                List<Dictionary<string, object>> rows = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
                if(rows.Count > 0)
                    ModelState.AddModelError("email", "Email already in use");

                else
                {
                    // Hash PW if email is unique
                    PasswordHasher<RegistrationUser> hasher = new PasswordHasher<RegistrationUser>();
                    string hashedPW = hasher.HashPassword(user, user.password);


                    // Store user info in DB
                    string insertString = 
                    $@"
                        INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) 
                        VALUES ('{user.first_name}','{user.last_name}','{user.email}','{hashedPW}', NOW(), NOW() )
                    ";

                    DbConnector.Execute(insertString);

                    TempData["message"] = "You may now log in!";
                    return RedirectToAction("Login");
                }
            }

            return View("Register");
        }

        [HttpPost("login")]
        public IActionResult PerformLogin(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                // Validate existing email  
                List<Dictionary<string, object>> userRows = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");

                if(userRows.Count < 1)
                    ModelState.AddModelError("email", "Invalid Email/Password");
                
                else
                {
                    Dictionary<string, object> theUser = userRows.First();
                    string pwInDb = (string)theUser["password"];
                    int userIdInDB = (int)theUser["user_id"];

                    // Compare Hashed PW
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, pwInDb, user.password);

                    if(result == PasswordVerificationResult.Failed)
                        ModelState.AddModelError("email", "Invalid Email/Password");

                    if(ModelState.IsValid)
                    {
                        // Assign Session["id"] to user's id
                        HttpContext.Session.SetInt32("id", userIdInDB);
                        return Json("success");
                    }
                        
                }
            }
            

            return View("Login");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");   
        }       
    }
}