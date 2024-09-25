using HireMeAPI.BLL.interfaces;
using BC = BCrypt.Net.BCrypt;

using Microsoft.AspNetCore.Identity;

namespace HireMeAPI.BLL.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var passwordHash = BC.HashPassword(password);
            return passwordHash;
        }

        public bool verfyPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
