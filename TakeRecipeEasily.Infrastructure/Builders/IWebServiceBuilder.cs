using Autofac;
using TakeRecipeEasily.Infrastructure.Handlers;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Contracts.Events;

namespace TakeRecipeEasily.Infrastructure.Builders
{
    public interface IWebServiceBuilder : IBuilder<IContainer>
    {
        IWebServiceBuilder WithCommandsBus();

        IWebServiceBuilder WithEventsBus();

        IWebServiceBuilder SubscribeToEvent<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>;

        IWebServiceBuilder RespondToCommand<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>;
    }
}
