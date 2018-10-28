using System.Collections.Generic;

namespace CoinInMyPocket.Infrastructure.Exceptions
{
    public interface IErrorsResult
    {
        IEnumerable<string> Errors { get; }
    }
}
