using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("users")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUsersQueryService _usersService;

        public UsersController(
            ICommandsBus commandsBus,
            IUsersQueryService usersService) : base(commandsBus)
        {
            _usersService = usersService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserAsync(string email)
        {
            var user = await _usersService.GetUserAsync(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
            => await RunAsync(command, _ => _usersService.GetUserAsync(command.Id));
    }
}
