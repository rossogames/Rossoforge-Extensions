using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Rossoforge.Extensions.Tests
{
    public class Vector2ExtensionsTests
    {
        [Test]
        public void Clamp_ClampsComponentsWithinRange()
        {
            Vector2 v = new Vector2(-10f, 20f);
            Vector2 result = v.Clamp(0f, 10f);
            Assert.AreEqual(new Vector2(0f, 10f), result);
        }

        [Test]
        public void Rotate_90Degrees_ReturnsCorrectVector()
        {
            Vector2 v = new Vector2(1f, 0f);
            Vector2 rotated = v.Rotate(90f);
            Assert.That(rotated.x, Is.EqualTo(0f).Within(0.0001f));
            Assert.That(rotated.y, Is.EqualTo(1f).Within(0.0001f));
        }

        [Test]
        public void RotateAround_90DegreesAroundPivot()
        {
            Vector2 v = new Vector2(1f, 0f);
            Vector2 pivot = Vector2.zero;
            Vector2 result = v.RotateAround(pivot, 90f);
            Assert.That(result.x, Is.EqualTo(0f).Within(0.0001f));
            Assert.That(result.y, Is.EqualTo(1f).Within(0.0001f));
        }

        [Test]
        public void Distance_ReturnsCorrectValue()
        {
            Vector2 v = Vector2.zero;
            Vector2 target = new Vector2(3f, 4f);
            float result = v.Distance(target);
            Assert.AreEqual(5f, result);
        }

        [Test]
        public void SqrDistance_ReturnsCorrectValue()
        {
            Vector2 v = Vector2.zero;
            Vector2 target = new Vector2(3f, 4f);
            float result = v.SqrDistance(target);
            Assert.AreEqual(25f, result);
        }

        [Test]
        public void Angle_ReturnsCorrectAngle()
        {
            Vector2 v = Vector2.right;
            Vector2 target = Vector2.up;
            float angle = v.Angle(target);
            Assert.AreEqual(90f, angle);
        }

        [Test]
        public void Dot_ReturnsCorrectDotProduct()
        {
            Vector2 v = new Vector2(1f, 2f);
            Vector2 target = new Vector2(3f, 4f);
            float dot = v.Dot(target);
            Assert.AreEqual(11f, dot);
        }

        [Test]
        public void Cross_ReturnsCorrectCrossProduct()
        {
            Vector2 v = new Vector2(1f, 2f);
            Vector2 target = new Vector2(3f, 4f);
            float cross = v.Cross(target);
            Assert.AreEqual(-2f, cross);
        }

        [Test]
        public void WithX_ReturnsVectorWithNewX()
        {
            Vector2 v = new Vector2(1f, 2f);
            Vector2 result = v.WithX(5f);
            Assert.AreEqual(new Vector2(5f, 2f), result);
        }

        [Test]
        public void WithY_ReturnsVectorWithNewY()
        {
            Vector2 v = new Vector2(1f, 2f);
            Vector2 result = v.WithY(5f);
            Assert.AreEqual(new Vector2(1f, 5f), result);
        }

        [Test]
        public void ProjectOn_ReturnsCorrectProjection()
        {
            Vector2 v = new Vector2(2f, 2f);
            Vector2 target = new Vector2(1f, 0f);
            Vector2 result = v.ProjectOn(target);

            Assert.That(result.x, Is.EqualTo(2f).Within(0.001f));
            Assert.That(result.y, Is.EqualTo(0f).Within(0.001f));
        }

        [Test]
        public void Reflect_ReturnsCorrectReflection()
        {
            Vector2 v = new Vector2(1f, -1f);
            Vector2 normal = Vector2.up;
            Vector2 result = v.Reflect(normal);
            Assert.That(result, Is.EqualTo(new Vector2(1f, 1f)).Within(0.001f));
        }

        [Test]
        public void ToVector3_ReturnsCorrectVector3()
        {
            Vector2 v = new Vector2(1f, 2f);
            Vector3 result = v.ToVector3(3f);
            Assert.AreEqual(new Vector3(1f, 2f, 3f), result);
        }

        [Test]
        public void Scale_WithScalar_ReturnsCorrectScaledVector()
        {
            Vector2 v = new Vector2(2f, 3f);
            float scale = 2f;
            Vector2 result = v.Scale(scale);

            Assert.That(result.x, Is.EqualTo(4f).Within(0.0001f));
            Assert.That(result.y, Is.EqualTo(6f).Within(0.0001f));
        }
    }
}
