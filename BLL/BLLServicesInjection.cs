using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;

namespace HireMeAPI.BLL
{
    public static class BLLServicesInjection
    {

        public static void RegisterBLLServices(this IServiceCollection services, IConfiguration Configuration) {


            services.AddHttpContextAccessor();
            services.AddTransient<IPasswordHasher,PasswordHasher>();
            services.AddTransient<ITokenService, TokentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IWorkFieldService, WorkFieldService>();

        
        
        }
    }
}
