using CryptoHelper;

namespace CoinInMyPocket.Infrastructure.Services.Implementations
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
            => Crypto.HashPassword(password);

        public bool VerifyPassword(string hashedPassword, string password)
            => Crypto.VerifyHashedPassword(hashedPassword, password);
    }
}
