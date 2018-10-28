using CoinInMyPocket.Infrastructure.Contracts.Events;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Busses
{
    public interface IEventsBus
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
