using System;
using System.ComponentModel.DataAnnotations;

namespace HelloEF.Models
{
    public class Friend
    {
        [Key]
        public int FriendId {get;set;}
        [Required]
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public Friend()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public string CreatedAtFormatted
        {
            get { return CreatedAt.ToString("d"); }
        }
    }
    public class DummyService
    {
        public string Message = "Hey Im a service";
    }
}