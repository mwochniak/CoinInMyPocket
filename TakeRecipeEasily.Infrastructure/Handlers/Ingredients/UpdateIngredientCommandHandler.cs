using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Ingredients
{
    public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
    {
        private readonly IHandler _handler;
        private readonly IIngredientsService _ingredientsService;

        public UpdateIngredientCommandHandler(IHandler handler, IIngredientsService ingredientsService)
        {
            _handler = handler;
            _ingredientsService = ingredientsService;
        }

        public async Task HandleCommandAsync(UpdateIngredientCommand command)
            => await _handler
                .Validate(() => IngredientCommandModelsValidation.UpdateIngredientCommandValidation(command))
                .Handle(async () => await _ingredientsService.UpdateIngredientAsync(IngredientUpdateModel.Create(command.Id, command.Name, command.IngredientCategoryId)))
                .ExecuteAsync();
    }
}
