using System.Threading.Tasks;
using TakeRecipeEasily.Core.UpdateModels.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Services;
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
                .Handle(async () => await _recipesCommandService.UpdateRecipeAsync(RecipeUpdateModel.Create(command.Id, command.Name, command.Description, command.IngredientsIds)))
                .ExecuteAsync();
    }
}
