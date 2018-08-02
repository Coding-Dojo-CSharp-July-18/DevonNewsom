using System;
using System.ComponentModel.DataAnnotations;
namespace FormSubmissionTwo.Models
{
    public class User
    {
        [MinLength(3, ErrorMessage="Must be 3 or more characters")]
        // Must be 3 or more characters
        public string Name {get;set;}
        // Must be valid Email address
        [EmailAddress]
        public string Email {get;set;}
        // Must be past-dated
        [DataType(DataType.Date)]
        // We will validate in CONTROLLER (for now...
        [FutureDate]
        public DateTime DOB {get;set;}
        // must be 8 characters or more
        [MinLength(8, ErrorMessage="Must be 8 or more characters")]
        public string Password {get;set;}
        // must match Password
        [Compare("Password")]
        public string Confirm {get;set;}
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Im not checking to see if this is a valid DateTime!!
            DateTime val = (DateTime)value;
            if(val > DateTime.Now)
                return new ValidationResult("Date must be in future");
            return ValidationResult.Success;
        }
    }
}