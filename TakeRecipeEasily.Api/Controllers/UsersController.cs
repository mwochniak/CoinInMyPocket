using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IUsersService _usersService;

        public UsersController(
            ICommandsBus commandsBus,
            IUsersService usersService)
        {
            _commandsBus = commandsBus;
            _usersService = usersService;
        }

        
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserAsync(string email)
        {
            var user = await _usersService.GetUserAsync(email);
            return Ok(user);
        }

        [Authorized]
        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _usersService.GetUserAsync(command.Id));
        }
    }
}
