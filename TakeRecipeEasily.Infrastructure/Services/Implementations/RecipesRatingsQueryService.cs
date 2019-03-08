using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesRatingsQueryService : IRecipesRatingsQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesRatingsQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<RecipeRatingRetrieveModel> GetRecipeRatingAsync(Guid id)
            => await _dbContext.RecipesRatings.Where(rr => rr.Id == id).Select(rr => new RecipeRatingRetrieveModel()
            {
                Id = rr.Id,
                Comment = rr.Comment,
                Rate = rr.Rate,
                RecipeId = rr.RecipeId,
                UserFullName = $"{rr.User.FirstName} {rr.User.LastName}",
                UserId = rr.UserId
            })
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<RecipeRatingRetrieveModel>> GetRecipeRatingsAsync(Guid recipeId)
            => await _dbContext.RecipesRatings.Where(rr => rr.RecipeId == recipeId).Select(rr => new RecipeRatingRetrieveModel()
            {
                Id = rr.Id,
                Comment = rr.Comment,
                Rate = rr.Rate,
                RecipeId = rr.RecipeId,
                UserFullName = $"{rr.User.FirstName} {rr.User.LastName}",
                UserId = rr.UserId
            })
            .ToListAsync();
    }
}
