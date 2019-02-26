using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class UsersCommandService : IUsersCommandService
    {
        private readonly DatabaseContext _dbContext;

        public UsersCommandService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task CreateUserAsync(User user)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (await _dbContext.Users.AnyAsync(u => u.Email == user.Email))
                    return;

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                transactionScope.Complete();
            }
        }
    }
}
