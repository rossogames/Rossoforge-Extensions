using NUnit.Framework;
using UnityEngine;

namespace Rossoforge.Extensions.Tests
{
    public class RectExtensionsTests
    {
        [Test]
        public void Contains_PointInside_ReturnsTrue()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Assert.IsTrue(rect.Contains(5, 5));
        }

        [Test]
        public void Contains_PointOutside_ReturnsFalse()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Assert.IsFalse(rect.Contains(15, 5));
        }

        [Test]
        public void Contains_PointOnRightEdge_ReturnsFalse()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Assert.IsFalse(rect.Contains(10, 5));
        }

        [Test]
        public void Contains_PointOnBottomEdge_ReturnsTrue()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Assert.IsTrue(rect.Contains(5, 0));
        }

        [Test]
        public void Contains_AllowInverse_True_HandlesNegativeWidthHeight()
        {
            Rect rect = new Rect(10, 10, -10, -10); // equivalent to (0, 0, 10, 10)
            Assert.IsTrue(rect.Contains(5, 5, allowInverse: true));
        }

        [Test]
        public void Contains_AllowInverse_False_WithNegativeSize_ReturnsFalse()
        {
            Rect rect = new Rect(10, 10, -10, -10);
            Assert.IsFalse(rect.Contains(5, 5, allowInverse: false));
        }

        [Test]
        public void ClampPoint_PointInside_ReturnsSamePoint()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 point = new Vector2(5, 5);
            Assert.AreEqual(point, rect.ClampPoint(point));
        }

        [Test]
        public void ClampPoint_PointOutside_ReturnsClampedPoint()
        {
            Rect rect = new Rect(0, 0, 10, 10);
            Vector2 point = new Vector2(15, -5);
            Vector2 expected = new Vector2(10, 0);
            Assert.AreEqual(expected, rect.ClampPoint(point));
        }

        [Test]
        public void BottomLeft_ReturnsCorrectCorner()
        {
            Rect rect = new Rect(2, 3, 4, 5);
            Assert.AreEqual(new Vector2(2, 3), rect.BottomLeft());
        }

        [Test]
        public void BottomRight_ReturnsCorrectCorner()
        {
            Rect rect = new Rect(2, 3, 4, 5);
            Assert.AreEqual(new Vector2(6, 3), rect.BottomRight());
        }

        [Test]
        public void TopLeft_ReturnsCorrectCorner()
        {
            Rect rect = new Rect(2, 3, 4, 5);
            Assert.AreEqual(new Vector2(2, 8), rect.TopLeft());
        }

        [Test]
        public void TopRight_ReturnsCorrectCorner()
        {
            Rect rect = new Rect(2, 3, 4, 5);
            Assert.AreEqual(new Vector2(6, 8), rect.TopRight());
        }
    }
}
