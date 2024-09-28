using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class UserExperienceDTO
    {
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string ComanyName { get; set; }
        [Required]
        public DateOnly StartedFrom { get; set; }
        [Required]
        public DateOnly WorkedUntill { get; set; }

        public List<Guid> WorkFields { get; set; } 
    }
}
