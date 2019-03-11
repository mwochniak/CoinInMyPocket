using System.Collections.Generic;
using System.Linq;
using System;

namespace TakeRecipeEasily.Infrastructure.Extensions
{
    public static class NumbersExtensions
    {
        public static double CalculateAvegareAccurateToTwoDecimalPlaces(this IEnumerable<int> that)
            => that.Any() ? Math.Round(that.ToList().Average(), 2) : 0;
    }
}
