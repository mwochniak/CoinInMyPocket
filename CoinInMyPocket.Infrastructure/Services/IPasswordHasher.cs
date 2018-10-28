namespace CoinInMyPocket.Infrastructure.Services
{
    public interface IPasswordHasher : IServisable
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
