using System;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.Models
{
    public class Review
    {
        [Key]
        public int ReviewId {get;set;}
        public int BookId {get;set;}
        public int UserId {get;set;}
        public string Content {get;set;}
        public int Rating {get;set;}
        public DateTime CreatedAt {get;set;}
        public Book ReviewedBook {get;set;}
        public ReviewerUser Reviewer {get;set;}
        public Review()
        {
            CreatedAt = DateTime.Now;
        }
    }
}