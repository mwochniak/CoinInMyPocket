using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientService : IServisable
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel);

        Task<Ingredient> GetIngredientAsync(Guid ingredientId);
    }
}
