using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IRecipesImagesQueryService : IServisable
    {
        Task<RecipeImageRetrieveModel> GetDefaultRecipeImageAsync(Guid recipeId);
        Task<IEnumerable<RecipeImageRetrieveModel>> GetRecipeImagesAsync(Guid recipeId);
    }
}
