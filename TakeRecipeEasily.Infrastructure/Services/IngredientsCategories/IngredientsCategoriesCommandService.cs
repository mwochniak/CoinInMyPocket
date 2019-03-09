using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.IngredientsCategories
{
    public class IngredientsCategoriesCommandService : IIngredientsCategoriesCommandService
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsCategoriesCommandService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task CreateIngredientCategoryAsync(IngredientCategory ingredientCategory)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (await _dbContext.IngredientsCategories.AnyAsync(i => i.Name == ingredientCategory.Name))
                    return;

                await _dbContext.IngredientsCategories.AddAsync(ingredientCategory);
                await _dbContext.SaveChangesAsync();

                transactionScope.Complete();
            }
        }
    }
}
