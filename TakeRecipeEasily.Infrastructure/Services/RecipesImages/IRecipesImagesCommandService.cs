using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesImages
{
    public interface IRecipesImagesCommandService : IServisable
    {
        Task CreateRecipeImagesAsync(Guid recipeId, IEnumerable<RecipeImageCreateModel> recipeImageCreateModels);
        Task UpdateRecipeImagesAsync(Guid recipeId, IEnumerable<RecipeImageUpdateModel> recipeImageUpdateModels);
        Task DeleteRecipeImagesAsync(IEnumerable<Guid> recipeImagesIds);
    }
}
