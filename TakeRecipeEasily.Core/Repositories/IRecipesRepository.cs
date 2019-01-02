using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IRecipesRepository : IRepositorable
    {
        Task CreateAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Recipe recipe);

        Task<Recipe> GetAsync(Guid recipeId);
    }
}
