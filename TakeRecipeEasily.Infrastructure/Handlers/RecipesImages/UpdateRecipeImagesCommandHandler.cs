using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using TakeRecipeEasily.Infrastructure.Services.RecipesImages;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesImages
{
    public class UpdateRecipeImagesCommandHandler : ICommandHandler<UpdateRecipeImagesCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesImagesCommandService _recipesImagesCommandService;

        public UpdateRecipeImagesCommandHandler(IHandler handler, IRecipesImagesCommandService recipesImagesCommandService)
        {
            _handler = handler;
            _recipesImagesCommandService = recipesImagesCommandService;
        }

        public async Task HandleCommandAsync(UpdateRecipeImagesCommand command)
            => await _handler
                .Validate(() => RecipesImagesCommandModelsValidation.UpdateRecipeImagesCommandValidation(command))
                .Handle(async () => await _recipesImagesCommandService.UpdateRecipeImagesAsync(command.RecipeId, command.RecipeImages))
                .ExecuteAsync();
    }
}
