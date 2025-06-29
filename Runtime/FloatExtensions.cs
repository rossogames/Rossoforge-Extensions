using System;
using UnityEngine;

namespace RossoForge.Extensions
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Determines if a float value is within the specified range, with configurable inclusivity for the boundaries.
        /// </summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="inclusiveMin">Whether to include the lower bound (default: true).</param>
        /// <param name="inclusiveMax">Whether to include the upper bound (default: true).</param>
        /// <returns>True if the value is within the specified bounds.</returns>
        /// <exception cref="ArgumentException">Thrown if max is less than min.</exception>
        public static bool IsBetween(
            this float value,
            float min,
            float max,
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
        /// Remaps a value from one range to another.
        /// Equivalent to combining Mathf.InverseLerp and Mathf.Lerp.
        /// </summary>
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        /// <summary>
        /// Normalizes a value to a 0–1 range based on the provided min and max.
        /// Similar to Mathf.InverseLerp but as an extension method.
        /// </summary>
        public static float Normalize(this float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        /// <summary>
        /// Converts the float to the nearest integer using rounding.
        /// </summary>
        public static int ToRoundedInt(this float value)
        {
            return (int)Math.Round(value);
        }

        /// <summary>
        /// Converts the float to a fixed-point string with the given number of decimal places.
        /// </summary>
        public static string ToStringFixed(this float value, int decimals = 2)
        {
            return value.ToString($"F{decimals}");
        }

        /// <summary>
        /// Returns true if the value is very close to zero, using the given epsilon threshold.
        /// </summary>
        public static bool IsZero(this float value, float epsilon = 1e-6f)
        {
            return Math.Abs(value) < epsilon;
        }

        /// <summary>
        /// Snaps the float to the nearest multiple of the given grid size.
        /// </summary>
        public static float SnapToGrid(this float value, float gridSize)
        {
            if (gridSize == 0f) 
                return value;

            return (float)Math.Round(value / gridSize) * gridSize;
        }

        /// <summary>
        /// Converts to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees to convert.</param>
        public static float ToRadians(this float degrees)
        {
            return degrees * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Converts to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians to convert.</param>
        public static float ToDegrees(this float radians)
        {
            return radians * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Converts the value to a percentage string with optional precision (e.g., 0.75 -> "75%").
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="decimals">The number of decimal places to include in the percentage string (default: 0).</param>
        public static string ToPercentageString(this float value, int decimals = 0)
        {
            return (value * 100).ToString($"F{decimals}") + "%";
        }

        /// <summary>
        /// Rounds the number to the nearest multiple of a given step (e.g., 0.05, 0.1).
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="step">The step size to round to.</param>
        public static float RoundToNearest(this float value, float step)
        {
            if (step == 0)
                return value;

            return Mathf.Round(value / step) * step;
        }
    }
}