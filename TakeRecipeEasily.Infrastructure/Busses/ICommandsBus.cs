using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Busses
{
    public interface ICommandsBus
    {
        Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
