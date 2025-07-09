using NUnit.Framework;
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
    }
}
