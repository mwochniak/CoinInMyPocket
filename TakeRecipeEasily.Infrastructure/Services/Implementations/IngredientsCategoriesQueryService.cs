using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsCategoriesQueryService : IIngredientsCategoriesQueryService
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsCategoriesQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id)
            => await _dbContext.IngredientsCategories.Select(ic => new IngredientCategoryRetrieveModel()
            {
                Id = ic.Id,
                Name = ic.Name
            })
            .SingleAsync(ic => ic.Id == id);

        public async Task<IEnumerable<IngredientCategoryRetrieveModel>> GetIngredientCategoriesAsync()
            => await _dbContext.IngredientsCategories.Select(ic => new IngredientCategoryRetrieveModel()
            {
                Id = ic.Id,
                Name = ic.Name
            })
            .ToListAsync();

        
    }
}
