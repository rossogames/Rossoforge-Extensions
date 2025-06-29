using UnityEngine;

namespace RossoForge.Extensions
{
    public static class RectExtensions
    {
        /// <summary>
        /// Checks whether the specified point (x, y) is inside the rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to test against.</param>
        /// <param name="x">X coordinate of the point.</param>
        /// <param name="y">Y coordinate of the point.</param>
        /// <returns>True if the point is inside the rectangle.</returns>
        public static bool Contains(this Rect rect, float x, float y)
        {
            return
                x >= rect.xMin &&
                x < rect.xMax &&
                y >= rect.yMin &&
                y < rect.yMax;
        }

        /// <summary>
        /// Checks whether the specified point (x, y) is inside the rectangle,
        /// </summary>
        /// <param name="rect">The rectangle to test against.</param>
        /// <param name="x">X coordinate of the point.</param>
        /// <param name="y">Y coordinate of the point.</param>
        /// <param name="allowInverse">
        /// If true, supports rectangles with negative width or height.
        /// </param>
        /// <returns>True if the point is inside the rectangle.</returns>
        public static bool Contains(this Rect rect, float x, float y, bool allowInverse)
        {
            if (!allowInverse)
            {
                return Contains(rect, x, y);
            }
            else
            {
                bool xInRange;
                if (rect.width >= 0)
                    xInRange = (x >= rect.xMin && x < rect.xMax);
                else
                    xInRange = (x >= rect.xMax && x < rect.xMin);

                bool yInRange;
                if (rect.height >= 0)
                    yInRange = (y >= rect.yMin && y < rect.yMax);
                else
                    yInRange = (y >= rect.yMax && y < rect.yMin);

                return xInRange && yInRange;
            }
        }

        /// <summary>
        /// Clamps the point so that it stays inside the rectangle.
        /// </summary>
        public static Vector2 ClampPoint(this Rect rect, Vector2 point)
        {
            float clampedX = Mathf.Clamp(point.x, rect.xMin, rect.xMax);
            float clampedY = Mathf.Clamp(point.y, rect.yMin, rect.yMax);
            return new Vector2(clampedX, clampedY);
        }

        /// <summary>
        /// Returns the bottom-left corner of the rectangle.
        /// </summary>
        public static Vector2 BottomLeft(this Rect rect)
        {
            return new Vector2(rect.xMin, rect.yMin);
        }

        /// <summary>
        /// Returns the bottom-right corner of the rectangle.
        /// </summary>
        public static Vector2 BottomRight(this Rect rect)
        {
            return new Vector2(rect.xMax, rect.yMin);
        }

        /// <summary>
        /// Returns the top-left corner of the rectangle.
        /// </summary>
        public static Vector2 TopLeft(this Rect rect)
        {
            return new Vector2(rect.xMin, rect.yMax);
        }

        /// <summary>
        /// Returns the top-right corner of the rectangle.
        /// </summary>
        public static Vector2 TopRight(this Rect rect)
        {
            return new Vector2(rect.xMax, rect.yMax);
        }
    }
}

