namespace HireMeAPI.DAL.Entities
{
    public class WorkFields
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<ExperienceWorkFields> ExperienceWorkFields { get; set; } 
    }
}
