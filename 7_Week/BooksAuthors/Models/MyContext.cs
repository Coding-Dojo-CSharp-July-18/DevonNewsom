using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BooksAuthors.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options) {}
        public DbSet<ReviewerUser> Users {get;set;}
        public DbSet<Book> Books {get;set;}
        public DbSet<Review> Reviews {get;set;}
    }
}