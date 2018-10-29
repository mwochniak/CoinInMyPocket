using TakeRecipeEasily.Infrastructure.Authentication.Models;
using TakeRecipeEasily.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class HmacJwtService : IJwtService
    {
        private readonly AuthSettings _authSettings;

        public HmacJwtService(AuthSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public string CreateToken(JwtUserModel user)
        {
            var payload = CreatePayload(user);
            return Jose.JWT.Encode(payload, _authSettings.SecretKey, Jose.JwsAlgorithm.HS256);
        }

        public JwtPayload DecodeToken(string token)
            => Jose.JWT.Decode<JwtPayload>(token, _authSettings.SecretKey, Jose.JwsAlgorithm.HS256);

        private JwtPayload CreatePayload(JwtUserModel user)
            => new JwtPayload
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Exp = DateTime.UtcNow.Add(_authSettings.TokenExpiry)
            };
    }
}
