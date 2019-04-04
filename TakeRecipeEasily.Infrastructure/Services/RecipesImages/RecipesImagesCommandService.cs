using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesImages
{
    public class RecipesImagesCommandService : IRecipesImagesCommandService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesImagesCommandService(DatabaseContext context) => _dbContext = context;

        public async Task CreateRecipeImagesAsync(Guid recipeId, IEnumerable<RecipeImageCreateModel> recipeImageCreateModels)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipeImages = recipeImageCreateModels.Select(ri => RecipeImage.Create(id: ri.Id, content: ri.Content, recipeId: recipeId, isDefault: ri.IsDefault, contentType: ri.ContentType));
                await _dbContext.RecipesImages.AddRangeAsync(recipeImages);
                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task DeleteRecipeImagesAsync(IEnumerable<Guid> recipeImagesIds)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipeImages = await GetAsync(recipeImagesIds);
                _dbContext.RecipesImages.RemoveRange(recipeImages);
                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        private async Task<IEnumerable<RecipeImage>> GetAsync(IEnumerable<Guid> ids)
            => await _dbContext.RecipesImages.Where(ri => ids.Contains(ri.Id)).ToListAsync();
    }
}
