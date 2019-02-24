using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Users;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class UsersQueryService : IUsersQueryService
    {
        private readonly DatabaseContext _dbContext;

        public UsersQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<UserRetrieveModel> GetUserAsync(Guid id)
            => await _dbContext.Users.Where(u => u.Id == id).Select(u => new UserRetrieveModel()
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName
            })
            .SingleOrDefaultAsync();

        public async Task<UserRetrieveModel> GetUserAsync(string email)
            => await _dbContext.Users.Where(u => u.Email == email).Select(u => new UserRetrieveModel()
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName
            })
            .SingleOrDefaultAsync();
    }
}
