using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class IListExtensionsTests
    {
        [Test]
        public void ShuffleInPlace_ShufflesElements()
        {
            // Arrange
            var original = new List<int> { 1, 2, 3, 4, 5 };
            var list = new List<int>(original);
            var rng = new System.Random(42); // usar semilla para reproducibilidad

            // Act
            list.ShuffleInPlace(rng);

            // Assert: debe contener los mismos elementos
            Assert.That(list.OrderBy(x => x), Is.EqualTo(original.OrderBy(x => x)), "Los elementos deben coincidir tras la mezcla.");

            // Assert: hay alta probabilidad de que el orden haya cambiado
            Assert.That(list, Is.Not.EqualTo(original), "El orden debería cambiar después de mezclar.");
        }

        [Test]
        public void ShuffleInPlace_DoesNotThrowOnEmptyList()
        {
            // Arrange
            var list = new List<int>();

            // Act & Assert
            Assert.DoesNotThrow(() => list.ShuffleInPlace(), "No debería lanzar excepción en listas vacías.");
            Assert.IsEmpty(list);
        }

        [Test]
        public void ShuffleInPlace_DoesNotThrowOnSingleElement()
        {
            // Arrange
            var list = new List<int> { 42 };

            // Act
            list.ShuffleInPlace();

            // Assert
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo(42));
        }

        [Test]
        public void At2D_ReturnsCorrectValue()
        {
            var grid = new List<int>
            {
                1, 2, 3,
                4, 5, 6
            };

            int value = grid.At2D(x: 1, y: 1, width: 3, height: 2);

            Assert.AreEqual(5, value);
        }

        [Test]
        public void At2D_Throws_WhenOutOfBounds()
        {
            var grid = new List<int> { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                grid.At2D(x: 3, y: 0, width: 3, height: 1));
        }

        [Test]
        public void At2D_Throws_WhenSourceIsNull()
        {
            IList<int> grid = null;

            Assert.Throws<ArgumentNullException>(() =>
                grid.At2D(0, 0, 1, 1));
        }

        [Test]
        public void At3D_ReturnsCorrectValue()
        {
            var grid = new List<int>
            {
                // z = 0
                1, 2,
                3, 4,

                // z = 1
                5, 6,
                7, 8
            };

            int value = grid.At3D(
                x: 1,
                y: 0,
                z: 1,
                width: 2,
                height: 2,
                depth: 2);

            Assert.AreEqual(6, value);
        }

        [Test]
        public void At3D_Throws_WhenOutOfBounds()
        {
            var grid = new List<int>(new int[8]);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                grid.At3D(0, 0, 2, 2, 2, 2));
        }

        [Test]
        public void At3D_Throws_WhenSourceIsNull()
        {
            IList<int> grid = null;

            Assert.Throws<ArgumentNullException>(() =>
                grid.At3D(0, 0, 0, 1, 1, 1));
        }

        [Test]
        public void TryAt2D_ReturnsTrue_WhenInBounds()
        {
            var grid = new List<int>
            {
                10, 20,
                30, 40
            };

            bool result = grid.TryAt2D(
                x: 0,
                y: 1,
                width: 2,
                height: 2,
                out int value);

            Assert.IsTrue(result);
            Assert.AreEqual(30, value);
        }

        [Test]
        public void TryAt2D_ReturnsFalse_WhenOutOfBounds()
        {
            var grid = new List<int> { 1, 2, 3, 4 };

            bool result = grid.TryAt2D(
                x: -1,
                y: 0,
                width: 2,
                height: 2,
                out int value);

            Assert.IsFalse(result);
            Assert.AreEqual(default(int), value);
        }

        [Test]
        public void TryAt2D_ReturnsFalse_WhenSourceIsNull()
        {
            IList<int> grid = null;

            bool result = grid.TryAt2D(
                0, 0, 1, 1, out int value);

            Assert.IsFalse(result);
            Assert.AreEqual(default(int), value);
        }

        [Test]
        public void TryAt3D_ReturnsTrue_WhenInBounds()
        {
            var grid = new List<int>
            {
                1, 2,
                3, 4,

                5, 6,
                7, 8
            };

            bool result = grid.TryAt3D(
                x: 0,
                y: 1,
                z: 1,
                width: 2,
                height: 2,
                depth: 2,
                out int value);

            Assert.IsTrue(result);
            Assert.AreEqual(7, value);
        }

        [Test]
        public void TryAt3D_ReturnsFalse_WhenOutOfBounds()
        {
            var grid = new List<int>(new int[8]);

            bool result = grid.TryAt3D(
                0, 0, -1,
                2, 2, 2,
                out int value);

            Assert.IsFalse(result);
            Assert.AreEqual(default(int), value);
        }

        [Test]
        public void TryAt3D_ReturnsFalse_WhenSourceIsNull()
        {
            IList<int> grid = null;

            bool result = grid.TryAt3D(
                0, 0, 0,
                1, 1, 1,
                out int value);

            Assert.IsFalse(result);
            Assert.AreEqual(default(int), value);
        }

    }
}
