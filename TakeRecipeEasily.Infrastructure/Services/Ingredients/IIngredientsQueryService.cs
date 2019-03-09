using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services.Ingredients
{
    public interface IIngredientsQueryService : IServisable
    {
        Task<IngredientRetrieveModel> GetIngredientAsync(Guid ingredientId);

        Task<IEnumerable<IngredientRetrieveModel>> GetIngredientsAsync();
        Task<IEnumerable<IngredientRetrieveModel>> GetIngredientsAsync(string phrase);
    }
}
