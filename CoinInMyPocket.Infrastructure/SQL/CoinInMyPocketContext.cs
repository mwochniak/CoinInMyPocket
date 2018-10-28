using CoinInMyPocket.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoinInMyPocket.Infrastructure.SQL
{
    public class CoinInMyPocketContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CoinInMyPocketContext(
            DbContextOptions<CoinInMyPocketContext> options) : base(options)
        {
        }
    }
}
