using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Authentication.Models;
using TakeRecipeEasily.Infrastructure.Exceptions;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Infrastructure.Authentication.Middleware
{
    public class JwtAuthorizationMiddleware
    {
        private const string BearerDeclaration = "Bearer ";
        private readonly IJwtService _jwtService;
        private readonly RequestDelegate _next;

        public JwtAuthorizationMiddleware(
            IJwtService jwtService,
            RequestDelegate next)
        {
            _jwtService = jwtService;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var header = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header))

            {
                JwtPayload payload = null;

                try
                {
                    var jwt = header.Substring(BearerDeclaration.Length);
                    payload = _jwtService.DecodeToken(jwt);
                }
                catch (Exception)
                {
                    throw new ServiceException(ErrorType.Unauthorized, AuthenticationErrorCodes.TokenIsNotValid);
                }

                if (payload.Exp < DateTime.Now)
                {
                    throw new ServiceException(ErrorType.Unauthorized, AuthenticationErrorCodes.TokenExpired);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimType.FirstName, payload.FirstName),
                    new Claim(ClaimType.LastName, payload.LastName),
                    new Claim(ClaimType.Email, payload.Email),
                    new Claim(ClaimType.UserId, payload.UserId.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "User");
                context.User = new ClaimsPrincipal(userIdentity);
            }

            await _next(context);
        }
    }
}
