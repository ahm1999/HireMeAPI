using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class CreateApplicationDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid JobPostingId { get; set; }

        [Required]

        public Guid ResumeId { get; set; }

    }
}
