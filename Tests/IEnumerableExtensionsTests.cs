using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class IEnumerableExtensionsTests
    {
        [Test]
        public void ChunkToList_SplitsCorrectly()
        {
            var source = Enumerable.Range(1, 10);
            var result = source.ChunkToList(3);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(new[] { 1, 2, 3 }, result[0]);
            Assert.AreEqual(new[] { 10 }, result[3]);
        }

        [Test]
        public void ChunkToArray_SplitsCorrectly()
        {
            var source = Enumerable.Range(1, 10);
            var result = source.ChunkToArray(4);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, result[0]);
            Assert.AreEqual(new[] { 9, 10 }, result[2]);
        }

        [Test]
        public void Chunk_InvalidChunkSize_Throws()
        {
            var source = Enumerable.Range(1, 5);
            Assert.Throws<ArgumentOutOfRangeException>(() => source.ChunkToList(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => source.ChunkToArray(-1));
        }

        [Test]
        public void ForEach_ExecutesOnAllElements()
        {
            var list = new int[] { 1, 2, 3 };
            var result = new List<int>();
            list.ForEach(x => result.Add(x * 2));

            CollectionAssert.AreEqual(new[] { 2, 4, 6 }, result);
        }

        [Test]
        public void ForEach_WithIndex_WorksCorrectly()
        {
            var list = new string[] { "a", "b", "c" };
            var output = new List<string>();
            list.ForEach((x, i) => output.Add($"{i}:{x}"));

            CollectionAssert.AreEqual(new[] { "0:a", "1:b", "2:c" }, output);
        }

        [Test]
        public void IsEmpty_ReturnsTrueOnlyWhenEmpty()
        {
            Assert.IsTrue(new int[0].IsEmpty());
            Assert.IsFalse(new[] { 1 }.IsEmpty());
        }

        [Test]
        public void IsNotEmpty_ReturnsTrueOnlyWhenNotEmpty()
        {
            Assert.IsFalse(new int[0].IsNotEmpty());
            Assert.IsTrue(new[] { 1 }.IsNotEmpty());
        }

        [Test]
        public void WhereNotNull_Class_ReturnsOnlyNonNull()
        {
            string[] source = { "a", null, "b" };
            var result = source.WhereNotNull().ToList();
            CollectionAssert.AreEqual(new[] { "a", "b" }, result);
        }

        [Test]
        public void WhereNotNull_Struct_ReturnsOnlyNonNull()
        {
            int?[] source = { 1, null, 3 };
            var result = source.WhereNotNull().ToList();
            CollectionAssert.AreEqual(new[] { 1, 3 }, result);
        }

        [Test]
        public void Shuffle_ReturnsSameItemsInDifferentOrder()
        {
            var source = Enumerable.Range(1, 100).ToList();
            var shuffled = source.Shuffle(new System.Random(42));

            Assert.AreEqual(source.Count, shuffled.Count);
            CollectionAssert.AreEquivalent(source, shuffled);
            Assert.AreNotEqual(source, shuffled); // Usually not the same order
        }

        [Test]
        public void RandomElement_ReturnsElement()
        {
            var list = new List<string> { "a", "b", "c" };
            var result = list.RandomElement(new System.Random(0));

            Assert.Contains(result, list);
        }

        [Test]
        public void RandomElement_Empty_Throws()
        {
            var list = new List<int>();
            Assert.Throws<InvalidOperationException>(() => list.RandomElement());
        }

        [Test]
        public void Choose_ValidNumber_ReturnsUniqueRandomElements()
        {
            var source = Enumerable.Range(1, 10);
            var chosen = source.Choose(3, new System.Random(0));

            Assert.AreEqual(3, chosen.Count);
            Assert.IsTrue(chosen.Distinct().Count() == 3);
            CollectionAssert.IsSubsetOf(chosen, source);
        }

        [Test]
        public void Choose_TooMany_Throws()
        {
            var source = new[] { "a", "b" };
            Assert.Throws<ArgumentException>(() => source.Choose(3));
        }

        [Test]
        public void Choose_Negative_Throws()
        {
            var source = new[] { "x", "y", "z" };
            Assert.Throws<ArgumentOutOfRangeException>(() => source.Choose(-1));
        }
    }
}
