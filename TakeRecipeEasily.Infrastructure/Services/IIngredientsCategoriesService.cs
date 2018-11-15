using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsCategoriesService : IServisable
    {
        Task CreateIngredientCategoryAsync(Guid id, string name);

        Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id);
    }
}
