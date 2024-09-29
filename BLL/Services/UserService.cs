using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using HireMeAPI.utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using static Azure.Core.HttpHeader;


namespace HireMeAPI.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<UserService> _logger;
        private readonly IRoleService _roleService;
        public UserService(AppDbContext context,
                           IPasswordHasher passwordHasher,
                           ITokenService tokenService,
                           IHttpContextAccessor accessor,
                           ILogger<UserService> logger,
                           IRoleService roleService )
        {

            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _accessor = accessor;
            _logger = logger;
            _roleService = roleService;
        }
        public async Task<Guid> CreateUserAccountAsync(SignUpDTO userData)
        {
            Guid UserId = Guid.NewGuid();
            if (await _context.Users.AnyAsync(u => u.Email == userData.Email)) {
                return Guid.Empty;
            }

            string _passwordHash = _passwordHasher.HashPassword(userData.Password??" ");
            User user = new User()
            {
                Id = UserId,
                Email = userData.Email,
                UserName = userData.UserName,
                passwordHash = _passwordHash
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await _roleService.AddUserToRole(UserId, RolesConsts.USER);
            return UserId;
        }

        

        public async Task<LogInResponse> LogInAsync(LogInDTO userData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u .Email == userData.Email);

            if (user == null) {
                return new LogInResponse(false, "No account with that email exists", string.Empty);
            }

            if (!_passwordHasher.verfyPassword(userData.password?? string.Empty, user.passwordHash ?? string.Empty)) {

                return new LogInResponse(false, "wrong password", string.Empty);
            }

            var roleServiceRes = await _roleService.GetUserRoles(user.Id);

            var token =  _tokenService.CreateToken(user,roleServiceRes.roles);

            return new LogInResponse(true, "Loggend in", token);

        }


        public UserDataResponse GetUserData(ClaimsPrincipal User) {

            string id = _accessor.HttpContext!.User.FindFirst(ClaimTypes.Sid)?.Value??Guid.Empty.ToString();
            _logger.LogInformation(id);
            return new UserDataResponse("", id, "");
                
        }

        public Guid GetUserId()
        {
            return Guid.Parse(_accessor.HttpContext!.User.FindFirst(ClaimTypes.Sid)?.Value ?? Guid.Empty.ToString());
        }
    }

    public record LogInResponse (bool LoggedIn ,string Messege,string Accesstoken);
    public record UserDataResponse(string status, string UserId, string email);

}
