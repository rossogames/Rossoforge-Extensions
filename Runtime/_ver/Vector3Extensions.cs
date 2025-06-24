using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class Vector3Extensions
    {
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        /// <summary>
        /// Clamps the given value between the given minimum float and maximum float values.
        /// </summary>
        /// <param name="vector">vector to Clamp</param>
        /// <param name="min">The minimum floating point value to compare against.</param>
        /// <param name="max">The maximum floating point value to compare against.</param>
        /// <returns>Returns the given value if it is within the minimum and maximum range.</returns>
        public static Vector3 Clamp(this Vector3 vector, float min, float max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min, max),
                Mathf.Clamp(vector.y, min, max),
                Mathf.Clamp(vector.z, min, max)
            );
        }

        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
        public static Vector3 Scale(this Vector3 input, Vector3 scale) => new(input.x * scale.x, input.y * scale.y, input.z * scale.z);
        public static Vector3 Direction(this Vector3 input, Vector3 target) => (target - input).normalized;
    }
}