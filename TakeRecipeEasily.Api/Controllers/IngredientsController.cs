using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IIngredientsService _ingredientService;

        public IngredientsController(ICommandsBus commandsBus, IIngredientsService ingredientService)
        {
            _commandsBus = commandsBus;
            _ingredientService = ingredientService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientService.GetIngredientAsync(command.Id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredientCommand command)
        {
            await _commandsBus.SendCommandAsync(command);
            return Ok(await _ingredientService.GetIngredientAsync(command.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientAsync([FromRoute] Guid id)
            => Ok(await _ingredientService.GetIngredientAsync(id));
    }
}
