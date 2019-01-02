using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IUsersRepository : IRepositorable
    {
        Task CreateAsync(User user);

        Task<bool> IsEmailInUse(string email);

        Task<User> GetAsync(Guid userId);
        Task<User> GetAsync(string email);
    }
}
