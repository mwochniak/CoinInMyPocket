using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IAuthenticationService : IServisable
    {
        Task LoginAsync(string email, string password);
    }
}
