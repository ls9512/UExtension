using UnityEngine;

namespace Aya.Extension
{
    public static class SpriteRendererExtension
    {
        public static void SetColorA(this SpriteRenderer spriteRenderer, float alpha)
        {
            var color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            spriteRenderer.color = color;
        }

        public static void SetColorR(this SpriteRenderer spriteRenderer, float red)
        {
            var color = new Color(red, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a);
            spriteRenderer.color = color;
        }

        public static void SetColorG(this SpriteRenderer spriteRenderer, float green)
        {
            var color = new Color(spriteRenderer.color.r, green, spriteRenderer.color.b, spriteRenderer.color.a);
            spriteRenderer.color = color;
        }

        public static void SetColorB(this SpriteRenderer spriteRenderer, float blue)
        {
            var color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, blue, spriteRenderer.color.a);
            spriteRenderer.color = color;
        }
    }
}