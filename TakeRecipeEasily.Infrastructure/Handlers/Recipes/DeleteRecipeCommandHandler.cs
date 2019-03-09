using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Services.Recipes;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Recipes
{
    public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesCommandService _recipesCommandService;

        public DeleteRecipeCommandHandler(IHandler handler, IRecipesCommandService recipesCommandService)
        {
            _handler = handler;
            _recipesCommandService = recipesCommandService;
        }

        public async Task HandleCommandAsync(DeleteRecipeCommand command)
            => await _handler
                .Validate(() => RecipesCommandModelsValidation.DeleteRecipeCommandValidation(command))
                .Handle(async () => await _recipesCommandService.DeleteRecipeAsync(command.Id))
                .ExecuteAsync();
    }
}
