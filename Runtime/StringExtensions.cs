using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RossoForge.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns true if the string is null, empty, or contains only white-space characters.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Converts the string to a slug (lowercase, alphanumeric, dash-separated).
        /// Useful for URLs or file names.
        /// </summary>
        public static string ToSlug(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            var normalized = str.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var slug = new StringBuilder();

            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc == UnicodeCategory.LowercaseLetter ||
                    uc == UnicodeCategory.UppercaseLetter ||
                    uc == UnicodeCategory.DecimalDigitNumber)
                {
                    slug.Append(ch);
                }
                else if (uc == UnicodeCategory.SpaceSeparator)
                {
                    slug.Append('-');
                }
            }

            return Regex.Replace(slug.ToString(), "-+", "-").Trim('-');
        }

        /// <summary>
        /// Returns a shortened version of the string with ellipsis if it exceeds maxLength.
        /// </summary>
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || maxLength < 0) return string.Empty;
            return str.Length <= maxLength ? str : str.Substring(0, maxLength) + "...";
        }

        /// <summary>
        /// Capitalizes the first letter of the string.
        /// </summary>
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Converts the string to a `bool` safely. Returns fallback if parsing fails.
        /// </summary>
        public static bool ToBool(this string str, bool fallback = false)
        {
            return bool.TryParse(str, out bool result) ? result : fallback;
        }

        /// <summary>
        /// Converts the string to an `int` safely. Returns fallback if parsing fails.
        /// </summary>
        public static int ToInt(this string str, int fallback = 0)
        {
            return int.TryParse(str, out int result) ? result : fallback;
        }

        /// <summary>
        /// Converts the string to a `float` safely. Returns fallback if parsing fails.
        /// </summary>
        public static float ToFloat(this string str, float fallback = 0f)
        {
            return float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out float result) ? result : fallback;
        }

        /// <summary>
        /// Checks if the string contains only digits.
        /// </summary>
        public static bool IsNumeric(this string str)
        {
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }

        /// <summary>
        /// Repeats the string n times.
        /// </summary>
        public static string Repeat(this string str, int count)
        {
            if (string.IsNullOrEmpty(str) || count <= 0) return string.Empty;
            return string.Concat(Enumerable.Repeat(str, count));
        }

        /// <summary>
        /// Returns a string with only alphanumeric characters.
        /// </summary>
        public static string RemoveNonAlphanumeric(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return new string(str.Where(char.IsLetterOrDigit).ToArray());
        }
    }
}
