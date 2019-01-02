using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.IngredientsCategories
{
    public class CreateIngredientCategoryCommandHandler : ICommandHandler<CreateIngredientCategoryCommand>
    {
        private readonly IHandler _handler;
        private readonly IIngredientsCategoriesService _ingredientsCategoriesService;

        public CreateIngredientCategoryCommandHandler(
            IHandler handler,
            IIngredientsCategoriesService ingredientsCategoriesService)
        {
            _handler = handler;
            _ingredientsCategoriesService = ingredientsCategoriesService;
        }

        public async Task HandleCommandAsync(CreateIngredientCategoryCommand command)
            => await _handler
                .Validate(() => IngredientsCategoriesCommandModelsValidation.CreateIngredientCategoryCommandValidation(command))
                .Handle(async () => await _ingredientsCategoriesService.CreateIngredientCategoryAsync(IngredientCategory.Create(command.Id, command.Name)))
                .ExecuteAsync();
    }
}
