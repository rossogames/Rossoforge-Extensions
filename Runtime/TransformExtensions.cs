using System.Collections.Generic;
using UnityEngine;

namespace RossoForge.Extensions
{
    public static class TransformExtensions
    {
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
        /// Resets the local position, rotation, and scale to default values.
        /// </summary>
        public static void ResetLocal(this Transform t)
        {
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

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
    }
}

