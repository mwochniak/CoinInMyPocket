using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Repositories
{
    public class RecipesRatingsRepository : IRecipesRatingsRepository
    {
        private readonly TakeRecipeEasilyContext _context;

        public RecipesRatingsRepository(TakeRecipeEasilyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(RecipeRating recipeRating)
        {
            await _context.RecipesRatings.AddAsync(recipeRating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RecipeRating recipeRating)
        {
            _context.Update(recipeRating);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeRating>> GetAsync(Guid recipeId)
            => await _context.RecipesRatings.Where(rr => rr.RecipeId == recipeId).ToListAsync();
    }
}
