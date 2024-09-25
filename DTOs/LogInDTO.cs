using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class LogInDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? password { get; set; }
    }
}
