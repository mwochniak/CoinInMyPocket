﻿using System;
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
        private readonly IIngredientsCommandService _ingredientsCommandService;

        public UpdateIngredientCommandHandler(IHandler handler, IIngredientsCommandService ingredientsCommandService)
        {
            _handler = handler;
            _ingredientsCommandService = ingredientsCommandService;
        }

        public async Task HandleCommandAsync(UpdateIngredientCommand command)
            => await _handler
                .Validate(() => IngredientCommandModelsValidation.UpdateIngredientCommandValidation(command))
                .Handle(async () => await _ingredientsCommandService.UpdateIngredientAsync(IngredientUpdateModel.Create(command.Id, command.Name, command.IngredientCategoryId)))
                .ExecuteAsync();
    }
}