namespace HireMeAPI.BLL.interfaces
{
    public interface IPasswordHasher
    {

        public Task<string> HashPassword(string password);

        public Task<bool> verfyPassword(string password, string hashPassword);
    }
}
