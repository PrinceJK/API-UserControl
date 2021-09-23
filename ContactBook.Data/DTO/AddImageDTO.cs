using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Data.DTO
{
    public class AddImageDTO
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
