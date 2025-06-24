using System.Collections.Generic;
using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class TransformExtensions
    {
        public static Transform[] GetChilds(this Transform transform, bool includeInactives)
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
    }
}

