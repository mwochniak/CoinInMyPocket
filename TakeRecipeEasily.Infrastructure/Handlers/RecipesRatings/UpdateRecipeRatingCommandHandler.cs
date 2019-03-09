using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Services.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesRatings
{
    public class UpdateRecipeRatingCommandHandler : ICommandHandler<UpdateRecipeRatingCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesRatingsCommandService _recipesRatingsCommandService;

        public UpdateRecipeRatingCommandHandler(IHandler handler, IRecipesRatingsCommandService recipesRatingsCommandService)
        {
            _handler = handler;
            _recipesRatingsCommandService = recipesRatingsCommandService;
        }

        public async Task HandleCommandAsync(UpdateRecipeRatingCommand command)
            => await _handler
                .Validate(() => RecipesRatingsCommandModelsValidation.UpdateRecipeRatingCommandValidation(command))
                .Handle(async () => await _recipesRatingsCommandService.UpdateRecipeRatingAsync(RecipeRatingUpdateModel.Create(
                    id: command.Id,
                    rate: command.Rate,
                    comment: command.Comment)))
                .ExecuteAsync();
    }
}
