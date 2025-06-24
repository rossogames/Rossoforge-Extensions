using System.Collections.Generic;
using UnityEngine;

namespace RossoForge.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns the component of Type type. If one doesn't already exist on the GameObject it will be added.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Checks if the GameObject has a component of type T.
        /// </summary>
        public static bool HasComponent<T>(this GameObject go) where T : Component
        {
            return go.GetComponent<T>() != null;
        }

        /// <summary>
        /// Finds a child GameObject by name recursively.
        /// </summary>
        public static GameObject FindChild(this GameObject go, string name)
        {
            foreach (Transform child in go.transform)
            {
                if (child.name == name)
                    return child.gameObject;

                GameObject result = child.gameObject.FindChild(name);
                if (result != null)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// Destroys all children of the GameObject.
        /// </summary>
        public static void DestroyAllChildren(this GameObject go)
        {
            foreach (Transform child in go.transform)
            {
                Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Sets the layer of the GameObject and all its children recursively.
        /// </summary>
        public static void SetLayerRecursively(this GameObject go, int layer)
        {
            go.layer = layer;
            foreach (Transform child in go.transform)
            {
                child.gameObject.SetLayerRecursively(layer);
            }
        }

        /// <summary>
        /// Gets all components of type T in children, excluding the parent GameObject.
        /// </summary>
        public static List<T> GetComponentsInChildrenWithoutSelf<T>(this GameObject go) where T : Component
        {
            List<T> result = new List<T>();
            foreach (Transform child in go.transform)
            {
                result.AddRange(child.GetComponentsInChildren<T>());
            }
            return result;
        }
    }
}