using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesRatingsCommandService : IServisable
    {
        Task CreateRecipeRatingAsync(RecipeRating recipeRating);
        Task DeleteRecipeRatingAsync(Guid id);
        Task UpdateRecipeRatingAsync(RecipeRatingUpdateModel recipeRatingUpdateModel);
    }
}
