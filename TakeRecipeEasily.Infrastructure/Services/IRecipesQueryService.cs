using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesQueryService : IServisable
    {
        Task<RecipeRetrieveModel> GetRecipeAsync(Guid recipeId);

        Task<IEnumerable<RecipeRetrieveModel>> GetRecipesAsync();
    }
}
