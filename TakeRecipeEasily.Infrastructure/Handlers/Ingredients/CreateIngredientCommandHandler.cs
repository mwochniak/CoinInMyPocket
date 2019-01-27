using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Ingredients
{
    public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
    {
        private readonly IHandler _handler;
        private readonly IIngredientsService _ingredientsService;

        public CreateIngredientCommandHandler(IHandler handler, IIngredientsService ingredientsService)
        {
            _handler = handler;
            _ingredientsService = ingredientsService;
        }

        public async Task HandleCommandAsync(CreateIngredientCommand command)
            => await _handler
                .Validate(() => IngredientCommandModelsValidation.CreateIngredientCommandValidation(command))
                .Handle(async () => await _ingredientsService.CreateIngredientAsync(Ingredient.Create(command.Id, command.Name, command.IngredientCategoryId)))
                .ExecuteAsync();
    }
}
