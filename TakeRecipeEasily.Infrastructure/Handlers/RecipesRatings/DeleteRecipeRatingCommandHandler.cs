using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Services.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesRatings
{
    public class DeleteRecipeRatingCommandHandler : ICommandHandler<DeleteRecipeRatingCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesRatingsCommandService _recipesRatingsCommandService;

        public DeleteRecipeRatingCommandHandler(IHandler handler, IRecipesRatingsCommandService recipesRatingsCommandService)
        {
            _handler = handler;
            _recipesRatingsCommandService = recipesRatingsCommandService;
        }

        public async Task HandleCommandAsync(DeleteRecipeRatingCommand command)
            => await _handler
                .Validate(() => RecipesRatingsCommandModelsValidation.DeleteRecipeRatingCommandValidation(command))
                .Handle(async () => await _recipesRatingsCommandService.DeleteRecipeRatingAsync(id: command.Id))
                .ExecuteAsync();
    }
}
