using NUnit.Framework;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TestTools;

namespace Rossoforge.Extensions.Tests
{
    public class TransformExtensionsTests
    {
        private GameObject go;
        private Transform t;

        [SetUp]
        public void SetUp()
        {
            go = new GameObject("TestObject");
            t = go.transform;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(go);
        }

        // POSITION
        [Test] 
        public void SetPositionX_Works() 
        { 
            t.SetPositionX(5); 
            Assert.AreEqual(5, t.position.x); 
        }
        [Test] 
        public void SetPositionY_Works() 
        { 
            t.SetPositionY(3); 
            Assert.AreEqual(3, t.position.y); 
        }
        [Test] 
        public void SetPositionZ_Works() 
        { 
            t.SetPositionZ(-2); 
            Assert.AreEqual(-2, t.position.z); 
        }
        [Test] 
        public void ResetPosition_Works() 
        {
            t.position = Vector3.one; 
            t.ResetPosition(); 
            Assert.AreEqual(Vector3.zero, t.position); 
        }

        // LOCAL POSITION
        [Test] 
        public void SetLocalPositionX_Works() 
        { 
            t.SetLocalPositionX(1); 
            Assert.AreEqual(1, t.localPosition.x); 
        }
        [Test] 
        public void SetLocalPositionY_Works() 
        { 
            t.SetLocalPositionY(2); 
            Assert.AreEqual(2, t.localPosition.y); 
        }
        [Test] 
        public void SetLocalPositionZ_Works() 
        { 
            t.SetLocalPositionZ(3); 
            Assert.AreEqual(3, t.localPosition.z); 
        }
        [Test] 
        public void ResetLocalPosition_Works() 
        { 
            t.localPosition = Vector3.one; 
            t.ResetLocalPosition(); 
            Assert.AreEqual(Vector3.zero, t.localPosition); 
        }

        // SCALE
        [Test] 
        public void SetLocalScaleX_Works() 
        { 
            t.SetLocalScaleX(2); 
            Assert.AreEqual(2, t.localScale.x); 
        }
        [Test] 
        public void SetLocalScaleY_Works() 
        { 
            t.SetLocalScaleY(3); 
            Assert.AreEqual(3, t.localScale.y); 
        }
        [Test] 
        public void SetLocalScaleZ_Works() 
        { 
            t.SetLocalScaleZ(4); 
            Assert.AreEqual(4, t.localScale.z); 
        }
        [Test] 
        public void ResetLocalScale_Works() 
        { 
            t.localScale = Vector3.one * 5; 
            t.ResetLocalScale(); 
            Assert.AreEqual(Vector3.zero, t.localScale); 
        }

        // ROTATION (Euler angles)
        [Test] 
        public void SetRotationX_Works() 
        { 
            t.eulerAngles = Vector3.zero; 
            t.SetRotationX(45); 
            Assert.AreEqual(45, t.eulerAngles.x, 0.01f);
        }
        [Test] 
        public void SetRotationY_Works() 
        { 
            t.eulerAngles = Vector3.zero; 
            t.SetRotationY(30); 
            Assert.AreEqual(30, t.eulerAngles.y, 0.01f);
        }
        [Test] 
        public void SetRotationZ_Works() 
        { 
            t.eulerAngles = Vector3.zero; 
            t.SetRotationZ(90); 
            Assert.AreEqual(90, t.eulerAngles.z, 0.01f);
        }
        [Test] 
        public void RotateX_Works() 
        { 
            float before = t.eulerAngles.x; 
            t.RotateX(45); 
            Assert.AreEqual(before + 45, t.eulerAngles.x, 0.01f); 
        }
        [Test] 
        public void RotateY_Works() 
        { 
            float before = t.eulerAngles.y; 
            t.RotateY(45); 
            Assert.AreEqual(before + 45, t.eulerAngles.y, 0.01f); 
        }
        [Test] 
        public void RotateZ_Works() 
        { 
            float before = t.eulerAngles.z; 
            t.RotateZ(45); 
            Assert.AreEqual(before + 45, t.eulerAngles.z, 0.01f); 
        }
        [Test] 
        public void ResetRotation_Works() 
        { 
            t.rotation = Quaternion.Euler(10, 20, 30); 
            t.ResetRotation(); 
            Assert.AreEqual(Quaternion.identity, t.rotation); 
        }

        // LOCAL ROTATION
        [Test] 
        public void SetLocalRotationX_Works() 
        { 
            t.localEulerAngles = Vector3.zero; 
            t.SetLocalRotationX(15); 
            Assert.AreEqual(15, t.localEulerAngles.x, 0.01f); 
        }
        [Test] 
        public void SetLocalRotationY_Works() 
        { 
            t.localEulerAngles = Vector3.zero; 
            t.SetLocalRotationY(25); 
            Assert.AreEqual(25, t.localEulerAngles.y, 0.01f);
        }
        [Test] 
        public void SetLocalRotationZ_Works() 
        { 
            t.localEulerAngles = Vector3.zero; 
            t.SetLocalRotationZ(35); 
            Assert.AreEqual(35, t.localEulerAngles.z, 0.01f);
        }
        [Test] 
        public void RotateLocalX_Works() 
        { 
            float before = t.localEulerAngles.x; 
            t.RotateLocalX(15); 
            Assert.AreEqual(before + 15, t.localEulerAngles.x, 0.01f); 
        }
        [Test] 
        public void RotateLocalY_Works() 
        {
            float before = t.localEulerAngles.y; 
            t.RotateLocalY(25); 
            Assert.AreEqual(before + 25, t.localEulerAngles.y, 0.01f); 
        }
        [Test] 
        public void RotateLocalZ_Works() 
        { 
            float before = t.localEulerAngles.z; 
            t.RotateLocalZ(35); 
            Assert.AreEqual(before + 35, t.localEulerAngles.z, 0.01f); 
        }
        [Test] 
        public void ResetLocalRotation_Works() 
        { 
            t.localRotation = Quaternion.Euler(10, 20, 30); 
            t.ResetLocalRotation(); 
            Assert.AreEqual(Quaternion.identity, t.localRotation); 
        }

        // ResetLocal
        [Test]
        public void ResetLocal_Works()
        {
            t.localPosition = Vector3.one * 2;
            t.localRotation = Quaternion.Euler(45, 90, 180);
            t.localScale = Vector3.one * 5;
            t.ResetLocal();
            Assert.AreEqual(Vector3.zero, t.localPosition);
            Assert.AreEqual(Quaternion.identity, t.localRotation);
            Assert.AreEqual(Vector3.one, t.localScale);
        }

        // CHILD UTILS
        [Test]
        public void SetLayerRecursively_Works()
        {
            var child = new GameObject("Child");
            child.transform.SetParent(t);
            t.SetLayerRecursively(8);
            Assert.AreEqual(8, go.layer);
            Assert.AreEqual(8, child.layer);
            Object.DestroyImmediate(child);
        }

        [Test]
        public void GetChildren_OnlyActive()
        {
            var c1 = new GameObject("C1");
            c1.transform.SetParent(t);
            c1.SetActive(false);

            var children = t.GetChildren(false);
            Assert.AreEqual(0, children.Length);
            Object.DestroyImmediate(c1);
        }

        [Test]
        public void GetChildren_IncludeInactives()
        {
            var c1 = new GameObject("C1");
            c1.transform.SetParent(t);
            c1.SetActive(false);

            var c2 = new GameObject("C2");
            c2.transform.SetParent(t);

            var children = t.GetChildren(true);
            Assert.AreEqual(2, children.Length);
            Object.DestroyImmediate(c1.gameObject);
            Object.DestroyImmediate(c2.gameObject);
        }

        [Test]
        public void DestroyChildren_RemovesAllChildren()
        {
            var c1 = new GameObject("C1");
            c1.transform.SetParent(t);
            t.DestroyChildren();
            Assert.AreEqual(0, t.childCount);
        }
    }
}
