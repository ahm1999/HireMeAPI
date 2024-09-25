
using Microsoft.EntityFrameworkCore;

namespace HireMeAPI.DAL
{
    public static class DALServiceInjection
    {
        public static void RegisterDALServices(this IServiceCollection services, IConfiguration Configuration) {

            var connectionString = Configuration.GetConnectionString("SqlServer");
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
