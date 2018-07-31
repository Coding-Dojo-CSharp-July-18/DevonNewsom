using System.ComponentModel.DataAnnotations;

namespace ModelsLecture.Models
{
    public class Friend
    {
        [Required(ErrorMessage="Name is required")]
        [Display(Name="Custom Name")]
        public string Name {get;set;}
        [EmailAddress(ErrorMessage="Please enter a valid EMAIL")]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}
        [Required]
        [MinLength(3, ErrorMessage="Location field must be 3 characters or greater")]
        public string Location {get;set;}
        [Range(13,100)]
        public int Age {get;set;}
    }
}