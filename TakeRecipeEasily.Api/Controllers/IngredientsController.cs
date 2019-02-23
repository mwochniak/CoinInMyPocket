using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Authentication.Attributes;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorized]
    [Route("api/v1/ingredients")]
    public class IngredientsController : Controller
    {
        private readonly ICommandsBus _commandsBus;
        private readonly IIngredientsQueryService _ingredientQueryService;

        public IngredientsController(ICommandsBus commandsBus, IIngredientsQueryService ingredientQueryService)
        {
            _commandsBus = commandsBus;
            _ingredientQueryService = ingredientQueryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientQueryService.GetIngredientAsync(command.Id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredientCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientQueryService.GetIngredientAsync(command.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientAsync([FromRoute] Guid id)
            => Ok(await _ingredientQueryService.GetIngredientAsync(id));
    }
}
