using CoinInMyPocket.Core.Abstractions;
using System;

namespace CoinInMyPocket.Core.Domain
{
    public class Entity : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
