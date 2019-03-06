using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesImagesQueryService : IRecipesImagesQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesImagesQueryService(DatabaseContext context) => _dbContext = context;

        public async Task<RecipeImageRetrieveModel> GetDefaultRecipeImageAsync(Guid recipeId)
            => await _dbContext.RecipesImages.Select(ri => new RecipeImageRetrieveModel()
            {
                Content = ri.Content,
                Id = ri.Id,
                IsDefault = ri.IsDefault,
                RecipeId = ri.RecipeId
            })
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<RecipeImageRetrieveModel>> GetRecipeImagesAsync(Guid recipeId)
            => await _dbContext.RecipesImages.Where(ri => ri.RecipeId == recipeId).Select(ri => new RecipeImageRetrieveModel()
            {
                Content = ri.Content,
                Id = ri.Id,
                IsDefault = ri.IsDefault,
                RecipeId = ri.RecipeId
            })
            .ToListAsync();
    }
}
