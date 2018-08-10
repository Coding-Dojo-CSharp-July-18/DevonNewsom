using System;
using System.ComponentModel.DataAnnotations;

namespace DapperFun.Models
{
    public class User
    {
        public int user_id {get;set;}
        [Required]
        public string first_name {get;set;}
        public string last_name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
}