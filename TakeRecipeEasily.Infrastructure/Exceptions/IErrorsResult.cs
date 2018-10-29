using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Exceptions
{
    public interface IErrorsResult
    {
        IEnumerable<string> Errors { get; }
    }
}
