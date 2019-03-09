using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesImages
{
    public interface IRecipesImagesQueryService : IServisable
    {
        Task<RecipeImageRetrieveModel> GetRecipeImageAsync(Guid id);
        Task<RecipeImageRetrieveModel> GetDefaultRecipeImageAsync(Guid recipeId);
    }
}
