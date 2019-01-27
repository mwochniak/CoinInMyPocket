using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Recipes;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IRecipesRepository : IRepositorable
    {
        Task CreateAsync(Recipe recipe);
        Task UpdateAsync(RecipeUpdateModel recipeUpdateModel);
        Task DeleteAsync(Guid id);

        Task<Recipe> GetAsync(Guid recipeId);
    }
}
