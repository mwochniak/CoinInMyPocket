using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IUsersQueryService _usersService;

        public UsersController(
            ICommandsBus commandsBus,
            IUsersQueryService usersService)
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

        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _usersService.GetUserAsync(command.Id));
        }
    }
}
