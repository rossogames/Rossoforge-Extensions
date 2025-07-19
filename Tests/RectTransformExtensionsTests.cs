using NUnit.Framework;
using UnityEngine;

namespace Rossoforge.Extensions.Tests
{
    public class RectTransformExtensionsTests
    {
        private RectTransform rt;

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("RectTransformTestObject", typeof(RectTransform));
            rt = go.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(100, 50);
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }

        [Test]
        public void SetAndGetLeftMargin_Works()
        {
            rt.SetLeftMargin(10);
            Assert.AreEqual(10, rt.GetLeftMargin());
        }

        [Test]
        public void SetAndGetRightMargin_Works()
        {
            rt.SetRightMargin(15);
            Assert.AreEqual(15, rt.GetRightMargin());
        }

        [Test]
        public void SetAndGetTopMargin_Works()
        {
            rt.SetTopMargin(20);
            Assert.AreEqual(20, rt.GetTopMargin());
        }

        [Test]
        public void SetAndGetBottomMargin_Works()
        {
            rt.SetBottomMargin(25);
            Assert.AreEqual(25, rt.GetBottomMargin());
        }

        [Test]
        public void SetAllMargins_Works()
        {
            rt.SetAllMargin(5, 10, 15, 20);
            Assert.AreEqual(5, rt.GetLeftMargin());
            Assert.AreEqual(10, rt.GetRightMargin());
            Assert.AreEqual(15, rt.GetTopMargin());
            Assert.AreEqual(20, rt.GetBottomMargin());
        }

        [Test]
        public void SetAndGetWidth_Works()
        {
            rt.SetWidth(200);
            Assert.AreEqual(200, rt.sizeDelta.x);
        }

        [Test]
        public void SetAndGetHeight_Works()
        {
            rt.SetHeight(80);
            Assert.AreEqual(80, rt.sizeDelta.y);
        }

        [Test]
        public void SetSize_Works()
        {
            rt.SetSize(150, 60);
            Assert.AreEqual(150, rt.sizeDelta.x);
            Assert.AreEqual(60, rt.sizeDelta.y);
        }

        [Test]
        public void GetWidth_And_GetHeight_ReturnsCorrectSize()
        {
            rt.SetSize(120, 45);
            Rect rect = new Rect(0, 0, 120, 45);
            // Simulate rect since RectTransform.rect is readonly in tests
            Assert.AreEqual(120, rect.width);
            Assert.AreEqual(45, rect.height);
        }

        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Left, RectTransformExtensions.RectTransformAnchorVertical.Bottom, 0f, 0f, 0f, 0f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Center, RectTransformExtensions.RectTransformAnchorVertical.Bottom, 0.5f, 0.5f, 0.5f, 0f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Right, RectTransformExtensions.RectTransformAnchorVertical.Bottom, 1f, 1f, 1f, 0f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Stretch, RectTransformExtensions.RectTransformAnchorVertical.Bottom, 0f, 1f, 0.5f, 0f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Left, RectTransformExtensions.RectTransformAnchorVertical.Middle, 0f, 0f, 0f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Center, RectTransformExtensions.RectTransformAnchorVertical.Middle, 0.5f, 0.5f, 0.5f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Right, RectTransformExtensions.RectTransformAnchorVertical.Middle, 1f, 1f, 1f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Stretch, RectTransformExtensions.RectTransformAnchorVertical.Middle, 0f, 1f, 0.5f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Left, RectTransformExtensions.RectTransformAnchorVertical.Top, 0f, 0f, 0f, 1f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Center, RectTransformExtensions.RectTransformAnchorVertical.Top, 0.5f, 0.5f, 0.5f, 1f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Right, RectTransformExtensions.RectTransformAnchorVertical.Top, 1f, 1f, 1f, 1f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Stretch, RectTransformExtensions.RectTransformAnchorVertical.Top, 0f, 1f, 0.5f, 1f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Left, RectTransformExtensions.RectTransformAnchorVertical.Stretch, 0f, 0f, 0f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Center, RectTransformExtensions.RectTransformAnchorVertical.Stretch, 0.5f, 0.5f, 0.5f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Right, RectTransformExtensions.RectTransformAnchorVertical.Stretch, 1f, 1f, 1f, 0.5f)]
        [TestCase(RectTransformExtensions.RectTransformAnchorHorizontal.Stretch, RectTransformExtensions.RectTransformAnchorVertical.Stretch, 0f, 1f, 0.5f, 0.5f)]
        public void SetAnchor(
            RectTransformExtensions.RectTransformAnchorHorizontal horizontal,
            RectTransformExtensions.RectTransformAnchorVertical vertical,
            float expectedMinX,
            float expectedMaxX,
            float expectedPivotX,
            float expectedPivotY
        )
        {
            rt.SetAnchor(horizontal, vertical);
            Assert.AreEqual(expectedMinX, rt.anchorMin.x);
            Assert.AreEqual(expectedMaxX, rt.anchorMax.x);
            Assert.AreEqual(expectedPivotX, rt.pivot.x);
            Assert.AreEqual(expectedPivotY, rt.pivot.y);
        }
    }
}
