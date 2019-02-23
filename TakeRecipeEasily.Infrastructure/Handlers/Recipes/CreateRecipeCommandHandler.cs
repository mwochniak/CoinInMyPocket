using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Recipes
{
    public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesCommandService _recipesService;

        public CreateRecipeCommandHandler(IHandler handler, IRecipesCommandService recipesService)
        {
            _handler = handler;
            _recipesService = recipesService;
        }

        public async Task HandleCommandAsync(CreateRecipeCommand command)
            => await _handler
                .Validate(() => RecipesCommandModelsValidation.CreateRecipeCommandValidation(command))
                .Handle(async () => await _recipesService.CreateRecipeAsync(Recipe.Create(command.Id, command.Name, command.Description, command.RecipeRatingId, command.UserId), command.IngredientsIds))
                .ExecuteAsync();
    }
}
