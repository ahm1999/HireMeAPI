using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    public class Experience
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string JobDescription { get; set; }

        public string ComanyName { get; set; }
        public DateOnly StartedFrom { get; set; }

        public DateOnly WorkedUntill { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User _User { get; set; }

        public ICollection<ExperienceWorkFields> WorkFields { get; set;  }        

       }
}
