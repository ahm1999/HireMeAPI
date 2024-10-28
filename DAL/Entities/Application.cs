using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    [PrimaryKey(nameof(UserId),nameof(JobPostingId))]
    public class Application
    {
        [ForeignKey(nameof(User))]
        public Guid  UserId { get; set; }
        [ForeignKey(nameof(JobPosting))]

        public Guid  JobPostingId { get; set; }

        public JobPosting JobPosting { get; set; }

        public Guid ResumeId { get; set; }

        public Resume resume { get; set; }

        public User User { get; set; }  

    }
}
