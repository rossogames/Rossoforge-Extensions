using NUnit.Framework;
using UnityEngine;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class LayerMaskExtensionsTests
    {
        [Test]
        public void ContainsLayer_ReturnsTrue_IfLayerIsInMask()
        {
            var mask = 1 << 3; // only layer 3
            Assert.IsTrue(((LayerMask)mask).ContainsLayer(3));
        }

        [Test]
        public void ContainsLayer_ReturnsFalse_IfLayerIsNotInMask()
        {
            var mask = 1 << 2; // only layer 2
            Assert.IsFalse(((LayerMask)mask).ContainsLayer(3));
        }

        [Test]
        public void AddLayer_AddsLayerToMask()
        {
            var mask = 1 << 1; // layer 1
            var newMask = ((LayerMask)mask).AddLayer(4); // add layer 4
            Assert.IsTrue(newMask.ContainsLayer(1));
            Assert.IsTrue(newMask.ContainsLayer(4));
        }

        [Test]
        public void RemoveLayer_RemovesLayerFromMask()
        {
            var mask = (1 << 1) | (1 << 4); // layers 1 and 4
            var newMask = ((LayerMask)mask).RemoveLayer(4);
            Assert.IsTrue(newMask.ContainsLayer(1));
            Assert.IsFalse(newMask.ContainsLayer(4));
        }

        [Test]
        public void ToLayerIndices_ReturnsCorrectIndices()
        {
            var mask = (1 << 0) | (1 << 5) | (1 << 10); // layers 0, 5, 10
            var indices = ((LayerMask)mask).ToLayerIndices();
            CollectionAssert.AreEquivalent(new[] { 0, 5, 10 }, indices);
        }

        [Test]
        public void ToLayerNames_ReturnsCorrectNames()
        {
            // Set up some dummy layer names (Unity does not let you modify layer names at runtime).
            // So we test against built-in Unity layer 0: "Default"
            var mask = 1 << 0;
            var names = ((LayerMask)mask).ToLayerNames();
            CollectionAssert.Contains(names, "Default");
        }

        [Test]
        public void ToLayerNames_IgnoresUnnamedLayers()
        {
            var unnamedLayer = 31; // usually unused
            var mask = 1 << unnamedLayer;
            var names = ((LayerMask)mask).ToLayerNames();
            Assert.IsEmpty(names); // should skip unnamed layer
        }
    }
}
