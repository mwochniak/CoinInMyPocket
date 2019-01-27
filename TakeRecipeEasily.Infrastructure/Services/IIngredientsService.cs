using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsService : IServisable
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel);

        Task<IngredientRetrieveModel> GetIngredientAsync(Guid ingredientId);
    }
}
