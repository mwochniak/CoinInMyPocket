using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Recipes;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesCommandService : IServisable
    {
        Task CreateRecipeAsync(Recipe recipe, IEnumerable<Guid> ingredientsIds);
        Task UpdateRecipeAsync(RecipeUpdateModel recipeUpdateModel);
        Task DeleteRecipeAsync(Guid recipeId);
    }
}
