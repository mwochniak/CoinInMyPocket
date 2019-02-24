using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Models;

namespace TakeRecipeEasily.Infrastructure.Authentication.Attributes
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

                var user = AuthUser.Parse(context.HttpContext.User.Identity as ClaimsIdentity)
                    .ThrowIfNull(ErrorType.Forbidden, AuthenticationErrorCodes.UserIsNotLoggedIn);

                await next();
            }
        }
    }
}
