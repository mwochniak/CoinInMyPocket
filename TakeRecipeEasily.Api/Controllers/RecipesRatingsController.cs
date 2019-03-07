using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("recipesRatings")]
    public class RecipesRatingsController : ApiControllerBase
    {
        private readonly IRecipesRatingsQueryService _recipesRatingsQueryService;

        public RecipesRatingsController(ICommandsBus commandsBus, IRecipesRatingsQueryService recipesRatingsQueryService) : base(commandsBus)
            => _recipesRatingsQueryService = recipesRatingsQueryService;

        [Authorized]
        [HttpPost("")]
        public async Task<IActionResult> CreateRecipeRatingAsync([FromBody] CreateRecipeRatingCommand command)
            => await RunAsync(command, _ => _recipesRatingsQueryService.GetRecipeRatingAsync(command.Id));

        [Authorized]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeRatingAsync([FromBody] UpdateRecipeRatingCommand command)
            => await RunAsync(command, _ => _recipesRatingsQueryService.GetRecipeRatingAsync(command.Id));

        [Authorized]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeRatingAsync([FromBody] DeleteRecipeRatingCommand command)
            => await RunAsync(command);

        [Authorized]
        [HttpGet("")]
        public async Task<IActionResult> GetRecipeRatingsAsync([FromRoute] Guid recipeId)
            => Ok(await _recipesRatingsQueryService.GetRecipeRatingsAsync(recipeId));
    }
}
