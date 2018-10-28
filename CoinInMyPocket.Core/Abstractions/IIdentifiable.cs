using System;

namespace CoinInMyPocket.Core.Abstractions
{
    internal interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
