namespace RossoForge.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Determines if number is in the indicated range
        /// </summary>
        /// <param name="value">Number value to evaluate</param>
        /// <param name="min">Minimum value to evaluate</param>
        /// <param name="max">Maximum value to evaluate</param>
        /// <returns></returns>
        public static bool IsBetweenInclusive(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}