using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Models;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;

namespace TakeRecipeEasily.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        private readonly ICommandsBus _commandsBus;

        private AuthUser GetUser => AuthUser.Parse(HttpContext.User.Identity as ClaimsIdentity);
        protected Guid? UserId => GetUser?.UserId;

        public ApiControllerBase(ICommandsBus commandsBus)
        {
            _commandsBus = commandsBus;
        }

        protected async Task<IActionResult> RunAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            UpdateAuthenticationProperties(command);

            await _commandsBus.SendCommandAsync(command);
            return Ok();
        }

        protected async Task<IActionResult> RunAsync<TCommand, TModel>(TCommand command, Func<TCommand, Task<TModel>> onSuccessAction)
            where TCommand : ICommand
        {
            UpdateAuthenticationProperties(command);

            await _commandsBus.SendCommandAsync(command);

            var result = await onSuccessAction(command);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        private ICommand UpdateAuthenticationProperties(ICommand command)
        {
            command.UserId = UserId ?? Guid.Empty;

            return command;
        }
    }
}
