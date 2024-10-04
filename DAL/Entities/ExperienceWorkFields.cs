using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeAPI.DAL.Entities
{
    [PrimaryKey(nameof(ExperienceId),nameof(WorkFieldId))]
    public class ExperienceWorkFields
    {
        [ForeignKey(nameof(Experience))]
        public Guid ExperienceId { get; set; }

        public Guid WorkFieldId { get; set;  }

        public Experience Experience_ { get; set;  }

        public WorkFields WorkField { get; set; }
    }
}
