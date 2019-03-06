using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesRatingsQueryService : IServisable
    {
        Task<IEnumerable<RecipeRatingRetrieveModel>> GetRecipeRatingsAsync(Guid recipeId);
    }
}
