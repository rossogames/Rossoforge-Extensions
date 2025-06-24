using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class SpriteExtensions
    {
        public static Vector2 GetNormalizedPivot(this Sprite sprite)
        {
            float x = sprite.pivot.x > 0 ? sprite.pivot.x / sprite.rect.width : 0;
            float y = sprite.pivot.y > 0 ? sprite.pivot.y / sprite.rect.height : 0;
            return new Vector2(x, y);
        }
    }
}