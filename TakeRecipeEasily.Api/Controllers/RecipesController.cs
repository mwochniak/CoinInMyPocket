using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Filters;
using TakeRecipeEasily.Infrastructure.Services.Recipes;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("recipes")]
    public class RecipesController : ApiControllerBase
    {
        private readonly IRecipesQueryService _recipesQueryService;

        public RecipesController(ICommandsBus commandsBus, IRecipesQueryService recipesQueryService) : base(commandsBus)
            => _recipesQueryService = recipesQueryService;

        [Authorized]
        [HttpPost("")]
        public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeCommand command)
            => await RunAsync(command, _ => _recipesQueryService.GetRecipeAsync(command.Id));

        [Authorized]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeAsync([FromBody] UpdateRecipeCommand command)
            => await RunAsync(command, _ => _recipesQueryService.GetRecipeAsync(command.Id));

        [Authorized]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeAsync([FromBody] DeleteRecipeCommand command)
            => await RunAsync(command);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeAsync([FromRoute] Guid id)
            => Ok(await _recipesQueryService.GetRecipeAsync(id));

        [HttpGet("")]
        public async Task<IActionResult> GetRecipesAsync()
            => Ok(await _recipesQueryService.GetRecipesAsync());

        [HttpGet("searcher")]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] RecipeFilters filters)
            => Ok(await _recipesQueryService.GetRecipesAsync(filters));

        [Authorized]
        [HttpGet("users/current")]
        public async Task<IActionResult> GetUserRecipesAsync()
        {
            if (UserId.HasValue)
                return Ok(await _recipesQueryService.GetUserRecipesAsync(UserId.Value));
            else
                return BadRequest();
        }
    }
}
