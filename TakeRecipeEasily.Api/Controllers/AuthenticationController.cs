using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Models;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Users;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUsersQueryService _usersService;

        public AuthenticationController(
            ICommandsBus commandsBus,
            IJwtService jwtService,
            IUsersQueryService usersService) : base(commandsBus)
        {
            _jwtService = jwtService;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
            => await RunAsync(command, async _ => CreateJwtToken(await _usersService.GetUserAsync(command.Email)));

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
