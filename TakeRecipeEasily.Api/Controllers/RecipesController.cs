using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IRecipesQueryService _recipesQueryService;

        public RecipesController(ICommandsBus commandsBus, IRecipesQueryService recipesQueryService)
        {
            _commandsBus = commandsBus;
            _recipesQueryService = recipesQueryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _recipesQueryService.GetRecipeAsync(command.Id));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateRecipeAsync([FromBody] UpdateRecipeCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _recipesQueryService.GetRecipeAsync(command.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeAsync([FromBody] DeleteRecipeCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeAsync([FromRoute] Guid id)
            => Ok(await _recipesQueryService.GetRecipeAsync(id));
    }
}
