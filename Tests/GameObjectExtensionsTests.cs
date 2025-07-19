using NUnit.Framework;
using UnityEngine;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class GameObjectExtensionsTests
    {
        private GameObject parent;
        private GameObject child;
        private GameObject grandChild;

        [SetUp]
        public void SetUp()
        {
            parent = new GameObject("Parent");
            child = new GameObject("Child");
            grandChild = new GameObject("GrandChild");

            child.transform.parent = parent.transform;
            grandChild.transform.parent = child.transform;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(parent);
        }

        [Test]
        public void GetOrAddComponent_ReturnsExistingComponent()
        {
            var existing = parent.AddComponent<Rigidbody>();
            var result = parent.GetOrAddComponent<Rigidbody>();

            Assert.AreSame(existing, result);
        }

        [Test]
        public void GetOrAddComponent_AddsComponentIfMissing()
        {
            Assert.IsFalse(parent.TryGetComponent<Collider>(out _));

            var result = parent.GetOrAddComponent<BoxCollider>();

            Assert.IsNotNull(result);
            Assert.IsTrue(parent.TryGetComponent<BoxCollider>(out _));
        }

        [Test]
        public void HasComponent_ReturnsTrue_IfComponentExists()
        {
            parent.AddComponent<BoxCollider>();

            Assert.IsTrue(parent.HasComponent<BoxCollider>());
        }

        [Test]
        public void HasComponent_ReturnsFalse_IfComponentMissing()
        {
            Assert.IsFalse(parent.HasComponent<Rigidbody>());
        }

        [Test]
        public void FindChild_ReturnsCorrectGameObject_Recursively()
        {
            var result = parent.FindChild("GrandChild");

            Assert.IsNotNull(result);
            Assert.AreEqual("GrandChild", result.name);
        }

        [Test]
        public void FindChild_ReturnsNull_IfNotFound()
        {
            var result = parent.FindChild("NonExistent");

            Assert.IsNull(result);
        }

        [Test]
        public void DestroyAllChildren_DestroysAllChildGameObjects()
        {
            Assert.AreEqual(1, parent.transform.childCount);

            parent.DestroyAllChildren();

            Assert.AreEqual(0, parent.transform.childCount);
        }

        [Test]
        public void SetLayerRecursively_SetsLayerToAllChildren()
        {
            int targetLayer = 8;

            parent.SetLayerRecursively(targetLayer);

            Assert.AreEqual(targetLayer, parent.layer);
            Assert.AreEqual(targetLayer, child.layer);
            Assert.AreEqual(targetLayer, grandChild.layer);
        }

        [Test]
        public void GetComponentsInChildrenWithoutSelf_ExcludesParent()
        {
            parent.AddComponent<BoxCollider>();
            child.AddComponent<BoxCollider>();
            grandChild.AddComponent<BoxCollider>();

            var components = parent.GetComponentsInChildrenWithoutSelf<BoxCollider>();

            Assert.AreEqual(2, components.Count);
            Assert.IsFalse(components.Contains(parent.GetComponent<BoxCollider>()));
        }
    }
}
