namespace HireMeAPI.BLL.interfaces
{
    public interface IPasswordHasher
    {

        public string HashPassword(string password);

        public bool verfyPassword(string password, string hashPassword);
    }
}
