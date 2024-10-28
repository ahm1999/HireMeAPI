using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace HireMeAPI.BLL.interfaces
{
    public interface IUserService
    {
        public Task<Guid> CreateUserAccountAsync(SignUpDTO userData,bool IsRecruiter);

        public Task<LogInResponse> LogInAsync(LogInDTO userData);

        public Guid GetUserId();
        public UserDataResponse GetUserData(ClaimsPrincipal User);
    }
}
