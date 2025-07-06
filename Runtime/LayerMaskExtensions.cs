using UnityEngine;

namespace Rossoforge.Extensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Checks if the LayerMask contains the given layer index.
        /// </summary>
        /// <param name="layer">layer index</param>
        /// <returns></returns>
        public static bool ContainsLayer(this LayerMask layerMask, int layer)
        {
            return (layerMask & (1 << layer)) != 0;
        }


        /// <summary>
        /// Returns a new LayerMask that includes the original layers plus the given layer.
        /// </summary>
        public static LayerMask AddLayer(this LayerMask mask, int layer)
        {
            return mask | (1 << layer);
        }

        /// <summary>
        /// Returns a new LayerMask with the specified layer removed.
        /// </summary>
        public static LayerMask RemoveLayer(this LayerMask mask, int layer)
        {
            return mask & ~(1 << layer);
        }

        /// <summary>
        /// Converts the LayerMask to a list of layer indices (0 to 31) it contains.
        /// </summary>
        public static int[] ToLayerIndices(this LayerMask mask)
        {
            var layers = new System.Collections.Generic.List<int>();
            for (int i = 0; i < 32; i++)
            {
                if ((mask & (1 << i)) != 0)
                    layers.Add(i);
            }
            return layers.ToArray();
        }

        /// <summary>
        /// Converts the LayerMask to a list of layer names.
        /// </summary>
        public static string[] ToLayerNames(this LayerMask mask)
        {
            var names = new System.Collections.Generic.List<string>();
            for (int i = 0; i < 32; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    string name = LayerMask.LayerToName(i);
                    if (!string.IsNullOrEmpty(name))
                        names.Add(name);
                }
            }
            return names.ToArray();
        }
    }
}
