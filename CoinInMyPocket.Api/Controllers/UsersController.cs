using CoinInMyPocket.Infrastructure.Authentication.Attributes;
using CoinInMyPocket.Infrastructure.Busses;
using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoinInMyPocket.Api.Controllers
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

        [Authorized]
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
