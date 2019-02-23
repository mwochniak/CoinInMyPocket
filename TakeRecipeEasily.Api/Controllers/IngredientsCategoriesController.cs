using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("api/v1/ingredientsCategories")]
    public class IngredientsCategoriesController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IIngredientsCategoriesQueryService _ingredientCategoryQueryService;

        public IngredientsCategoriesController(ICommandsBus commandsBus, IIngredientsCategoriesQueryService ingredientCategoryQueryService)
        {
            _commandsBus = commandsBus;
            _ingredientCategoryQueryService = ingredientCategoryQueryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientCategoryAsync([FromBody] CreateIngredientCategoryCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientCategoryQueryService.GetIngredientCategoryAsync(command.Id));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetIngredientCategoriesAsync()
            => Ok(await _ingredientCategoryQueryService.GetIngredientCategoriesAsync());
    }
}
