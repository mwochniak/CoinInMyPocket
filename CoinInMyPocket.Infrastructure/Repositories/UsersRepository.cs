using CoinInMyPocket.Core.Domain;
using CoinInMyPocket.Core.Repositories;
using CoinInMyPocket.Infrastructure.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CoinInMyPocketContext _context;

        public UsersRepository(CoinInMyPocketContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailInUse(string email)
            => await _context.Users.AnyAsync(u => u.Email == email);

        public async Task<User> GetUserAsync(Guid userId)
            => await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        public async Task<User> GetUserAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}
