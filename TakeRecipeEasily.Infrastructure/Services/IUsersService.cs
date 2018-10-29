using TakeRecipeEasily.Infrastructure.Contracts.QueryModels;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IUsersService : IServisable
    {
        Task CreateUserAsync(Guid id, string email, string firstName, string lastName, string hashedPassword);

        Task<UserRetrieveModel> GetUserAsync(Guid id);
        Task<UserRetrieveModel> GetUserAsync(string email);
    }
}
