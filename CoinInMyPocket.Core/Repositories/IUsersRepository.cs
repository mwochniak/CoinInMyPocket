using CoinInMyPocket.Core.Abstractions;
using CoinInMyPocket.Core.Domain;
using System;
using System.Threading.Tasks;

namespace CoinInMyPocket.Core.Repositories
{
    public interface IUsersRepository : IRepositorable
    {
        Task AddAsync(User user);

        Task<bool> IsEmailInUse(string email);

        Task<User> GetUserAsync(Guid userId);
        Task<User> GetUserAsync(string email);
    }
}
