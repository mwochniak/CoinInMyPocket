using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using TakeRecipeEasily.Infrastructure.Services.RecipesImages;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesImages
{
    public class CreateRecipeImagesCommandHandler : ICommandHandler<CreateRecipeImagesCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesImagesCommandService _recipesImagesCommandService;

        public CreateRecipeImagesCommandHandler(IHandler handler, IRecipesImagesCommandService recipesImagesCommandService)
        {
            _handler = handler;
            _recipesImagesCommandService = recipesImagesCommandService;
        }

        public async Task HandleCommandAsync(CreateRecipeImagesCommand command)
            => await _handler
                .Validate(() => RecipesImagesCommandModelsValidation.CreateRecipeImagesCommandValidation(command))
                .Handle(async () => await _recipesImagesCommandService.CreateRecipeImagesAsync(command.RecipeId, command.RecipeImages))
                .ExecuteAsync();
    }
}
