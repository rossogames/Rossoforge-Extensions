namespace RossoForge.Extensions
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Determines if number is in the indicated range
        /// </summary>
        /// <param name="value">Floating number value to evaluate</param>
        /// <param name="min">Minimum value to evaluate</param>
        /// <param name="max">Maximum value to evaluate</param>
        /// <returns></returns>
        public static bool IsBetweenInclusive(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }
}