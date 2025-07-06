using System.Collections.Generic;
using UnityEngine;

namespace Rossoforge.Extensions
{
    public static class TransformExtensions
    {
        // POSITION
        /// <summary>
        /// Sets the X component of the Transform's position.
        /// </summary>
        public static void SetPositionX(this Transform t, float x)
        {
            Vector3 pos = t.position;
            pos.x = x;
            t.position = pos;
        }

        /// <summary>
        /// Sets the Y component of the Transform's position.
        /// </summary>
        public static void SetPositionY(this Transform t, float y)
        {
            Vector3 pos = t.position;
            pos.y = y;
            t.position = pos;
        }

        /// <summary>
        /// Sets the Z component of the Transform's position.
        /// </summary>
        public static void SetPositionZ(this Transform t, float z)
        {
            Vector3 pos = t.position;
            pos.z = z;
            t.position = pos;
        }

        /// <summary>
        /// Resets the position to default values.
        /// </summary>
        public static void ResetPosition(this Transform t)
        {
            t.position = Vector3.zero;
        }

        /// LOCAL SCALE
        /// <summary>
        /// Sets the local X scale of the Transform.
        /// </summary>
        public static void SetLocalScaleX(this Transform t, float x)
        {
            Vector3 scale = t.localScale;
            scale.x = x;
            t.localScale = scale;
        }

        /// <summary>
        /// Sets the local Y scale of the Transform.
        /// </summary>
        public static void SetLocalScaleY(this Transform t, float y)
        {
            Vector3 scale = t.localScale;
            scale.y = y;
            t.localScale = scale;
        }

        /// <summary>
        /// Sets the local Z scale of the Transform.
        /// </summary>
        public static void SetLocalScaleZ(this Transform t, float z)
        {
            Vector3 scale = t.localScale;
            scale.z = z;
            t.localScale = scale;
        }

        /// <summary>
        /// Resets the local scale to default values.
        /// </summary>
        public static void ResetLocalScale(this Transform t)
        {
            t.localScale = Vector3.zero;
        }

        // LOCAL POSITION

        /// <summary>
        /// Sets the X component of the local position.
        /// </summary>
        public static void SetLocalPositionX(this Transform t, float x)
        {
            Vector3 pos = t.localPosition;
            pos.x = x;
            t.localPosition = pos;
        }

        /// <summary>
        /// Sets the Y component of the local position.
        /// </summary>
        public static void SetLocalPositionY(this Transform t, float y)
        {
            Vector3 pos = t.localPosition;
            pos.y = y;
            t.localPosition = pos;
        }

        /// <summary>
        /// Sets the Z component of the local position.
        /// </summary>
        public static void SetLocalPositionZ(this Transform t, float z)
        {
            Vector3 pos = t.localPosition;
            pos.z = z;
            t.localPosition = pos;
        }

        /// <summary>
        /// Resets the local position to default values.
        /// </summary>
        public static void ResetLocalPosition(this Transform t)
        {
            t.localPosition = Vector3.zero;
        }

        // ROTATION

        /// <summary>
        /// Sets the rotation's X component in global Euler angles.
        /// </summary>
        public static void SetRotationX(this Transform t, float x)
        {
            Vector3 euler = t.eulerAngles;
            euler.x = x;
            t.eulerAngles = euler;
        }

        /// <summary>
        /// Sets the rotation's Y component in global Euler angles.
        /// </summary>
        public static void SetRotationY(this Transform t, float y)
        {
            Vector3 euler = t.eulerAngles;
            euler.y = y;
            t.eulerAngles = euler;
        }

        /// <summary>
        /// Sets the rotation's Z component in global Euler angles.
        /// </summary>
        public static void SetRotationZ(this Transform t, float z)
        {
            Vector3 euler = t.eulerAngles;
            euler.z = z;
            t.eulerAngles = euler;
        }

        /// <summary>
        /// Rotates the Transform around the global X axis by a specified angle in degrees.
        /// </summary>
        public static void RotateX(this Transform t, float angle)
        {
            t.Rotate(Vector3.right, angle, Space.World);
        }

        /// <summary>
        /// Rotates the Transform around the global Y axis by a specified angle in degrees.
        /// </summary>
        public static void RotateY(this Transform t, float angle)
        {
            t.Rotate(Vector3.up, angle, Space.World);
        }

        /// <summary>
        /// Rotates the Transform around the global Z axis by a specified angle in degrees.
        /// </summary>
        public static void RotateZ(this Transform t, float angle)
        {
            t.Rotate(Vector3.forward, angle, Space.World);
        }

        /// <summary>
        /// Resets the global rotation to identity.
        /// </summary>
        public static void ResetRotation(this Transform t)
        {
            t.rotation = Quaternion.identity;
        }

        // LOCAL ROTATION

        /// <summary>
        /// Sets the local rotation's X component in Euler angles.
        /// </summary>
        public static void SetLocalRotationX(this Transform t, float x)
        {
            Vector3 euler = t.localEulerAngles;
            euler.x = x;
            t.localEulerAngles = euler;
        }

        /// <summary>
        /// Sets the local rotation's Y component in Euler angles.
        /// </summary>
        public static void SetLocalRotationY(this Transform t, float y)
        {
            Vector3 euler = t.localEulerAngles;
            euler.y = y;
            t.localEulerAngles = euler;
        }

        /// <summary>
        /// Sets the local rotation's Z component in Euler angles.
        /// </summary>
        public static void SetLocalRotationZ(this Transform t, float z)
        {
            Vector3 euler = t.localEulerAngles;
            euler.z = z;
            t.localEulerAngles = euler;
        }

        /// <summary>
        /// Resets the local rotation to identity.
        /// </summary>
        public static void ResetLocalRotation(this Transform t)
        {
            t.localRotation = Quaternion.identity;
        }

        /// <summary>
        /// Rotates the Transform around the local X axis by a specified angle in degrees.
        /// </summary>
        public static void RotateLocalX(this Transform t, float angle)
        {
            t.Rotate(Vector3.right, angle, Space.Self);
        }

        /// <summary>
        /// Rotates the Transform around the local Y axis by a specified angle in degrees.
        /// </summary>
        public static void RotateLocalY(this Transform t, float angle)
        {
            t.Rotate(Vector3.up, angle, Space.Self);
        }

        /// <summary>
        /// Rotates the Transform around the local Z axis by a specified angle in degrees.
        /// </summary>
        public static void RotateLocalZ(this Transform t, float angle)
        {
            t.Rotate(Vector3.forward, angle, Space.Self);
        }

        // OTHERS
        /// <summary>
        /// Recursively sets the layer of the GameObject and all its children.
        /// </summary>
        public static void SetLayerRecursively(this Transform t, int layer)
        {
            t.gameObject.layer = layer;
            foreach (Transform child in t)
            {
                child.SetLayerRecursively(layer);
            }
        }

        /// <summary>
        /// Returns an array of the Transform's direct children, optionally including inactive GameObjects.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="includeInactives"></param>
        /// <returns></returns>
        public static Transform[] GetChildren(this Transform transform, bool includeInactives)
        {
            var lstChilds = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.gameObject.activeSelf || includeInactives)
                    lstChilds.Add(child);
            }

            return lstChilds.ToArray();
        }

        /// <summary>
        /// Destroys all children GameObjects of the Transform.
        /// </summary>
        public static void DestroyChildren(this Transform t)
        {
            for (int i = t.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(t.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// Resets the local position, rotation, and scale to default values.
        /// </summary>
        public static void ResetLocal(this Transform t)
        {
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }
    }
}

