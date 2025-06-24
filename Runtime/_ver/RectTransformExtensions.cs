using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class RectTransformExtensions
    {
        public static void SetLeftMargin(this RectTransform rt, float value) => rt.offsetMin = new Vector2(value, rt.offsetMin.y);
        public static void SetRightMargin(this RectTransform rt, float value) => rt.offsetMax = new Vector2(-value, rt.offsetMax.y);
        public static void SetTopMargin(this RectTransform rt, float value) => rt.offsetMax = new Vector2(rt.offsetMax.x, -value);
        public static void SetBottomMargin(this RectTransform rt, float value) => rt.offsetMin = new Vector2(rt.offsetMin.x, value);
        public static void SetAllMargin(this RectTransform rt, float left, float right, float top, float bottom)
        {
            rt.SetLeftMargin(left);
            rt.SetRightMargin(right);
            rt.SetTopMargin(top);
            rt.SetBottomMargin(bottom);
        }
        public static void SetWidth(this RectTransform rt, float width) => rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
        public static void SetHeight(this RectTransform rt, float height) => rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
        public static void SetSize(this RectTransform rt, float width, float height) => rt.sizeDelta = new Vector2(width, height);

        public static float GetLeftMargin(this RectTransform rt) => rt.offsetMin.x;
        public static float GetRightMargin(this RectTransform rt) => -rt.offsetMax.x;
        public static float GetTopMargin(this RectTransform rt) => -rt.offsetMax.y;
        public static float GetBottomMargin(this RectTransform rt) => rt.offsetMin.y;
        public static float GetWidth(this RectTransform rt) => rt.rect.max.x - rt.rect.min.x;
        public static float GetHeight(this RectTransform rt) => rt.rect.max.y - rt.rect.min.y;

        public static void SetAnchor(this RectTransform rt, RectTransformAnchorHorizontal anchorHorizontal, RectTransformAnchorVertical anchorVertical)
        {
            float anchorMinX =
                anchorHorizontal == RectTransformAnchorHorizontal.LEFT ? 0 :
                anchorHorizontal == RectTransformAnchorHorizontal.CENTER ? 0.5f :
                anchorHorizontal == RectTransformAnchorHorizontal.RIGHT ? 1 :
                0;

            float anchorMinY =
                anchorVertical == RectTransformAnchorVertical.TOP ? 1 :
                anchorVertical == RectTransformAnchorVertical.MIDDLE ? 0.5f :
                anchorVertical == RectTransformAnchorVertical.BOTTOM ? 0 :
                0;

            float anchorMaxX =
                anchorHorizontal == RectTransformAnchorHorizontal.LEFT ? 0 :
                anchorHorizontal == RectTransformAnchorHorizontal.CENTER ? 0.5f :
                anchorHorizontal == RectTransformAnchorHorizontal.RIGHT ? 1 :
                1;

            float anchorMaxY =
                anchorVertical == RectTransformAnchorVertical.TOP ? 1 :
                anchorVertical == RectTransformAnchorVertical.MIDDLE ? 0.5f :
                anchorVertical == RectTransformAnchorVertical.BOTTOM ? 0 :
                1;

            float pivotX =
                anchorHorizontal == RectTransformAnchorHorizontal.LEFT ? 0 :
                anchorHorizontal == RectTransformAnchorHorizontal.CENTER ? 0.5f :
                anchorHorizontal == RectTransformAnchorHorizontal.RIGHT ? 1 :
                0.5f;

            float pivotY =
                anchorVertical == RectTransformAnchorVertical.TOP ? 1 :
                anchorVertical == RectTransformAnchorVertical.MIDDLE ? 0.5f :
                anchorVertical == RectTransformAnchorVertical.BOTTOM ? 0 :
                0.5f;

            rt.anchorMin = new Vector2(anchorMinX, anchorMinY);
            rt.anchorMax = new Vector2(anchorMaxX, anchorMaxY);
            rt.pivot = new Vector2(pivotX, pivotY);
        }
    }
}

