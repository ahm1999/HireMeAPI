using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    public class Resume
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? FileUrl { get; set; }

        public string? Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User Applicant { get; set; }

    }
}
