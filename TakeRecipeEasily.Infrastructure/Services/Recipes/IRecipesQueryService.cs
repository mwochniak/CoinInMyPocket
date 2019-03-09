using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;
using TakeRecipeEasily.Infrastructure.Filters;

namespace TakeRecipeEasily.Infrastructure.Services.Recipes
{
    public interface IRecipesQueryService : IServisable
    {
        Task<RecipeRetrieveModel> GetRecipeAsync(Guid recipeId);

        Task<IEnumerable<RecipeRetrieveModel>> GetRecipesAsync();
        Task<IEnumerable<RecipeRetrieveModel>> GetUserRecipesAsync(Guid userId);
        Task<IEnumerable<RecipeRetrieveModel>> GetRecipesAsync(RecipeFilters recipeFilters);
    }
}
