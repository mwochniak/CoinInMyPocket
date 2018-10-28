using CoinInMyPocket.Infrastructure.Contracts.Events;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Handlers
{
    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        Task HandleEventAsync(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
