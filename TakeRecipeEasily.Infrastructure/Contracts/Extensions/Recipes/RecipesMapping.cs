using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Extensions.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;

namespace TakeRecipeEasily.Infrastructure.Contracts.Extensions.Recipes
{
    public static class RecipesMapping
    {
        public async static Task<IEnumerable<RecipeRetrieveModel>> AsModels(this Task<IEnumerable<Recipe>> that, IEnumerable<Ingredient> ingredients)
            => (await that).AsModels(ingredients);

        public static IEnumerable<RecipeRetrieveModel> AsModels(this IEnumerable<Recipe> recipes, IEnumerable<Ingredient> ingredients)
            => recipes.Select(r => r.AsModel(ingredients));

        public async static Task<RecipeRetrieveModel> AsModel(this Task<Recipe> that, IEnumerable<Ingredient> ingredients)
            => (await that).AsModel(ingredients);

        public static RecipeRetrieveModel AsModel(this Recipe recipe, IEnumerable<Ingredient> ingredients)
            => new RecipeRetrieveModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                RecipeRatingId = recipe.RecipeRatingId,
                UserId = recipe.UserId,
                Ingredients = ingredients.AsModels()
            };
    }
}
