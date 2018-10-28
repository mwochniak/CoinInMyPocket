using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Services
{
    public interface IAuthenticationService : IServisable
    {
        Task LoginAsync(string email, string password);
    }
}
