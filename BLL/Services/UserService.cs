using HireMeAPI.BLL.interfaces;
using HireMeAPI.DAL;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
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
        public UserService(AppDbContext context,IPasswordHasher passwordHasher, ITokenService tokenService, IHttpContextAccessor accessor,ILogger<UserService> logger)
        {

            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _accessor = accessor;
            _logger = logger;
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

            var token =  _tokenService.CreateToken(user);

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
