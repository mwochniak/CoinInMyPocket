using CoinInMyPocket.Infrastructure.Handlers;
using CoinInMyPocket.Infrastructure.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Busses
{
    public class EventsBus : IEventsBus
    {
        private readonly Func<Type, IEnumerable<IEventHandler>> _handlersFactory;

        public EventsBus(Func<Type, IEnumerable<IEventHandler>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _handlersFactory(typeof(TEvent))
                .Cast<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
            {
                await handler.HandleEventAsync(@event);
            }
        }
    }
}
