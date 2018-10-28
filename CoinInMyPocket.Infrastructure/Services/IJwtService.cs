using CoinInMyPocket.Infrastructure.Authentication.Models;

namespace CoinInMyPocket.Infrastructure.Services
{
    public interface IJwtService
    {
        string CreateToken(JwtUserModel user);
        JwtPayload DecodeToken(string token);
    }
}
