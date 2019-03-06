using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsQueryService : IIngredientsQueryService
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<IngredientRetrieveModel> GetIngredientAsync(Guid ingredientId)
            => await _dbContext.Ingredients.Select(i => new IngredientRetrieveModel()
            {
                Id = i.Id,
                IngredientCategoryId = i.IngredientCategoryId,
                Name = i.Name,
                IngredientCategoryName = i.IngredientCategory.Name
            })
            .SingleOrDefaultAsync(i => i.Id == ingredientId);

        public async Task<IEnumerable<IngredientRetrieveModel>> GetIngredientsAsync()
            => await _dbContext.Ingredients.Select(i => new IngredientRetrieveModel()
            {
                Id = i.Id,
                IngredientCategoryId = i.IngredientCategoryId,
                Name = i.Name,
                IngredientCategoryName = i.IngredientCategory.Name
            })
            .ToListAsync();
    }
}
