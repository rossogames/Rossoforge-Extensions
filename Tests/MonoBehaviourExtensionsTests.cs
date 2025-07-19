using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Rossoforge.Extensions.Tests
{
    [TestFixture]
    public class MonoBehaviourExtensionsTests
    {
        private GameObject testObject;
        private TestMonoBehaviour testComponent;

        // Clase auxiliar para extender MonoBehaviour en los tests
        private class TestMonoBehaviour : MonoBehaviour { }

        [SetUp]
        public void SetUp()
        {
            testObject = new GameObject("TestObject");
            testComponent = testObject.AddComponent<TestMonoBehaviour>();
        }

        [TearDown]
        public void TearDown()
        {
            if (testObject != null)
                Object.DestroyImmediate(testObject);
        }

        [Test]
        public void ActivateGameObject_SetsActiveTrue()
        {
            testObject.SetActive(false);
            testComponent.ActivateGameObject();
            Assert.IsTrue(testObject.activeSelf);
        }

        [Test]
        public void DeactivateGameObject_SetsActiveFalse()
        {
            testObject.SetActive(true);
            testComponent.DeactivateGameObject();
            Assert.IsFalse(testObject.activeSelf);
        }

        [UnityTest]
        public IEnumerator DestroySelf_Immediately_DestroysGameObject()
        {
            testComponent.DestroySelf();
            yield return null; // Wait a frame for Destroy to take effect
            Assert.IsTrue(testComponent == null || testObject == null);
        }
    }
}
