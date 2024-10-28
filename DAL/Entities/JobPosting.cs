using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{

    [PrimaryKey(nameof(JobPostingId))]
    public class JobPosting
    {

        public Guid JobPostingId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        [ForeignKey(nameof(User))]
        public Guid CreatorId { get; set;  }

        public User Creator { get; set; }
        public ICollection<Application> UserApplications { get; set; }

    }
}
