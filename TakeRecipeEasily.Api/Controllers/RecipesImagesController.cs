using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using TakeRecipeEasily.Infrastructure.Services.RecipesImages;

namespace TakeRecipeEasily.Api.Controllers
{
    [Route("recipesImages")]
    public class RecipesImagesController : ApiControllerBase
    {
        private readonly IRecipesImagesQueryService _recipesImagesQueryService;

        public RecipesImagesController(ICommandsBus commandsBus, IRecipesImagesQueryService recipesImagesQueryService) : base(commandsBus)
            => _recipesImagesQueryService = recipesImagesQueryService;

        [Authorized]
        [HttpPost("")]
        public async Task<IActionResult> CreateRecipeImagesAsync([FromBody] CreateRecipeImagesCommand command)
            => await RunAsync(command);

        [Authorized]
        [HttpDelete("")]
        public async Task<IActionResult> DeleteRecipeImagesAsync([FromQuery] IEnumerable<Guid> ids)
            => await RunAsync(new DeleteRecipeImagesCommand(ids));

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipeImageDefaultAsync([FromRoute] Guid recipeId)
        {
            var recipeImage = await _recipesImagesQueryService.GetDefaultRecipeImageAsync(recipeId);
            return File(recipeImage.Content, recipeImage.ContentType);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeImageAsync([FromRoute] Guid id)
        {
            var recipeImage = await _recipesImagesQueryService.GetRecipeImageAsync(id);
            return File(recipeImage.Content, recipeImage.ContentType);
        }
    }
}
