using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TakeRecipeEasilyContext _context;

        public UsersRepository(TakeRecipeEasilyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailInUse(string email)
            => await _context.Users.AnyAsync(u => u.Email == email);

        public async Task<User> GetAsync(Guid userId)
            => await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        public async Task<User> GetAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}
