using UnityEngine;
using UnityEngine.UI;

namespace Aya.Extension
{
    public static class MaskableGraphicExtension
    {
        #region Color RGB
    
        public static float GetR(this MaskableGraphic graphic)
        {
            return graphic.color.r;
        }

        public static void SetR(this MaskableGraphic graphic, float red)
        {
            var color = graphic.color;
            color.r = red;
            graphic.color = color;
        }

        public static float GetG(this MaskableGraphic graphic)
        {
            return graphic.color.g;
        }

        public static void SetG(this MaskableGraphic graphic, float green)
        {
            var color = graphic.color;
            color.g = green;
            graphic.color = color;
        }

        public static float GetB(this MaskableGraphic graphic)
        {
            return graphic.color.b;
        }

        public static void SetB(this MaskableGraphic graphic, float blue)
        {
            var color = graphic.color;
            color.b = blue;
            graphic.color = color;
        }

        public static float GetA(this MaskableGraphic graphic)
        {
            return graphic.color.a;
        }

        public static void SetA(this MaskableGraphic graphic, float alpha)
        {
            var color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }

        #endregion

        #region Color HSV

        public static float GetH(this MaskableGraphic graphic)
        {
            Color.RGBToHSV(graphic.color, out var h, out _, out _);
            return h;
        }

        public static void SetH(this MaskableGraphic graphic, float h)
        {
            var color = graphic.color;
            Color.RGBToHSV(color, out _, out var ts, out var tv);
            var result = Color.HSVToRGB(h, ts, tv);
            graphic.color = result;
        }

        public static float GetS(this MaskableGraphic graphic)
        {
            Color.RGBToHSV(graphic.color, out var _, out var s, out _);
            return s;
        }

        public static void SetS(this MaskableGraphic graphic, float s)
        {
            var color = graphic.color;
            Color.RGBToHSV(color, out var th, out _, out var tv);
            var result = Color.HSVToRGB(th, s, tv);
            graphic.color = result;
        }

        public static float GetV(this MaskableGraphic graphic)
        {
            Color.RGBToHSV(graphic.color, out var _, out _, out var v);
            return v;
        }

        public static void SetV(this MaskableGraphic graphic, float v)
        {
            var color = graphic.color;
            Color.RGBToHSV(color, out var th, out var ts, out _);
            var result = Color.HSVToRGB(th, ts, v);
            graphic.color = result;
        }

        #endregion
    }
}