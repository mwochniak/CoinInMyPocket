using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Users;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IUsersQueryService : IServisable
    {
        Task<UserRetrieveModel> GetUserAsync(Guid id);
        Task<UserRetrieveModel> GetUserAsync(string email);
    }
}
