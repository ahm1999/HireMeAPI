using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]        
        public string? Password { get; set; }
    }
}
