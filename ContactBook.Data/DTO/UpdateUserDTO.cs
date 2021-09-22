using System;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Data.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
