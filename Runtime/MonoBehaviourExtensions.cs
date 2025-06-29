using UnityEngine;

namespace RossoForge.Extensions
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Enables the GameObject this MonoBehaviour is attached to.
        /// </summary>
        public static void ActivateGameObject(this MonoBehaviour mb)
        {
            mb.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the GameObject this MonoBehaviour is attached to.
        /// </summary>
        public static void DeactivateGameObject(this MonoBehaviour mb)
        {
            mb.gameObject.SetActive(false);
        }

        /// <summary>
        /// Destroys the GameObject this MonoBehaviour is attached to.
        /// </summary>
        public static void DestroySelf(this MonoBehaviour mb)
        {
            Object.Destroy(mb.gameObject);
        }

        /// <summary>
        /// Destroys the GameObject after the specified delay.
        /// </summary>
        public static void DestroySelf(this MonoBehaviour mb, float delay)
        {
            Object.Destroy(mb.gameObject, delay);
        }
    }
}