using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesRatings
{
    public class CreateRecipeRatingCommandHandler : ICommandHandler<CreateRecipeRatingCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesRatingsCommandService _recipesRatingsCommandService;

        public CreateRecipeRatingCommandHandler(IHandler handler, IRecipesRatingsCommandService recipesRatingsCommandService)
        {
            _handler = handler;
            _recipesRatingsCommandService = recipesRatingsCommandService;
        }

        public async Task HandleCommandAsync(CreateRecipeRatingCommand command)
            => await _handler
                .Validate(() => RecipesRatingsCommandModelsValidation.CreateRecipeRatingCommandValidation(command))
                .Handle(async () => await _recipesRatingsCommandService.CreateRecipeRatingAsync(RecipeRating.Create(
                    id: command.Id,
                    rate: command.Rate,
                    recipeId: command.RecipeId,
                    userId: command.UserId,
                    comment: command.Comment)))
                .ExecuteAsync();
    }
}
