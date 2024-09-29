using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireMeAPI.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context; 
        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RoleServiceResponse> AddRole(string role)
        {
            if (await _context.Roles.AnyAsync(r => r.AssignedRole == role))
            {
                return new RoleServiceResponse(false, "Role already added");
            }


            Role _role = new Role() {
                Id = Guid.NewGuid(),
                AssignedRole = role
            };
            await _context.Roles.AddAsync(_role);
            await _context.SaveChangesAsync();

            return new RoleServiceResponse(true, "Role Added succesfully");

        }

        public async Task<RoleServiceResponse> AddUserToRole(Guid UserId, string role)
        {
            var _role = await _context.Roles.FirstOrDefaultAsync(r => r.AssignedRole == role);
            if (_role is null) return new RoleServiceResponse(false, "role doesn't exist");

            var response = await IsUserInRole(role, UserId);

            if (response.Success) {
                return new RoleServiceResponse(false, "User already in role");
            };

            var _userRole = new UserRole()
            {
                RoleId = _role.Id,
                UserId = UserId

            };

            await _context.UserRoles.AddAsync(_userRole);
            await _context.SaveChangesAsync();

            return new RoleServiceResponse(true, "user Added succesfully to that role ");

        }

        public async Task<RoleServiceResponse> GetUserRoles(Guid UserId)
        {
            List<UserRole> _userRole = await _context.UserRoles
                                                     .Include(ur => ur.Role_)
                                                     .Where(ur => ur.UserId == UserId)
                                                     .ToListAsync();
            return new RoleServiceResponse(true,"User Roles", _userRole);

        }

        public async Task<RoleServiceResponse> IsUserInRole(string Role,Guid UserId)
        {
            var ServiceRes = await GetUserRoles(UserId);
            bool Statues = ServiceRes.roles.Any(ur => ur.Role_.AssignedRole == Role);
            if (!Statues)
            {
                return new RoleServiceResponse(false, "User Not in role");
            }
            return new RoleServiceResponse(true, $"User In {Role} role ");            
        }
    }

    public record RoleServiceResponse(bool Success, string messege) {

        public List<UserRole> roles { get; set; }
        public RoleServiceResponse(bool Success,string messege,List<UserRole> roles) : this(Success, messege)
        {
            this.roles = roles;
        }
    };
}
