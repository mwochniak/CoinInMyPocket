using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsCommandService : IIngredientsCommandService
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsCommandService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _dbContext.Ingredients.AddAsync(ingredient);

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var ingredient = await GetIngredientAsync(ingredientUpdateModel.Id);

                ingredient.Update(ingredientUpdateModel.Name, ingredientUpdateModel.IngredientCategoryId);
                _dbContext.Ingredients.Update(ingredient);

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        private async Task<Ingredient> GetIngredientAsync(Guid ingredientId)
            => await _dbContext.Ingredients
                .Select(i => Ingredient.Create(i.Id, i.Name, i.IngredientCategoryId))
                .SingleOrDefaultAsync(i => i.Id == ingredientId);
    }
}
