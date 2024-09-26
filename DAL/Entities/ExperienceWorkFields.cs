using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    [PrimaryKey(nameof(ExperienceId),nameof(WorkFieldId))]
    public class ExperienceWorkFields
    {
        [ForeignKey(nameof(Experience))]
        public Guid ExperienceId { get; set; }

        [ForeignKey(nameof(WorkFields))]
        public Guid WorkFieldId { get; set;  }

        public Experience Experience_ { get; set;  }

        public WorkFields WorkField_ { get; set; }
    }
}
