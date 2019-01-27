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
        private readonly IIngredientsCategoriesService _ingredientCategoryService;

        public IngredientsCategoriesController(ICommandsBus commandsBus, IIngredientsCategoriesService ingredientCategoryService)
        {
            _commandsBus = commandsBus;
            _ingredientCategoryService = ingredientCategoryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientCategoryAsync([FromBody] CreateIngredientCategoryCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientCategoryService.GetIngredientCategoryAsync(command.Id));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetIngredientCategoriesAsync()
            => Ok(await _ingredientCategoryService.GetIngredientCategoriesAsync());
    }
}
