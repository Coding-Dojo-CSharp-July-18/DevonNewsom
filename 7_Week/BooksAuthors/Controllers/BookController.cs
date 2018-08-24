using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksAuthors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BooksAuthors.Controllers
{
    public class BookController : Controller
    {
        public int LoggedInUser
        {
            get { return 1;}
        }
        private BookContext _dbContext;
        public BookController(BookContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var ReviewsWithBookAndUser = _dbContext.Reviews
                .Include(r => r.Reviewer)
                .Include(r => r.ReviewedBook);

            IEnumerable<Review> RecentThree = ReviewsWithBookAndUser
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToList();

            // books where reviews not in the top 3 most recent
            IEnumerable<Book> notRecentlyReviewed = _dbContext.Books
                .Include(b => b.Reviews)
                .Where(b => 
                    !b.Reviews.Any(r => RecentThree.Contains(r)));
            

            return View();
        }

        public IActionResult ShowUser(int id)
        {
            ReviewerUser theUser = _dbContext.Users
                .Include(u => u.ReviewsLeft)
                .ThenInclude(r => r.ReviewedBook)
                .SingleOrDefault( u => u.UserId == LoggedInUser);

            return View(theUser);
        }
    
        public IActionResult ShowBook(int id)
        {
            Book theBook = _dbContext.Books
                .Include(b => b.Reviews)
                .ThenInclude(r => r.Reviewer)
                .SingleOrDefault( b => b.BookId == id);

            return View(theBook);
        }
        

    }
}
