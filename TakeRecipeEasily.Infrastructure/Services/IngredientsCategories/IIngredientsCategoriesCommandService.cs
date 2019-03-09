using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Services.IngredientsCategories
{
    public interface IIngredientsCategoriesCommandService : IServisable
    {
        Task CreateIngredientCategoryAsync(IngredientCategory ingredientCategory);
    }
}
