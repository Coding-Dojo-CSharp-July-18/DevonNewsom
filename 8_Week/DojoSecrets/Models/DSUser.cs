using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace DojoSecrets.Models
{
    
    public class RegistrationUser
    {
        [Required]
        [Display(Name="First Name")]
        public string first_name {get;set;}
        [Required]
        [Display(Name="Last Name")]
        public string last_name {get;set;}
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string email {get;set;}
        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [DataType(DataType.Password)]
        [Required]
        [Display(Name="Confirm Password")]
        [Compare("password")]
        public string confirm {get;set;}
    }
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password {get;set;}
    }
}