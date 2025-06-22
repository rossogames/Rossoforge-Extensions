using System;
using System.Text;

namespace RossoForge.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Determines if an int is within a specified range, with configurable inclusivity.
        /// </summary>
        public static bool IsBetween(
            this int value,
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

        /// <summary>
        /// Check if a number is even
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns></returns>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Check if a number is odd
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns></returns>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Convert a number to Roman numerals
        /// </summary>
        /// <param name="number">number to convert</param>
        /// <returns></returns>
        public static string ToRoman(this int number)
        {
            if (number < 1 || number > 3999) return number.ToString();

            var map = new[] {
                (1000, "M"), 
                (900, "CM"), 
                (500, "D"), 
                (400, "CD"),
                (100, "C"), 
                (90, "XC"), 
                (50, "L"), 
                (40, "XL"),
                (10, "X"), 
                (9, "IX"), 
                (5, "V"), 
                (4, "IV"), 
                (1, "I")
            };

            var result = new StringBuilder();
            foreach (var (value, numeral) in map)
            {
                while (number >= value)
                {
                    result.Append(numeral);
                    number -= value;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Determines whether the specified integer is a multiple of the given divisor.
        /// </summary>
        /// <param name="value">The integer to check.</param>
        /// <param name="divisor">The divisor to test against. Must not be zero.</param>
        /// <returns>true if value is a multiple of divisor;  otherwise, false. </returns>
        public static bool IsMultipleOf(this int value, int divisor)
        {
            return divisor != 0 && value % divisor == 0;
        }
    }
}