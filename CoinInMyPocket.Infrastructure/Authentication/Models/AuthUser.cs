using CoinInMyPocket.Infrastructure.Authentication.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace ePrzedszkole.Common.Auth.Models
{
    public class AuthUser
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static AuthUser Parse(ClaimsIdentity userIdentity)
        {
            if (userIdentity == null)
            {
                return null;
            }

            Guid.TryParse(GetProp(userIdentity, ClaimType.UserId), out var userId);

            if (userId == Guid.Empty)
            {
                return null;
            }

            return new AuthUser
            {
                UserId = userId,
                Email = GetProp(userIdentity, ClaimType.Email),
                FirstName = GetProp(userIdentity, ClaimType.FirstName),
                LastName = GetProp(userIdentity, ClaimType.LastName),
            };
        }

        private static string GetProp(ClaimsIdentity userIdentity, string propType)
            => userIdentity.Claims
                .Where(c => c.Type == propType)
                .Select(c => c.Value)
                .FirstOrDefault();
    }
}