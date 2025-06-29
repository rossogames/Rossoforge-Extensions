using UnityEngine;

namespace RossoForge.Extensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Clamps each component of this vector between the given minimum and maximum values.
        /// </summary>
        public static Vector3 Clamp(this Vector3 vector, float min, float max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min, max),
                Mathf.Clamp(vector.y, min, max),
                Mathf.Clamp(vector.z, min, max)
            );
        }

        /// <summary>
        /// Rotates this vector around the given axis by the specified degrees.
        /// </summary>
        public static Vector3 RotateAroundAxis(this Vector3 v, Vector3 axis, float degrees)
        {
            return Quaternion.AngleAxis(degrees, axis) * v;
        }

        /// <summary>
        /// Rotates this vector around a pivot point and axis by the specified degrees.
        /// </summary>
        public static Vector3 RotateAround(this Vector3 v, Vector3 pivot, Vector3 axis, float degrees)
        {
            return Quaternion.AngleAxis(degrees, axis) * (v - pivot) + pivot;
        }

        /// <summary>
        /// Scales this vector uniformly by the specified scale factor.
        /// </summary>
        public static Vector3 Scale(this Vector3 v, float scale)
        {
            return v * scale;
        }

        /// <summary>
        /// Scales this vector component-wise by another vector.
        /// </summary>
        public static Vector3 Scale(this Vector3 v, Vector3 scale)
        {
            return Vector3.Scale(v, scale);
        }

        /// <summary>
        /// Returns the distance between this vector and the target vector.
        /// </summary>
        public static float Distance(this Vector3 v, Vector3 target)
        {
            return Vector3.Distance(v, target);
        }

        /// <summary>
        /// Returns the squared distance between this vector and the target vector.
        /// </summary>
        public static float SqrDistance(this Vector3 v, Vector3 target)
        {
            return (v - target).sqrMagnitude;
        }

        /// <summary>
        /// Returns the angle in degrees between this vector and the target vector.
        /// </summary>
        public static float Angle(this Vector3 v, Vector3 target)
        {
            return Vector3.Angle(v, target);
        }

        /// <summary>
        /// Returns the dot product between this vector and the target vector.
        /// </summary>
        public static float Dot(this Vector3 v, Vector3 target)
        {
            return Vector3.Dot(v, target);
        }

        /// <summary>
        /// Returns the cross product between this vector and the target vector.
        /// </summary>
        public static Vector3 Cross(this Vector3 v, Vector3 target)
        {
            return Vector3.Cross(v, target);
        }

        /// <summary>
        /// Returns a copy of this vector with the X component replaced.
        /// </summary>
        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Returns a copy of this vector with the Y component replaced.
        /// </summary>
        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Returns a copy of this vector with the Z component replaced.
        /// </summary>
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Returns the projection of this vector onto the target vector.
        /// </summary>
        public static Vector3 ProjectOn(this Vector3 v, Vector3 target)
        {
            return Vector3.Project(v, target);
        }

        /// <summary>
        /// Returns the reflection of this vector off the plane defined by the given normal.
        /// </summary>
        public static Vector3 Reflect(this Vector3 v, Vector3 normal)
        {
            return Vector3.Reflect(v, normal);
        }

        /// <summary>
        /// Converts this Vector3 to a Vector2 by dropping the Z component.
        /// </summary>
        public static Vector2 ToVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}
