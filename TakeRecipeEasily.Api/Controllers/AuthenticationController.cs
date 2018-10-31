using TakeRecipeEasily.Infrastructure.Authentication.Models;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels;
using TakeRecipeEasily.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("api/v1/auth")]
    public class AuthenticationController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IJwtService _jwtService;
        private readonly IUsersService _usersService;

        public AuthenticationController(
            ICommandsBus commandsBus,
            IJwtService jwtService,
            IUsersService usersService)
        {
            _commandsBus = commandsBus;
            _jwtService = jwtService;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            var user = await _usersService.GetUserAsync(command.Email);
            var token = CreateJwtToken(user);
            return Ok(token);
        }

        private string CreateJwtToken(UserRetrieveModel user)
            => _jwtService.CreateToken(new JwtUserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
    }
}
