using System;

namespace RossoForge.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines if an int is within a specified range, with configurable inclusivity.
        /// </summary>
        public static bool IsBetween(
            this double value,
            int min,
            int max,
            bool inclusiveMin = true,
            bool inclusiveMax = true)
        {
            if (max < min)
                throw new ArgumentException($"Invalid range: max ({max}) is less than min ({min}).");

            bool lowerCheck = inclusiveMin ? value >= min : value > min;
            bool upperCheck = inclusiveMax ? value <= max : value < max;

            return lowerCheck && upperCheck;
        }
    }
}