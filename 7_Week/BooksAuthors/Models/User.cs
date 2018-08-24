using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.Models
{
    public class ReviewerUser
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Alias {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        public IEnumerable<Review> ReviewsLeft {get;set;}
    }
    public class RegUser : ReviewerUser
    {
        [Compare("Password")]
        public string ComparePassword {get;set;}
    }
    public class LogUser
    {
        public string LoginName {get;set;}
        public string PasswordAttempt {get;set;}
    }
}