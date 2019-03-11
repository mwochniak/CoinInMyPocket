using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Services.Ingredients;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("ingredients")]
    public class IngredientsController : ApiControllerBase
    {
        private readonly IIngredientsQueryService _ingredientQueryService;

        public IngredientsController(ICommandsBus commandsBus, IIngredientsQueryService ingredientQueryService) : base(commandsBus)
        {
            _ingredientQueryService = ingredientQueryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientCommand command)
            => await RunAsync(command, _ => _ingredientQueryService.GetIngredientAsync(command.Id));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientAsync([FromRoute] Guid id)
            => Ok(await _ingredientQueryService.GetIngredientAsync(id));

        [HttpGet("")]
        public async Task<IActionResult> GetIngredientsAsync()
           => Ok(await _ingredientQueryService.GetIngredientsAsync());

        [HttpGet("{phrase}")]
        public async Task<IActionResult> GetIngredientsAsync([FromRoute] string phrase)
            => Ok(await _ingredientQueryService.GetIngredientsAsync(phrase));
    }
}
