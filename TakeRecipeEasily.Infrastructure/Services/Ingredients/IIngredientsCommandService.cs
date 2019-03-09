using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services.Ingredients
{
    public interface IIngredientsCommandService : IServisable
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel);
    }
}
