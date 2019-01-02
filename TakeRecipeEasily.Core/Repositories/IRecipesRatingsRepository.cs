using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IRecipesRatingsRepository : IRepositorable
    {
        Task CreateAsync(RecipeRating recipeRating);
        Task UpdateAsync(RecipeRating recipeRating);

        Task<IEnumerable<RecipeRating>> GetAsync(Guid recipeId);
    }
}
