using TakeRecipeEasily.Infrastructure.Contracts.Events;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Handlers
{
    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        Task HandleEventAsync(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
