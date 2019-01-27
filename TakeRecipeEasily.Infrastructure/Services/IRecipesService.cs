using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesService : IServisable
    {
        Task CreateRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(RecipeUpdateModel recipeUpdateModel);
        Task DeleteRecipeAsync(Guid id);

        Task<RecipeRetrieveModel> GetRecipeAsync(Guid id);
    }
}
