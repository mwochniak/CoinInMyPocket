using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;

namespace TakeRecipeEasily.Infrastructure.Contracts.Extensions.IngredientsCategories
{
    public static class IngredientCategoriesMapping
    {
        public async static Task<IEnumerable<IngredientCategoryRetrieveModel>> AsModels(this Task<IEnumerable<IngredientCategory>> that)
            => (await that).AsModels();

        public static IEnumerable<IngredientCategoryRetrieveModel> AsModels(this IEnumerable<IngredientCategory> ingredientCategories)
            => ingredientCategories.Select(AsModel);

        public async static Task<IngredientCategoryRetrieveModel> AsModel(this Task<IngredientCategory> that)
            => (await that).AsModel();

        public static IngredientCategoryRetrieveModel AsModel(this IngredientCategory ingredientCategory)
            => new IngredientCategoryRetrieveModel
            {
                Id = ingredientCategory.Id,
                Name = ingredientCategory.Name
            };
    }
}
