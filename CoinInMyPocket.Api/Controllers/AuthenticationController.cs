﻿using CoinInMyPocket.Infrastructure.Authentication.Models;
using CoinInMyPocket.Infrastructure.Busses;
using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Contracts.QueryModels;
using CoinInMyPocket.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinInMyPocket.Api.Controllers
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
