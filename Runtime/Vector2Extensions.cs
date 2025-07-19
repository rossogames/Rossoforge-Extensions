using UnityEngine;

namespace Rossoforge.Extensions
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

            return new Vector2(
              (cos * v.x) - (sin * v.y),
              (sin * v.x) + (cos * v.y)
          );
        }
        /// <summary>
        /// Rotate de vector around pivot
        /// </summary>
        /// <param name="v">current vector</param>
        /// <param name="pivot">rotation pivot</param>
        /// <param name="degrees">degrees to rotate</param>
        /// <returns></returns>
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
            return new Vector2(v.x * scale, v.y * scale);
        }
        /// <summary>
        /// Distance between the current vector and the target verctor
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
        /// Angle in degrees between the two vectors
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
        /// <param name="target">The vector to compute the dot product with.</param>
        /// <returns></returns>
        public static float Dot(this Vector2 v, Vector2 target)
        {
            return Vector2.Dot(v, target);
        }
        /// <summary>
        /// Computes the 2D cross product (also known as the perp-dot product) between this vector and the target vector.
        /// This returns a scalar value equal to (v.x * target.y) - (v.y * target.x).
        /// The sign indicates the orientation: positive if the target vector is to the left (counter-clockwise),
        /// negative if to the right (clockwise), and zero if the vectors are colinear.
        /// </summary>
        /// <param name="v">The first vector.</param>
        /// <param name="target">The second vector to compute the cross product with.</param>
        /// <returns>A signed scalar representing the magnitude and orientation of the cross product.</returns>
        public static float Cross(this Vector2 v, Vector2 target)
        {
            return (v.x * target.y) - (v.y * target.x);
        }
        /// <summary>
        /// Returns a copy of this vector with the X component replaced by the specified value.
        /// </summary>
        /// <param name="v">The current vector.</param>
        /// <param name="x">The new X value.</param>
        /// <returns>A new vector with the updated X component.</returns>
        public static Vector2 WithX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }
        /// <summary>
        /// Returns a copy of this vector with the Y component replaced by the specified value.
        /// </summary>
        /// <param name="v">The current vector.</param>
        /// <param name="y">The new Y value.</param>
        /// <returns>A new vector with the updated Y component.</returns>
        public static Vector2 WithY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }
        /// <summary>
        /// Returns the projection of this vector onto the target vector.
        /// </summary>
        /// <param name="v">The current vector.</param>
        /// <param name="target">The vector to project onto.</param>
        /// <returns>A new vector representing the projection.</returns>
        public static Vector2 ProjectOn(this Vector2 v, Vector2 target)
        {
            return Vector2.Dot(v, target) / target.sqrMagnitude * target;
        }
        /// <summary>
        /// Returns the reflection of this vector off the plane defined by the given normal.
        /// </summary>
        /// <param name="v">The current vector.</param>
        /// <param name="normal">The normal vector of the plane to reflect off. Must be normalized.</param>
        /// <returns>A new vector representing the reflection.</returns>
        public static Vector2 Reflect(this Vector2 v, Vector2 normal)
        {
            return v - 2 * Vector2.Dot(v, normal) * normal;
        }
        /// <summary>
        /// Converts this Vector2 to a Vector3 with the specified Z component.
        /// </summary>
        /// <param name="v">The current vector.</param>
        /// <param name="z">The Z component to use.</param>
        /// <returns>A Vector3 with X, Y from this vector and the specified Z.</returns>
        public static Vector3 ToVector3(this Vector2 v, float z = 0f)
        {
            return new Vector3(v.x, v.y, z);
        }
    }
}