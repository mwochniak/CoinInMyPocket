using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Services.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.IngredientsCategories
{
    public class CreateIngredientCategoryCommandHandler : ICommandHandler<CreateIngredientCategoryCommand>
    {
        private readonly IHandler _handler;
        private readonly IIngredientsCategoriesCommandService _ingredientsCategoriesCommandService;

        public CreateIngredientCategoryCommandHandler(
            IHandler handler,
            IIngredientsCategoriesCommandService ingredientsCategoriesCommandService)
        {
            _handler = handler;
            _ingredientsCategoriesCommandService = ingredientsCategoriesCommandService;
        }

        public async Task HandleCommandAsync(CreateIngredientCategoryCommand command)
            => await _handler
                .Validate(() => IngredientsCategoriesCommandModelsValidation.CreateIngredientCategoryCommandValidation(command))
                .Handle(async () => await _ingredientsCategoriesCommandService.CreateIngredientCategoryAsync(IngredientCategory.Create(command.Id, command.Name)))
                .ExecuteAsync();
    }
}
