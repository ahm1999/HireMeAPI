
namespace HireMeAPI.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string passwordHash { get; set; }

        public string Email { get; set; }
        public ICollection<Resume> Resumes { get; set; }

        public ICollection<Experience> Experiences { get; set; }

        public ICollection<UserRole> userRoles { get; set;  }

    }
}
