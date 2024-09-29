using HireMeAPI.DAL.Entities;

namespace HireMeAPI.BLL.interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user,List<UserRole> roles);
    }
}
