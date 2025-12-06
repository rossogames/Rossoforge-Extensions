using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools.Utils;

namespace Rossoforge.Extensions.Tests
{
    public class Vector3ExtensionsTest
    {
        [Test]
        public void Clamp_ClampsEachComponentWithinRange()
        {
            Vector3 v = new Vector3(-10f, 5f, 100f);
            Vector3 result = v.Clamp(0f, 10f);
            Assert.AreEqual(new Vector3(0f, 5f, 10f), result);
        }

        [Test]
        public void RotateAroundAxis_RotatesCorrectly()
        {
            Vector3 v = Vector3.forward;
            Vector3 axis = Vector3.up;
            Vector3 result = v.RotateAroundAxis(axis, 90f);
            Assert.That(result.x, Is.EqualTo(1f).Within(0.001f));
            Assert.That(result.z, Is.EqualTo(0f).Within(0.001f));
        }

        [Test]
        public void RotateAround_PivotAndAxis_ReturnsCorrectValue()
        {
            Vector3 v = new Vector3(1f, 0f, 0f);
            Vector3 pivot = Vector3.zero;
            Vector3 axis = Vector3.up;
            Vector3 result = v.RotateAround(pivot, axis, 90f);
            Assert.That(result.x, Is.EqualTo(0f).Within(0.001f));
            Assert.That(result.z, Is.EqualTo(-1f).Within(0.001f));
        }

        [Test]
        public void Scale_WithScalar_ReturnsScaledVector()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector3 result = v.Scale(2f);
            Assert.AreEqual(new Vector3(2f, 4f, 6f), result);
        }

        [Test]
        public void Distance_ReturnsCorrectValue()
        {
            Vector3 v = Vector3.zero;
            Vector3 target = new Vector3(3f, 4f, 0f);
            float result = v.Distance(target);
            Assert.AreEqual(5f, result);
        }

        [Test]
        public void Direction_ReturnsNormalizedVectorPointingFromInputToTarget()
        {
            Vector3 input = Vector3.zero;
            Vector3 target = new Vector3(0, 0, 10);

            Vector3 result = input.Direction(target);

            Assert.That(result, Is.EqualTo(Vector3.forward).Using(Vector3EqualityComparer.Instance));
            Assert.That(result.magnitude, Is.EqualTo(1f).Within(1e-5f)); // Verifica que esté normalizado
        }

        [Test]
        public void Direction_ReturnsNormalizedVectorInArbitraryDirection()
        {
            Vector3 input = new Vector3(1, 2, 3);
            Vector3 target = new Vector3(4, 6, 3);

            Vector3 result = input.Direction(target);

            Vector3 expected = (target - input).normalized;
            Assert.That(result, Is.EqualTo(expected).Using(Vector3EqualityComparer.Instance));
        }

        [Test]
        public void Direction_WhenInputEqualsTarget_ReturnsZeroVector()
        {
            Vector3 input = new Vector3(5, 5, 5);
            Vector3 target = new Vector3(5, 5, 5);

            Vector3 result = input.Direction(target);

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SqrDistance_ReturnsCorrectValue()
        {
            Vector3 v = Vector3.zero;
            Vector3 target = new Vector3(3f, 4f, 0f);
            float result = v.SqrDistance(target);
            Assert.AreEqual(25f, result);
        }

        [Test]
        public void Angle_ReturnsCorrectAngle()
        {
            Vector3 v = Vector3.right;
            Vector3 target = Vector3.up;
            float angle = v.Angle(target);
            Assert.AreEqual(90f, angle);
        }

        [Test]
        public void Dot_ReturnsCorrectDotProduct()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector3 target = new Vector3(4f, -5f, 6f);
            float result = v.Dot(target);
            Assert.AreEqual(12f, result);
        }

        [Test]
        public void Cross_ReturnsCorrectCrossProduct()
        {
            Vector3 v = Vector3.right;
            Vector3 target = Vector3.up;
            Vector3 result = v.Cross(target);
            Assert.AreEqual(Vector3.forward, result);
        }

        [Test]
        public void WithX_ReturnsVectorWithNewX()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector3 result = v.WithX(9f);
            Assert.AreEqual(new Vector3(9f, 2f, 3f), result);
        }

        [Test]
        public void WithY_ReturnsVectorWithNewY()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector3 result = v.WithY(9f);
            Assert.AreEqual(new Vector3(1f, 9f, 3f), result);
        }

        [Test]
        public void WithZ_ReturnsVectorWithNewZ()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector3 result = v.WithZ(9f);
            Assert.AreEqual(new Vector3(1f, 2f, 9f), result);
        }

        [Test]
        public void ProjectOn_ReturnsCorrectProjection()
        {
            Vector3 v = new Vector3(2f, 2f, 0f);
            Vector3 target = new Vector3(1f, 0f, 0f);
            Vector3 result = v.ProjectOn(target);
            Assert.That(result.x, Is.EqualTo(2f).Within(0.001f));
            Assert.That(result.y, Is.EqualTo(0f).Within(0.001f));
            Assert.That(result.z, Is.EqualTo(0f).Within(0.001f));
        }

        [Test]
        public void Reflect_ReturnsCorrectReflection()
        {
            Vector3 v = new Vector3(0f, -1f, 0f);
            Vector3 normal = Vector3.up;
            Vector3 result = v.Reflect(normal);
            Assert.AreEqual(Vector3.up, result);
        }

        [Test]
        public void ToVector2_ReturnsCorrectConversion()
        {
            Vector3 v = new Vector3(1f, 2f, 3f);
            Vector2 result = v.ToVector2();
            Assert.AreEqual(new Vector2(1f, 2f), result);
        }
    }
}
