using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.Models
{
    public class Book
    {
        [Key]
        public int BookId {get;set;}
        public string Title {get;set;}
        public string Author {get;set;}
        public DateTime Published {get;set;}
        public IEnumerable<Review> Reviews {get;set;}

    }
}