using Autofac;
using CoinInMyPocket.Infrastructure.Handlers;
using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Contracts.Events;

namespace CoinInMyPocket.Infrastructure.Builders
{
    public interface IMVCWebServiceBuilder : IBuilder<IContainer>
    {
        IMVCWebServiceBuilder WithCommandsBus();

        IMVCWebServiceBuilder WithEventsBus();

        IMVCWebServiceBuilder SubscribeToEvent<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>;

        IMVCWebServiceBuilder RespondToCommand<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>;
    }
}
