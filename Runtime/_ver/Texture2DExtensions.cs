using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class Texture2DExtensions
    {
        /// <summary>
        /// convierte la textura en un sprite
        /// </summary>
        /// <param name="texture">Convert the texture to a sprite</param>
        /// <returns></returns>
        public static Sprite ConvertToSprite(this Texture2D texture)
        {
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
        /// <summary>
        /// convierte la textura en un sprite
        /// </summary>
        /// <param name="texture">Convert the texture to a sprite</param>
        /// <param name="PixelsPerUnit">number of pixels to display per unit of measure</param>
        /// <param name="spriteType">sprite mesh type</param>
        /// <returns></returns>
        public static Sprite ConvertToSprite(this Texture2D texture, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0, 0),
                PixelsPerUnit,
                0,
                spriteType
            );
        }
        /// <summary>
        /// Clone the texture
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Texture2D Clone(this Texture2D source)
        {
            RenderTexture renderTexture = RenderTexture.GetTemporary(
                source.width,
                source.height,
                0,
                RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);

            Graphics.Blit(source, renderTexture);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTexture;

            var newTexture = new Texture2D(source.width, source.height);
            newTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            newTexture.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTexture);

            return newTexture;
        }
    }
}
