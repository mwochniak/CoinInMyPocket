using Autofac;
using TakeRecipeEasily.Infrastructure.Handlers;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Contracts.Events;

namespace TakeRecipeEasily.Infrastructure.Builders
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
