using NUnit.Framework;
using System;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class IntExtensionsTests
    {
        [Test]
        public void IsBetween_InclusiveBounds_ReturnsTrueForExactBounds()
        {
            Assert.IsTrue(5.IsBetween(5, 10));
            Assert.IsTrue(10.IsBetween(5, 10));
        }

        [Test]
        public void IsBetween_ExclusiveBounds_ReturnsFalseForExactBounds()
        {
            Assert.IsFalse(5.IsBetween(5, 10, false, true));
            Assert.IsFalse(10.IsBetween(5, 10, true, false));
            Assert.IsFalse(5.IsBetween(5, 10, false, false));
            Assert.IsFalse(10.IsBetween(5, 10, false, false));
        }

        [Test]
        public void IsBetween_ExclusiveBounds_ReturnsTrueForInsideRange()
        {
            Assert.IsTrue(6.IsBetween(5, 10, false, false));
            Assert.IsTrue(9.IsBetween(5, 10, false, false));
        }

        [Test]
        public void IsBetween_InvalidRange_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => 5.IsBetween(10, 5));
        }

        [Test]
        public void IsBetween_ValueOutsideRange_ReturnsFalse()
        {
            Assert.IsFalse(4.IsBetween(5, 10));
            Assert.IsFalse(11.IsBetween(5, 10));
        }

        [Test]
        public void IsEven_WorksCorrectly()
        {
            Assert.IsTrue(0.IsEven());
            Assert.IsTrue(2.IsEven());
            Assert.IsTrue((-2).IsEven());
            Assert.IsFalse(1.IsEven());
            Assert.IsFalse((-1).IsEven());
        }

        [Test]
        public void IsOdd_WorksCorrectly()
        {
            Assert.IsFalse(0.IsOdd());
            Assert.IsFalse(2.IsOdd());
            Assert.IsFalse((-2).IsOdd());
            Assert.IsTrue(1.IsOdd());
            Assert.IsTrue((-1).IsOdd());
        }

        [TestCase(1, "I")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(40, "XL")]
        [TestCase(90, "XC")]
        [TestCase(400, "CD")]
        [TestCase(900, "CM")]
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(2024, "MMXXIV")]
        public void ToRoman_ValidRange_ReturnsCorrectRomanNumeral(int number, string expected)
        {
            Assert.That(number.ToRoman(), Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(4000)]
        public void ToRoman_OutOfRange_ReturnsNumberAsString(int number)
        {
            Assert.That(number.ToRoman(), Is.EqualTo(number.ToString()));
        }

        [Test]
        public void IsMultipleOf_ZeroDivisor_ReturnsFalse()
        {
            Assert.IsFalse(10.IsMultipleOf(0));
        }

        [Test]
        public void IsMultipleOf_ValidDivisor_ReturnsTrueIfMultiple()
        {
            Assert.IsTrue(10.IsMultipleOf(5));
            Assert.IsTrue((-10).IsMultipleOf(5));
        }

        [Test]
        public void IsMultipleOf_ValidDivisor_ReturnsFalseIfNotMultiple()
        {
            Assert.IsFalse(10.IsMultipleOf(3));
        }
    }
}
