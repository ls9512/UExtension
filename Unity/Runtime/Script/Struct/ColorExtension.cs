using System;
using UnityEngine;

namespace Aya.Extension
{
    public static class ColorExtension
    {
        #region Deconstruct
        
        public static void Deconstruct(in this Color color, out float r, out float g, out float b)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }

        public static void Deconstruct(in this Color color, out float r, out float g, out float b, out float a)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = color.a;
        }

        public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }

        public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b, out byte a)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = color.a;
        }

        #endregion

        #region With
        
        public static Color With(in this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            var result = new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
            return result;
        }

        public static Color32 With(in this Color32 color
            , byte? r = null, byte? g = null, byte? b = null, byte? a = null)
        {
            var result = new Color32(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
            return result;
        }

        #endregion

        #region RGB

        public static Color SetR(this ref Color color, float r)
        {
            r = Mathf.Clamp01(r);
            color.r = r;
            return color;
        }

        public static Color SetG(this ref Color color, float g)
        {
            g = Mathf.Clamp01(g);
            color = new Color(color.r, g, color.b, color.a);
            return color;
        }

        public static Color SetB(this ref Color color, float b)
        {
            b = Mathf.Clamp01(b);
            color = new Color(color.r, color.g, b, color.a);
            return color;
        }

        public static Color SetA(this ref Color color, float a)
        {
            a = Mathf.Clamp01(a);
            color.a = a;
            return color;
        }

        public static int GetRgbValue(this Color color)
        {
            var r = (int) (color.r * 255);
            var g = (int) (color.g * 255);
            var b = (int) (color.b * 255);
            return r * 255 * 255 + g * 255 + b;
        }

        #endregion

        #region HSV

        public static float GetH(this Color color)
        {
            Color.RGBToHSV(color, out var h, out _, out _);
            return h;
        }

        public static float GetS(this Color color)
        {
            Color.RGBToHSV(color, out _, out var s, out _);
            return s;
        }

        public static float GetV(this Color color)
        {
            Color.RGBToHSV(color, out _, out _, out var v);
            return v;
        }

        public static Color SetH(this ref Color color, float h)
        {
            Color.RGBToHSV(color, out _, out var ts, out var tv);
            var tc = Color.HSVToRGB(h, ts, tv);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }

        public static Color SetS(this ref Color color, float s)
        {
            Color.RGBToHSV(color, out var th, out _, out var tv);
            var tc = Color.HSVToRGB(th, s, tv);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }

        public static Color SetV(this ref Color color, float v)
        {
            Color.RGBToHSV(color, out var th, out var ts, out _);
            var tc = Color.HSVToRGB(th, ts, v);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }

        public static Color SetHsv(this ref Color color, float h, float s, float v)
        {
            var tc = Color.HSVToRGB(h, s, v);
            color.r = tc.r;
            color.g = tc.g;
            color.b = tc.b;
            return color;
        }

        #endregion

        #region Color SDR

        public static Color ComplementaryColor(this Color color, bool inverseAlpha = false)
        {
            var result = new Color(
                1f - color.r,
                1f - color.g,
                1f - color.b,
                inverseAlpha ? 1f - color.a : color.a);
            return result;
        }

        public static float GrayLevel(this Color color)
        {
            var result = (color.r + color.g + color.b) / 3f;
            return result;
        }

        // LDR Ignore Alpha
        public static float GetPerceivedBrightness(this Color color)
        {
            var result = Mathf.Sqrt(
                0.241f * color.r * color.r +
                0.691f * color.g * color.g +
                0.068f * color.b * color.b);
            return result;
        }

        #endregion

        #region AGBA32

        public static uint ToArgb32(this Color color)
        {
            var result = ((uint)(color.a * 255) << 24)
                         | ((uint)(color.r * 255) << 16)
                         | ((uint)(color.g * 255) << 8)
                         | ((uint)(color.b * 255));
            return result;
        }


        public static Color FromArgb32(this ref Color color, uint argb32)
        {
            var result = new Color(
                ((argb32 >> 16) & 0xFF) / 255f,
                ((argb32 >> 8) & 0xFF) / 255f,
                ((argb32) & 0xFF) / 255f,
                ((argb32 >> 24) & 0xFF) / 255f);
            return result;
        }

        #endregion

        #region HTML

        public static string GetHtmlRgb(this Color color)
        {
            var r = (int)(color.r * 255);
            var g = (int)(color.g * 255);
            var b = (int)(color.b * 255);
            var result = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2");
            return result;
        }

        public static string GetHtmlRgba(this Color color)
        {
            var r = (int)(color.r * 255);
            var g = (int)(color.g * 255);
            var b = (int)(color.b * 255);
            var a = (int)(color.a * 255);
            var result = "#" + r.ToString("x2") + g.ToString("x2") + b.ToString("x2") + a.ToString("x2");
            return result;
        }

        public static Color SetHtmlRgb(this ref Color color, string html)
        {
            html = html.Replace("#", "");
            var r = Convert.ToInt32(html.Substring(0, 2), 16);
            var g = Convert.ToInt32(html.Substring(2, 2), 16);
            var b = Convert.ToInt32(html.Substring(4, 2), 16);
            color.r = r;
            color.g = g;
            color.b = b;
            return color;
        }

        public static Color SetHtmlRgba(this ref Color color, string html)
        {
            html = html.Replace("#", "");
            var r = Convert.ToInt32(html.Substring(0, 2), 16);
            var g = Convert.ToInt32(html.Substring(2, 2), 16);
            var b = Convert.ToInt32(html.Substring(4, 2), 16);
            var a = Convert.ToInt32(html.Substring(6, 2), 16);
            color.r = r;
            color.g = g;
            color.b = b;
            color.a = a;
            return color;
        }

        #endregion

        #region Normalize

        public static Color Normalize(this ref Color color)
        {
            var vector = new Vector3(color.r, color.g, color.b).normalized;
            color.r = vector.x;
            color.g = vector.y;
            color.b = vector.z;
            return color;
        }

        #endregion

        #region Clamp

        public static Color Clamp(this ref Color value, float min, float max)
        {
            var result = new Color(
                Mathf.Clamp(value.r, min, max),
                Mathf.Clamp(value.g, min, max),
                Mathf.Clamp(value.b, min, max),
                Mathf.Clamp(value.a, min, max)
            );
            return result;
        }

        public static Color Clamp(this ref Color value, Color min, Color max)
        {
            float t;
            if (min.r > max.r)
            {
                t = min.r;
                min.r = max.r;
                max.r = t;
            }

            if (min.g > max.g)
            {
                t = min.g;
                min.g = max.g;
                max.g = t;
            }

            if (min.b > max.b)
            {
                t = min.b;
                min.b = max.b;
                max.b = t;
            }

            if (min.a > max.a)
            {
                t = min.a;
                min.a = max.a;
                max.a = t;
            }

            var result = new Color(
                Mathf.Clamp(value.r, min.r, max.r),
                Mathf.Clamp(value.g, min.g, max.g),
                Mathf.Clamp(value.b, min.b, max.b),
                Mathf.Clamp(value.a, min.a, max.a)
            );

            return result;
        }

        #endregion
    }
}