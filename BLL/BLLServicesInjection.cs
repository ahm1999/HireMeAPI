using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;

namespace HireMeAPI.BLL
{
    public static class BLLServicesInjection
    {

        public static void RegisterBLLServices(this IServiceCollection services, IConfiguration Configuration) {



            services.AddTransient<IPasswordHasher,PasswordHasher>();
            services.AddTransient<ITokenService, TokentService>();
            services.AddScoped<IUserService, UserService>();
        
        
        }
    }
}
