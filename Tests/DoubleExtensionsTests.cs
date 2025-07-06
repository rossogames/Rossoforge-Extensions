using NUnit.Framework;
using System;

namespace Rossoforge.Extensions.Tests
{
    public class DoubleExtensionsTests
    {
        [Test]
        public void IsBetween_InclusiveBounds()
        {
            Assert.IsTrue(5d.IsBetween(5.0, 10.0));
            Assert.IsTrue(7.5d.IsBetween(5.0, 10.0));
            Assert.IsTrue(10d.IsBetween(5.0, 10.0));
        }

        [Test]
        public void IsBetween_InclusiveMinBound()
        {
            Assert.IsTrue(5d.IsBetween(5.0, 10.0, true, false));
            Assert.IsTrue(7.5d.IsBetween(5.0, 10.0, true, false));
            Assert.IsFalse(10d.IsBetween(5.0, 10.0, true, false));
        }

        [Test]
        public void IsBetween_InclusiveMaxBound()
        {
            Assert.IsFalse(5d.IsBetween(5.0, 10.0, false, true));
            Assert.IsTrue(7.5d.IsBetween(5.0, 10.0, false, true));
            Assert.IsTrue(10d.IsBetween(5.0, 10.0, false, true));
        }

        [Test]
        public void IsBetween_ExclusiveBounds()
        {
            Assert.IsFalse(5d.IsBetween(5.0, 10.0, false, false));
            Assert.IsTrue(7.5d.IsBetween(5.0, 10.0, false, false));
            Assert.IsFalse(10d.IsBetween(5.0, 10.0, false, false));
        }

        [Test]
        public void IsBetween_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 5.0.IsBetween(10.0, 5.0));
        }

        [TestCase(0.0, ExpectedResult = true)]
        [TestCase(1e-7, ExpectedResult = true)]
        [TestCase(-1e-7, ExpectedResult = true)]
        [TestCase(1e-5, ExpectedResult = false)]
        public bool IsZero_ReturnsExpected(double value)
        {
            return value.IsZero();
        }

        [Test]
        public void ApproximatelyEquals_ReturnsCorrectResult()
        {
            Assert.IsTrue(5.0d.ApproximatelyEquals(5.0000000000001d));
            Assert.IsFalse(5.0d.ApproximatelyEquals(5.01d));
        }

        [Test]
        public void RoundToNearest_RoundsCorrectly()
        {
            Assert.AreEqual(1.0, 0.95.RoundToNearest(1.0));
            Assert.AreEqual(1.5, 1.46.RoundToNearest(0.5));
            Assert.AreEqual(0.0, 0.0.RoundToNearest(0.5));
            Assert.AreEqual(5.2, 5.12319d.RoundToNearest(0.2));
            Assert.AreEqual(5.0, 5.05.RoundToNearest(0.1));
            Assert.AreEqual(-1.5, -1.46.RoundToNearest(0.5));
            Assert.AreEqual(-1.0, -1.2.RoundToNearest(0.5));
        }

        [TestCase(0)]
        [TestCase(-0.01)]
        [TestCase(-1)]
        public void RoundToNearest_ThrowsArgumentOutOfRangeException(double step)
        {
            double value = 1.23;
            Assert.Throws<ArgumentOutOfRangeException>(() => value.RoundToNearest(step));
        }

        [Test]
        public void ToPercentageString()
        {
            Assert.AreEqual("75%", 0.75.ToPercentageString());
            Assert.AreEqual("12.35%", 0.12345.ToPercentageString(2));
            Assert.AreEqual("33.3%", 0.3333333.ToPercentageString(1));
            Assert.AreEqual("100%", 1.0.ToPercentageString(0));
            Assert.AreEqual("100.0%", 1.0.ToPercentageString(1));
            Assert.AreEqual("150%", 1.5.ToPercentageString(0));
        }

        [Test]
        public void Lerp_ReturnsCorrectValue()
        {
            Assert.AreEqual(5.0, 0.5.Lerp(0.0, 10.0));
            Assert.AreEqual(10.0, 1.0.Lerp(0.0, 10.0));
            Assert.AreEqual(0.0, 0.0.Lerp(0.0, 10.0));
        }

        [Test]
        public void Normalize_ReturnsCorrectValue()
        {
            Assert.AreEqual(0.5, 5.0.Normalize(0.0, 10.0));
            Assert.AreEqual(0.0, 0.0.Normalize(0.0, 10.0));
            Assert.AreEqual(1.0, 10.0.Normalize(0.0, 10.0));
        }

        [Test]
        public void ToRadians_ConvertsCorrectly()
        {
            Assert.AreEqual(Math.PI, 180.0.ToRadians(), 1e-10);
            Assert.AreEqual(0.0, 0.0.ToRadians());
        }

        [Test]
        public void ToDegrees_ConvertsCorrectly()
        {
            Assert.AreEqual(180.0, Math.PI.ToDegrees(), 1e-10);
            Assert.AreEqual(0.0, 0.0.ToDegrees());
        }
    }
}
