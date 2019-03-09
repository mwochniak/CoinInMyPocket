using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Services.IngredientsCategories;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("ingredientsCategories")]
    public class IngredientsCategoriesController : ApiControllerBase
    {
        private readonly IIngredientsCategoriesQueryService _ingredientCategoryQueryService;

        public IngredientsCategoriesController(ICommandsBus commandsBus, IIngredientsCategoriesQueryService ingredientCategoryQueryService) : base(commandsBus)
        {
            _ingredientCategoryQueryService = ingredientCategoryQueryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientCategoryAsync([FromBody] CreateIngredientCategoryCommand command)
            => await RunAsync(command, _ => _ingredientCategoryQueryService.GetIngredientCategoryAsync(command.Id));
        
        [HttpGet("")]
        public async Task<IActionResult> GetIngredientCategoriesAsync()
            => Ok(await _ingredientCategoryQueryService.GetIngredientCategoriesAsync());
    }
}
