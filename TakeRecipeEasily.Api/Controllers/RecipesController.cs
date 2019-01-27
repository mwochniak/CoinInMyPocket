using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("api/v1/recipes")]
    public class RecipesController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IRecipesService _recipesService;

        public RecipesController(ICommandsBus commandsBus, IRecipesService recipesService)
        {
            _commandsBus = commandsBus;
            _recipesService = recipesService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok();
        }
    }
}
