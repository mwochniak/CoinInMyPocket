using CoinInMyPocket.Core.Domain;
using CoinInMyPocket.Infrastructure.Exceptions;
using CoinInMyPocket.Infrastructure.Exceptions.ErrorMessages;
using ePrzedszkole.Common.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Authentication.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizedAttribute : TypeFilterAttribute
    {
        public AuthorizedAttribute() : base(typeof(AuthorizedAttributeImpl))
        {
            Arguments = new object[] { };
        }

        protected class AuthorizedAttributeImpl : IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var allowAnnonymous = context.Filters.Any(f => f.GetType() == typeof(AllowAnonymousFilter));
                if (allowAnnonymous)
                {
                    await next();
                    return;
                }

                var user = AuthUser.Parse(context.HttpContext.User.Identity as ClaimsIdentity);

                if (user == null)
                {
                    throw new ServiceException(ErrorType.Forbidden, AuthenticationErrorCodes.UserIsNotLoggedIn);
                }

                await next();
            }
        }
    }
}
