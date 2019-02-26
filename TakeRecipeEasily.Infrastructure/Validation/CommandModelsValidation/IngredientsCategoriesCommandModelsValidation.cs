using TakeRecipeEasily.Core.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation
{
    internal static class IngredientsCategoriesCommandModelsValidation
    {
        internal static void CreateIngredientCategoryCommandValidation(CreateIngredientCategoryCommand command)
        {
            var result = ValitRules<CreateIngredientCategoryCommand>
                .Create()
                .Ensure(c => c.Name, _ => _
                    .Required()
                    .MinLength(4)
                    .MaxLength(100))
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }
    }
}
