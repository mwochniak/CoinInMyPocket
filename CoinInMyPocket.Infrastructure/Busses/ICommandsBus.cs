using CoinInMyPocket.Infrastructure.Contracts.Commands;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Busses
{
    public interface ICommandsBus
    {
        Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
