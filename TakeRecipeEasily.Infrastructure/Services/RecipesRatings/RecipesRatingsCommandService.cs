using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.RecipesRatings
{
    public class RecipesRatingsCommandService : IRecipesRatingsCommandService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesRatingsCommandService(DatabaseContext context) => _dbContext = context;

        public async Task CreateRecipeRatingAsync(RecipeRating recipeRating)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _dbContext.RecipesRatings.AddAsync(recipeRating);
                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task DeleteRecipeRatingAsync(Guid id)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipeRating = await GetAsync(id);
                _dbContext.RecipesRatings.Remove(recipeRating);
                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task UpdateRecipeRatingAsync(RecipeRatingUpdateModel recipeRatingUpdateModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipeRating = await GetAsync(recipeRatingUpdateModel.Id);
                recipeRating.Update(recipeRating.Rate, recipeRating.Comment);
                _dbContext.RecipesRatings.Update(recipeRating);
                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        private async Task<RecipeRating> GetAsync(Guid recipeRatingId)
            => await _dbContext.RecipesRatings.SingleOrDefaultAsync(rr => rr.Id == recipeRatingId);
    }
}
