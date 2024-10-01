using HireMeAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireMeAPI.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set;  }

        public DbSet<Role> Roles { get; set;  }

        public DbSet<WorkFields> WorkFields { get; set; }  
        
        public DbSet<ExperienceWorkFields> ExperienceWorkFields { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
