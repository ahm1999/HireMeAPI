using HireMeAPI.BLL.Services;

namespace HireMeAPI.BLL.interfaces
{
    public interface IRoleService
    {
        public Task<RoleServiceResponse> AddRole(string role);
        public Task<RoleServiceResponse> IsUserInRole(string Role,Guid UserId);

        public Task<RoleServiceResponse> AddUserToRole(Guid UserId,string role);

        public Task<RoleServiceResponse> GetUserRoles(Guid UserId);

    }
}
