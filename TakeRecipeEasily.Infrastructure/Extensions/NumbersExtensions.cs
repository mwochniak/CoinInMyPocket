using System.Collections.Generic;
using System.Linq;

namespace TakeRecipeEasily.Infrastructure.Extensions
{
    public static class NumbersExtensions
    {
        public static double CalculateAvegare(this IEnumerable<int> that)
            => that.Any() ? that.ToList().Average() : 0;
    }
}
