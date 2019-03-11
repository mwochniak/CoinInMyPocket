using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Ingredients
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
    }
}
