using TakeRecipeEasily.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace TakeRecipeEasily.Infrastructure.SQL
{
    public class TakeRecipeEasilyContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TakeRecipeEasilyContext(
            DbContextOptions<TakeRecipeEasilyContext> options) : base(options)
        {
        }
    }
}
