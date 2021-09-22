using System.ComponentModel.DataAnnotations;

namespace ContactBook.Data.DTO
{
    public class RegistrationRequestDTO
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string PassWord {  get; set; }
        
    }
}
