using TakeRecipeEasily.Infrastructure.Contracts.Events;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Busses
{
    public interface IEventsBus
    {
        Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
