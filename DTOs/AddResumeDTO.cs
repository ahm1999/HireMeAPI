using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class AddResumeDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string FileUrl { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
