using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
namespace DojoSecrets.Models
{
    public class DSUser
    {
        [Key]
        public int UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public IEnumerable<Secret> Secrets {get;set;}
        public IEnumerable<Like> Likes {get;set;}

        public static DSUser Create(RegistrationUser user, string hash)
        {
            return new DSUser()
            {
                FirstName = user.first_name,
                LastName = user.last_name,
                Email = user.email,
                Password = hash,
            };
        }
    }
    public class Secret
    {
        [Key]
        public int SecretId {get;set;}
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public DSUser Creator {get;set;}
        public IEnumerable<Like> Likes {get;set;}
    }
    public class Like
    {
        [Key]
        public int LikeId {get;set;}
        public int UserId {get;set;}
        public int SecretId {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DSUser Liker {get;set;}
    }
}