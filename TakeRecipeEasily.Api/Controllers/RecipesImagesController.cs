﻿using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeImagesAsync([FromBody] UpdateRecipeImagesCommand command)
            => await RunAsync(command);

        [Authorized]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeImagesAsync([FromBody] DeleteRecipeImagesCommand command)
            => await RunAsync(command);

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
