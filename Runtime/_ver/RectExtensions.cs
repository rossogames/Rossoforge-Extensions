using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class RectExtensions
    {
        public static bool Contains(this Rect rect, float x, float y)
        {
            return
                x >= rect.x &&
                x < rect.max.x &&
                y >= rect.y &&
                y < rect.max.y;
        }
    }
}

