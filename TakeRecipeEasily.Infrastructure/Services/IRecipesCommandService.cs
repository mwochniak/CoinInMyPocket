using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesCommandService : IServisable
    {
        Task CreateRecipeAsync(Recipe recipe, ICollection<RecipeIngredientCreateModel> recipeIngredients);
        Task UpdateRecipeAsync(RecipeUpdateModel recipeUpdateModel);
        Task DeleteRecipeAsync(Guid recipeId);
    }
}
