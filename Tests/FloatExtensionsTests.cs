using NUnit.Framework;
using System;
using UnityEngine;

namespace Rossoforge.Extensions.Tests
{
    public class FloatExtensionsTests
    {
        [Test]
        public void IsBetween_InclusiveBounds()
        {
            Assert.IsTrue(5f.IsBetween(5.0f, 10.0f));
            Assert.IsTrue(7f.IsBetween(5.0f, 10.0f));
            Assert.IsTrue(10f.IsBetween(5.0f, 10.0f));
        }

        [Test]
        public void IsBetween_InclusiveMinBound()
        {
            Assert.IsTrue(5f.IsBetween(5.0f, 10.0f, true, false));
            Assert.IsTrue(7.5f.IsBetween(5.0f, 10.0f, true, false));
            Assert.IsFalse(10f.IsBetween(5.0f, 10.0f, true, false));
        }

        [Test]
        public void IsBetween_InclusiveMaxBound()
        {
            Assert.IsFalse(5f.IsBetween(5.0f, 10.0f, false, true));
            Assert.IsTrue(7.5f.IsBetween(5.0f, 10.0f, false, true));
            Assert.IsTrue(10f.IsBetween(5.0f, 10.0f, false, true));
        }

        [Test]
        public void IsBetween_ExclusiveBounds()
        {
            Assert.IsFalse(5f.IsBetween(5.0f, 10.0f, false, false));
            Assert.IsTrue(7.5f.IsBetween(5.0f, 10.0f, false, false));
            Assert.IsFalse(10f.IsBetween(5.0f, 10.0f, false, false));
        }

        [Test]
        public void IsBetween_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 5.0f.IsBetween(10.0f, 5.0f));
        }

        [TestCase(0.0f, ExpectedResult = true)]
        [TestCase(1e-7f, ExpectedResult = true)]
        [TestCase(-1e-7f, ExpectedResult = true)]
        [TestCase(1e-5f, ExpectedResult = false)]
        public bool IsZero_ReturnsExpected(float value)
        {
            return value.IsZero();
        }

        [Test]
        public void RoundToNearest_RoundsCorrectly()
        {
            Assert.AreEqual(1.0f, 0.95f.RoundToNearest(1.0f), 1e-10f);
            Assert.AreEqual(1.5f, 1.46f.RoundToNearest(0.5f), 1e-10f);
            Assert.AreEqual(0.0f, 0.0f.RoundToNearest(0.5f), 1e-10f);
            Assert.AreEqual(5.2f, 5.12319f.RoundToNearest(0.2f), 1e-1f);
            Assert.AreEqual(5.0f, 5.05f.RoundToNearest(0.1f), 1e-10f);
            Assert.AreEqual(-1.5f, -1.46f.RoundToNearest(0.5f), 1e-10f);
            Assert.AreEqual(-1.0f, -1.2f.RoundToNearest(0.5f), 1e-10f);
        }


        [TestCase(0f)]
        [TestCase(-0.01f)]
        [TestCase(-1f)]
        public void RoundToNearest_ThrowsArgumentException(float step)
        {
            float value = 1.23f;
            Assert.Throws<ArgumentException>(() => value.RoundToNearest(step));
        }

        [Test]
        public void ToPercentageString()
        {
            Assert.AreEqual("75%", 0.75f.ToPercentageString());
            Assert.AreEqual("12.35%", 0.12345f.ToPercentageString(2));
            Assert.AreEqual("33.3%", 0.3333333f.ToPercentageString(1));
            Assert.AreEqual("100%", 1.0f.ToPercentageString(0));
            Assert.AreEqual("100.0%", 1.0f.ToPercentageString(1));
            Assert.AreEqual("150%", 1.5f.ToPercentageString(0));
        }

        [Test]
        public void ToRadians_ConvertsCorrectly()
        {
            Assert.AreEqual(Mathf.PI, 180.0f.ToRadians(), 1e-10f);
            Assert.AreEqual(0.0f, 0.0f.ToRadians());
        }

        [Test]
        public void ToDegrees_ConvertsCorrectly()
        {
            Assert.AreEqual(180.0f, Mathf.PI.ToDegrees(), 1e-10f);
            Assert.AreEqual(0.0f, 0.0f.ToDegrees());
        }

        [Test]
        public void Remap_MapsCorrectly()
        {
            Assert.AreEqual(50f, 0.5f.Remap(0f, 1f, 0f, 100f), 1e-5f);
            Assert.AreEqual(0f, 5f.Remap(0f, 10f, -1f, 1f), 1e-5f);
            Assert.AreEqual(1f, 10f.Remap(0f, 10f, 0f, 1f), 1e-5f);
        }

        [Test]
        public void Remap_WithNegativeRanges()
        {
            Assert.AreEqual(-5f, 0.5f.Remap(0f, 1f, 0f, -10f), 1e-5f);
            Assert.AreEqual(0.5f, (-5f).Remap(-10f, 0f, 0f, 1f), 1e-5f);
        }

        [Test]
        public void Normalize_MapsCorrectly()
        {
            Assert.AreEqual(0.5f, 5f.Normalize(0f, 10f), 1e-5f);
            Assert.AreEqual(0f, 0f.Normalize(0f, 10f), 1e-5f);
            Assert.AreEqual(1f, 10f.Normalize(0f, 10f), 1e-5f);
        }

        [Test]
        public void Normalize_WithNegativeRange()
        {
            Assert.AreEqual(0.5f, (-5f).Normalize(-10f, 0f), 1e-5f);
            Assert.AreEqual(0f, (-10f).Normalize(-10f, 0f), 1e-5f);
        }

        [Test]
        public void ToRoundedInt_RoundsCorrectly()
        {
            Assert.AreEqual(2, 2.5f.ToRoundedInt());
            Assert.AreEqual(-3, -2.6f.ToRoundedInt());
            Assert.AreEqual(0, 0.49f.ToRoundedInt());
        }

        [Test]
        public void ToStringFixed()
        {
            Assert.AreEqual("1.23", 1.23456f.ToStringFixed());
            Assert.AreEqual("1.00", 1f.ToStringFixed());
            Assert.AreEqual("1.2", 1.23456f.ToStringFixed(1));
            Assert.AreEqual("1.235", 1.23456f.ToStringFixed(3));
        }

        [Test]
        public void SnapToGrid_SnapsCorrectly()
        {
            Assert.AreEqual(10f, 9.7f.SnapToGrid(5f));
            Assert.AreEqual(15f, 14.9f.SnapToGrid(5f));
            Assert.AreEqual(0f, 0.1f.SnapToGrid(1f));
            Assert.AreEqual(-10f, (-9.7f).SnapToGrid(5f));
            Assert.AreEqual(-15f, (-14.9f).SnapToGrid(5f));
            Assert.AreEqual(1.2f, 1.23f.SnapToGrid(0.1f), 1e-5f);
            Assert.AreEqual(1.25f, 1.26f.SnapToGrid(0.25f), 1e-5f);
            Assert.AreEqual(0f, 0f.SnapToGrid(5f));
        }

        [Test]
        public void SnapToGrid_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => 1f.SnapToGrid(0f));
            Assert.Throws<ArgumentException>(() => 1f.SnapToGrid(-1f));
        }
    }
}
