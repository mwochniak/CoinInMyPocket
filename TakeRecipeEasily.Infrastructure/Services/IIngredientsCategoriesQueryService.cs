using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsCategoriesQueryService : IServisable
    {
        Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id);
        Task<IEnumerable<IngredientCategoryRetrieveModel>> GetIngredientCategoriesAsync();
    }
}
