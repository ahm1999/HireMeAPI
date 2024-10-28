using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class CreateJobPostingDTO
    {
        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string JobDescription { get; set; }
    }
}
