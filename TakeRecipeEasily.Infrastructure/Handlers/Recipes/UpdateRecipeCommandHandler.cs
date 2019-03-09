using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Services.Recipes;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Recipes
{
    public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesCommandService _recipesCommandService;

        public UpdateRecipeCommandHandler(IHandler handler, IRecipesCommandService recipesCommandService)
        {
            _handler = handler;
            _recipesCommandService = recipesCommandService;
        }

        public async Task HandleCommandAsync(UpdateRecipeCommand command)
            => await _handler
                .Validate(() => RecipesCommandModelsValidation.UpdateRecipeCommandValidation(command))
                .Handle(async () => await _recipesCommandService.UpdateRecipeAsync(RecipeUpdateModel.Create(
                    id: command.Id,
                    difficultyLevel: command.DifficultyLevel,
                    preparationTime: command.PreparationTime,
                    totalKcal: command.TotalKcal,
                    description: command.Description,
                    name: command.Name,
                    summary: command.Summary,
                    recipeIngredients: command.RecipeIngredients)))
                .ExecuteAsync();
    }
}
