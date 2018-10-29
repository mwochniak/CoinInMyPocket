using TakeRecipeEasily.Infrastructure.Authentication.Models;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IJwtService
    {
        string CreateToken(JwtUserModel user);
        JwtPayload DecodeToken(string token);
    }
}
