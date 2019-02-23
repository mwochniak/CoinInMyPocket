using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsCategoriesCommandService : IServisable
    {
        Task CreateIngredientCategoryAsync(IngredientCategory ingredientCategory);
    }
}
