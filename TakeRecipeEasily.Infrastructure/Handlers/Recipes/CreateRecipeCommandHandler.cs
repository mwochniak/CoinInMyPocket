using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Events.Recipes;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Recipes
{
    public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
    {
        private readonly IEventsBus _eventsBus;
        private readonly IHandler _handler;
        private readonly IRecipesService _recipesService;

        public CreateRecipeCommandHandler(IEventsBus eventsBus, IHandler handler, IRecipesService recipesService)
        {
            _eventsBus = eventsBus;
            _handler = handler;
            _recipesService = recipesService;
        }

        public async Task HandleCommandAsync(CreateRecipeCommand command)
            => await _handler
                .Validate(() => RecipesCommandModelsValidation.CreateRecipeCommandValidation(command))
                .Handle(async () => await _recipesService.CreateRecipeAsync(Recipe.Create(command.Id, command.Name, command.Description, command.RecipeRatingId, command.UserId)))
                .Handle(async () => await _eventsBus.PublishEventAsync(RecipeCreatedEvent.Create(command.Id, command.IngredientsIds, command.RecipeRatingId)))
                .ExecuteAsync();
    }
}
