using UnityEngine;

namespace Aya.Extension
{
    public static class GradientExtension
    {
        public static void Reverse(this Gradient gradient)
        {
            var alphaKeys = gradient.alphaKeys;
            var colorKeys = gradient.colorKeys;
            var newAlphaKeys = new GradientAlphaKey[alphaKeys.Length];
            var newColorKeys = new GradientColorKey[colorKeys.Length];
            for (var i = 0; i < alphaKeys.Length; i++)
            {
                var alphaKey = alphaKeys[i];
                newAlphaKeys[alphaKeys.Length - 1 - i] = new GradientAlphaKey(alphaKey.alpha, 1f - alphaKey.time);
            }

            for (var i = 0; i < colorKeys.Length; i++)
            {
                var colorKey = colorKeys[i];
                newColorKeys[colorKeys.Length - 1 - i] = new GradientColorKey(colorKey.color, 1f - colorKey.time);
            }

            gradient.SetKeys(newColorKeys, newAlphaKeys);
        }
    }
}
