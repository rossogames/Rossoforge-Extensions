using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// </summary>
        /// <param name="vector">vector to Clamp</param>
        /// <param name="min">The minimum floating point value to compare against.</param>
        /// <param name="max">The maximum floating point value to compare against.</param>
        /// <returns>Returns the given value if it is within the minimum and maximum range.</returns>
        public static Vector2 Clamp(this Vector2 vector, float min, float max)
        {
            return new Vector2(
                Mathf.Clamp(vector.x, min, max),
                Mathf.Clamp(vector.y, min, max)
            );
        }
        /// <summary>
        /// Rotate de vector around the axis 0
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="degrees">degrees to rotate</param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }

        public static Vector2 RotateAround(this Vector2 v, Vector2 pivot, float degrees)
        {
            return (v - pivot).Rotate(degrees) + pivot;
        }
        /// <summary>
        /// Apply a scale to the vector
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="scale">scale to apply</param>
        /// <returns></returns>
        public static Vector2 Scale(this Vector2 v, float scale)
        {
            v.x *= scale;
            v.y *= scale;
            return v;
        }

        /// <summary>
        /// Apply a scale to the vector
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="scale">scale to apply</param>
        /// <returns></returns>
        public static Vector2 Scale(this Vector2 v, Vector2 scale)
        {
            v.x *= scale.x;
            v.y *= scale.y;
            return v;
        }

        /// <summary>
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="target">Target vector</param>
        /// <returns>Returns the distance between the current vector and the target verctor</returns>
        public static float Distance(this Vector2 v, Vector2 target)
        {
            return Vector2.Distance(v, target);
        }

        /// <summary>
        ///The unsigned angle in degrees between the two vectors.
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="target">The vector to which the angular difference is measured.</param>
        /// <returns></returns>
        public static float SqrDistance(this Vector2 v, Vector2 target)
        {
            return Vector2.SqrMagnitude(v - target);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="target">The vector to which the angular difference is measured.</param>
        /// <returns>The unsigned angle in degrees between the two vectors.</returns>
        public static float Angle(this Vector2 v, Vector2 target)
        {
            return Vector2.Angle(v, target);
        }

        /// <summary>
        /// Dot Product of two vectors.
        /// </summary>
        /// <param name="v">current vector</param>
        /// <returns></returns>
        public static float Dot(this Vector2 v, Vector2 target)
        {
            return Vector2.Dot(v, target);
        }

        public static float Cross(this Vector2 v, Vector2 target)
        {
            return (v.x * target.y) - (v.y * target.x);
        }
    }
}