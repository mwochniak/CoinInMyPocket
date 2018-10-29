using TakeRecipeEasily.Infrastructure.Handlers;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Busses
{
    public class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, ICommandHandler> _handlersFactory;

        public CommandsBus(Func<Type, ICommandHandler> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_handlersFactory(typeof(TCommand));
            await handler.HandleCommandAsync(command);
        }
    }
}
