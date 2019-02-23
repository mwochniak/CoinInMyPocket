using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IUsersCommandService : IServisable
    {
        Task CreateUserAsync(User user);
    }
}
