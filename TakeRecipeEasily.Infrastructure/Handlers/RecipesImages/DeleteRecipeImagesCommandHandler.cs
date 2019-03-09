using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using TakeRecipeEasily.Infrastructure.Services.RecipesImages;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.RecipesImages
{
    public class DeleteRecipeImagesCommandHandler : ICommandHandler<DeleteRecipeImagesCommand>
    {
        private readonly IHandler _handler;
        private readonly IRecipesImagesCommandService _recipesImagesCommandService;

        public DeleteRecipeImagesCommandHandler(IHandler handler, IRecipesImagesCommandService recipesImagesCommandService)
        {
            _handler = handler;
            _recipesImagesCommandService = recipesImagesCommandService;
        }

        public async Task HandleCommandAsync(DeleteRecipeImagesCommand command)
            => await _handler
                .Validate(() => RecipesImagesCommandModelsValidation.DeleteRecipeImagesCommandValidation(command))
                .Handle(async () => await _recipesImagesCommandService.DeleteRecipeImagesAsync(command.Ids))
                .ExecuteAsync();
    }
}
