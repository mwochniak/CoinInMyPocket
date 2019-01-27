using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Contracts.Extensions.Ingredients
{
    public static class IngredientsMapping
    {
        public async static Task<IEnumerable<IngredientRetrieveModel>> AsModels(this Task<IEnumerable<Ingredient>> that)
            => (await that).AsModels();

        public static IEnumerable<IngredientRetrieveModel> AsModels(this IEnumerable<Ingredient> ingredients)
            => ingredients.Select(AsModel);

        public async static Task<IngredientRetrieveModel> AsModel(this Task<Ingredient> that)
            => (await that).AsModel();

        public static IngredientRetrieveModel AsModel(this Ingredient ingredient)
            => new IngredientRetrieveModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                IngredientCategoryId = ingredient.IngredientCategoryId
            };
    }
}
