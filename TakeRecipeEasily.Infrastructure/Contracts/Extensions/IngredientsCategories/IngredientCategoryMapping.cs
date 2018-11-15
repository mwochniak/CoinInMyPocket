using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;

namespace TakeRecipeEasily.Infrastructure.Contracts.Extensions.IngredientsCategories
{
    public static class IngredientCategoryMapping
    {
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
