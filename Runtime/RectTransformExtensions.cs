using UnityEngine;

namespace Rossoforge.Extensions
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
            float anchorMinX, anchorMaxX, pivotX;
            float anchorMinY, anchorMaxY, pivotY;

            // Horizontal
            switch (anchorHorizontal)
            {
                case RectTransformAnchorHorizontal.LEFT:
                    anchorMinX = 0f;
                    anchorMaxX = 0f;
                    pivotX = 0f;
                    break;
                case RectTransformAnchorHorizontal.CENTER:
                    anchorMinX = 0.5f;
                    anchorMaxX = 0.5f;
                    pivotX = 0.5f;
                    break;
                case RectTransformAnchorHorizontal.RIGHT:
                    anchorMinX = 1f;
                    anchorMaxX = 1f;
                    pivotX = 1f;
                    break;
                case RectTransformAnchorHorizontal.STRETCH:
                    anchorMinX = 0f;
                    anchorMaxX = 1f;
                    pivotX = 0.5f;
                    break;
                default:
                    anchorMinX = anchorMaxX = pivotX = 0.5f;
                    break;
            }

            // Vertical
            switch (anchorVertical)
            {
                case RectTransformAnchorVertical.BOTTOM:
                    anchorMinY = 0f;
                    anchorMaxY = 0f;
                    pivotY = 0f;
                    break;
                case RectTransformAnchorVertical.MIDDLE:
                    anchorMinY = 0.5f;
                    anchorMaxY = 0.5f;
                    pivotY = 0.5f;
                    break;
                case RectTransformAnchorVertical.TOP:
                    anchorMinY = 1f;
                    anchorMaxY = 1f;
                    pivotY = 1f;
                    break;
                case RectTransformAnchorVertical.STRETCH:
                    anchorMinY = 0f;
                    anchorMaxY = 1f;
                    pivotY = 0.5f;
                    break;
                default:
                    anchorMinY = anchorMaxY = pivotY = 0.5f;
                    break;
            }

            rt.anchorMin = new Vector2(anchorMinX, anchorMinY);
            rt.anchorMax = new Vector2(anchorMaxX, anchorMaxY);
            rt.pivot = new Vector2(pivotX, pivotY);
        }

        public enum RectTransformAnchorHorizontal
        {
            LEFT,
            CENTER,
            RIGHT,
            STRETCH
        }

        public enum RectTransformAnchorVertical
        {
            TOP,
            MIDDLE,
            BOTTOM,
            STRETCH
        }
    }
}

