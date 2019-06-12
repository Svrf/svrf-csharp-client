using System;

namespace Svrf.Extensions
{
    internal static class IntExtension
    {
        internal static void ValidateRange(this int number, string argName, int? min = int.MinValue, int? max = int.MaxValue)
        {
            if (min.HasValue && number < min)
            {
                throw new ArgumentOutOfRangeException(argName, $"{argName} should be equal or greater than {min}");
            }

            if (max.HasValue && number > max)
            {
                throw new ArgumentOutOfRangeException(argName, $"{argName} should be equal or less than {max}");
            }
        }
    }
}
