using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsCategoriesService : IServisable
    {
        Task CreateIngredientCategoryAsync(IngredientCategory ingredientCategory);

        Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id);
        Task<IEnumerable<IngredientCategoryRetrieveModel>> GetIngredientCategoriesAsync();
    }
}
