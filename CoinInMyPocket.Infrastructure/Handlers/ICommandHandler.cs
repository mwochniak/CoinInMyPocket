using CoinInMyPocket.Infrastructure.Contracts.Commands;
using System;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Handlers
{
    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task HandleCommandAsync(TCommand command);
    }

    public interface ICommandHandler
    {
    }
}
