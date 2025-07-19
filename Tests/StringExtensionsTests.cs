using NUnit.Framework;

namespace Rossoforge.Extensions.Tests
{
    public class StringExtensionsTests
    {
        [TestCase(null, ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)]
        [TestCase("abc", ExpectedResult = false)]
        public bool IsNullOrEmpty_ReturnsExpected(string input)
        {
            return input.IsNullOrEmpty();
        }

        [TestCase(null, ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)]
        [TestCase("   ", ExpectedResult = true)]
        [TestCase("abc", ExpectedResult = false)]
        public bool IsNullOrWhiteSpace_ReturnsExpected(string input)
        {
            return input.IsNullOrWhiteSpace();
        }

        [TestCase("Hello World!", ExpectedResult = "hello-world")]
        [TestCase("Café con Leche", ExpectedResult = "cafe-con-leche")]
        [TestCase("  Multiple   Spaces  ", ExpectedResult = "multiple-spaces")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(null, ExpectedResult = "")]
        public string ToSlug_ReturnsExpected(string input)
        {
            return input.ToSlug();
        }

        [TestCase("short", 10, ExpectedResult = "short")]
        [TestCase("This is long", 4, "...", ExpectedResult = "This...")]
        [TestCase("", 10, ExpectedResult = "")]
        [TestCase(null, 10, ExpectedResult = "")]
        [TestCase("Edge", -1, ExpectedResult = "")]
        public string Truncate_ReturnsExpected(string input, int maxLength, string replacement = "...")
        {
            return input.Truncate(maxLength, replacement);
        }

        [TestCase("hello", ExpectedResult = "Hello")]
        [TestCase("Hello", ExpectedResult = "Hello")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(null, ExpectedResult = null)]
        public string Capitalize_ReturnsExpected(string input)
        {
            return input.Capitalize();
        }

        [TestCase("true", ExpectedResult = true)]
        [TestCase("false", ExpectedResult = false)]
        [TestCase("notabool", true, ExpectedResult = true)]
        [TestCase(null, ExpectedResult = false)]
        public bool ToBool_ReturnsExpected(string input, bool fallback = false)
        {
            return input.ToBool(fallback);
        }

        [TestCase("42", ExpectedResult = 42)]
        [TestCase("notanint", 5, ExpectedResult = 5)]
        [TestCase(null, ExpectedResult = 0)]
        public int ToInt_ReturnsExpected(string input, int fallback = 0)
        {
            return input.ToInt(fallback);
        }

        [TestCase("3.14", ExpectedResult = 3.14f)]
        [TestCase("notafloat", 1.5f, ExpectedResult = 1.5f)]
        [TestCase(null, ExpectedResult = 0f)]
        public float ToFloat_ReturnsExpected(string input, float fallback = 0f)
        {
            return input.ToFloat(fallback);
        }

        [TestCase("12345", ExpectedResult = true)]
        [TestCase("123.45", ExpectedResult = false)]
        [TestCase("123abc", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        public bool AreAllDigits_ReturnsExpected(string input)
        {
            return input.AreAllDigits();
        }

        [TestCase("ab", 3, ExpectedResult = "ababab")]
        [TestCase("x", 0, ExpectedResult = "")]
        [TestCase(null, 5, ExpectedResult = "")]
        [TestCase("", 5, ExpectedResult = "")]
        public string Repeat_ReturnsExpected(string input, int count)
        {
            return input.Repeat(count);
        }

        [TestCase("abc123", ExpectedResult = "abc123")]
        [TestCase("a!@#b$%^c&*()", ExpectedResult = "abc")]
        [TestCase("123-456", ExpectedResult = "123456")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(null, ExpectedResult = null)]
        public string RemoveNonAlphanumeric_ReturnsExpected(string input)
        {
            return input.RemoveNonAlphanumeric();
        }
    }
}
