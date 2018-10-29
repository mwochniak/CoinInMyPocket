using System.Collections.Generic;
using System.Linq;

namespace TakeRecipeEasily.Infrastructure.Exceptions
{
    public class ErrorsResult : IErrorsResult
    {
        public IEnumerable<string> Errors { get; set; }

        public ErrorsResult()
        {
            Errors = Enumerable.Empty<string>();
        }
    }
}
