using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesRatingsQueryService : IRecipesRatingsQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesRatingsQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<RecipeRatingRetrieveModel>> GetRecipeRatingsAsync(Guid recipeId)
            => await _dbContext.RecipesRatings.Where(rr => rr.RecipeId == recipeId).Select(rr => new RecipeRatingRetrieveModel()
            {
                Id = rr.Id,
                Comment = rr.Comment,
                Rate = rr.Rate,
                UserFullName = rr.User.FirstName + " " + rr.User.LastName,
                UserId = rr.UserId
            })
            .ToListAsync();
    }
}
