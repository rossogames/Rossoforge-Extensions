using System;

namespace Rossoforge.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines whether the double value falls within a specified range,
        /// with independent control over whether the minimum and maximum bounds are inclusive.
        /// </summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="inclusiveMin">Whether the minimum bound is inclusive (default: true).</param>
        /// <param name="inclusiveMax">Whether the maximum bound is inclusive (default: true).</param>
        /// <returns>True if the value lies within the range according to the specified inclusivity; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if the maximum is less than the minimum.</exception>

        public static bool IsBetween(
            this double value,
            double min,
            double max,
            bool inclusiveMin = true,
            bool inclusiveMax = true)
        {
            if (max < min)
                throw new ArgumentException($"Invalid range: max ({max}) is less than min ({min}).");

            bool lowerCheck = inclusiveMin ? value >= min : value > min;
            bool upperCheck = inclusiveMax ? value <= max : value < max;

            return lowerCheck && upperCheck;
        }

        /// <summary>
        /// Returns true if the value is very close to zero, using the given epsilon threshold.
        /// </summary>
        public static bool IsZero(this double value, double epsilon = 1e-6f)
        {
            return Math.Abs(value) < epsilon;
        }

        /// <summary>
        /// Returns true if the double is approximately equal to another, using a small tolerance (epsilon).
        /// </summary>
        /// <param name="a">The first double value.</param>
        /// <param name="b"> The second double value to compare against.</param>
        /// <param name="epsilon"> The tolerance level for comparison (default: 1e-10).</param>
        public static bool ApproximatelyEquals(this double a, double b, double epsilon = 1e-10)
        {
            return Math.Abs(a - b) < epsilon;
        }

        /// <summary>
        /// Rounds the number to the nearest multiple of a given step (e.g., 0.05, 0.1).
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="step">The step size to round to.</param>
        public static double RoundToNearest(this double value, double step)
        {
            if (step <= 0)
                throw new ArgumentOutOfRangeException(nameof(step), "Step must be greater than zero.");

            return Math.Round(value / step) * step;
        }

        /// <summary>
        /// Converts the double to a percentage string with optional precision (e.g., 0.75 -> "75%").
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="decimals">The number of decimal places to include in the percentage string (default: 0).</param>
        public static string ToPercentageString(this double value, int decimals = 0)
        {
            return (value * 100).ToString($"F{decimals}") + "%";
        }

        /// <summary>
        /// Linearly interpolates between two values using the current double as the t parameter.
        /// </summary>
        /// <param name="t">The interpolation factor (0.0 to 1.0).</param>
        /// <param name="from">The starting value.</param>
        /// <param name="to">The ending value.</param>
        public static double Lerp(this double t, double from, double to)
        {
            return from + (to - from) * t;
        }

        /// <summary>
        /// Normalizes a value to a 0–1 range based on the provided min and max.
        /// Similar to Mathf.InverseLerp but as an extension method.
        /// </summary>
        public static double Normalize(this double t, double min, double max)
        {
            return (t - min) / (max - min);
        }

        /// <summary>
        /// Converts the double to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees to convert.</param>
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        /// <summary>
        /// Converts the double to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians to convert.</param>
        public static double ToDegrees(this double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}