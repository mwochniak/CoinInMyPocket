using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Services.Ingredients;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Ingredients
{
    public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
    {
        private readonly IHandler _handler;
        private readonly IIngredientsCommandService _ingredientsCommandService;

        public CreateIngredientCommandHandler(IHandler handler, IIngredientsCommandService ingredientsCommandService)
        {
            _handler = handler;
            _ingredientsCommandService = ingredientsCommandService;
        }

        public async Task HandleCommandAsync(CreateIngredientCommand command)
            => await _handler
                .Validate(() => IngredientCommandModelsValidation.CreateIngredientCommandValidation(command))
                .Handle(async () => await _ingredientsCommandService.CreateIngredientAsync(Ingredient.Create(command.Id, command.Name, command.IngredientCategoryId)))
                .ExecuteAsync();
    }
}
