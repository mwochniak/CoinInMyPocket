using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsCommandService : IServisable
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel);
    }
}
