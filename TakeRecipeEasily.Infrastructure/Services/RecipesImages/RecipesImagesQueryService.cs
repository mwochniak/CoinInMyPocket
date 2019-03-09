using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesImages
{
    public class RecipesImagesQueryService : IRecipesImagesQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesImagesQueryService(DatabaseContext context) => _dbContext = context;

        public async Task<RecipeImageRetrieveModel> GetRecipeImageAsync(Guid id)
            => await _dbContext.RecipesImages.Where(ri => ri.Id == id).Select(ri => new RecipeImageRetrieveModel()
            {
                Content = ri.Content,
                Id = ri.Id,
                IsDefault = ri.IsDefault,
                RecipeId = ri.RecipeId,
                ContentType = ri.ContentType
            })
            .SingleOrDefaultAsync();

        public async Task<RecipeImageRetrieveModel> GetDefaultRecipeImageAsync(Guid recipeId)
            => await _dbContext.RecipesImages.Where(ri => ri.RecipeId == recipeId && ri.IsDefault).Select(ri => new RecipeImageRetrieveModel()
            {
                Content = ri.Content,
                Id = ri.Id,
                IsDefault = ri.IsDefault,
                RecipeId = ri.RecipeId,
                ContentType = ri.ContentType
            })
            .SingleOrDefaultAsync();
    }
}
