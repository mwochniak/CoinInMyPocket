using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesRatings
{
    public interface IRecipesRatingsQueryService : IServisable
    {
        Task<RecipeRatingRetrieveModel> GetRecipeRatingAsync(Guid id);

        Task<IEnumerable<RecipeRatingRetrieveModel>> GetRecipeRatingsAsync(Guid recipeId);
    }
}
