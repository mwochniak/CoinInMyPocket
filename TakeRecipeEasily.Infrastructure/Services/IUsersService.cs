using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Users;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IUsersService : IServisable
    {
        Task CreateUserAsync(User user);

        Task<UserRetrieveModel> GetUserAsync(Guid id);
        Task<UserRetrieveModel> GetUserAsync(string email);
    }
}
