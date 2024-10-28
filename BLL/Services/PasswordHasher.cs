using HireMeAPI.BLL.interfaces;
using BC = BCrypt.Net.BCrypt;

using Microsoft.AspNetCore.Identity;

namespace HireMeAPI.BLL.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public Task<string> HashPassword(string password)
        {
            return Task<string>.Run(() =>
            {
                var passwordHash = BC.HashPassword(password);
                return passwordHash;


            });
            
        }

        public Task<bool> verfyPassword(string password, string passwordHash)
        {
            return Task.Run<bool>(() =>
            {
                return BC.Verify(password, passwordHash);
            });
        }
    }
}
