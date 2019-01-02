using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Repositories
{
    public class IngredientsCategoriesRepository : IIngredientsCategoriesRepository
    {
        private readonly TakeRecipeEasilyContext _context;

        public IngredientsCategoriesRepository(TakeRecipeEasilyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(IngredientCategory ingredientCategory)
        {
            await _context.AddAsync(ingredientCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsNameInUse(string name)
            => await _context.IngredientsCategories.AnyAsync(i => i.Name == name);

        public async Task<IngredientCategory> GetAsync(Guid id)
            => await _context.IngredientsCategories.SingleOrDefaultAsync(i => i.Id == id);
    }
}
