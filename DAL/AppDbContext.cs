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
    }
}
