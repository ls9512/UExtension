using UnityEngine;

namespace Aya.Extension
{
    public static partial class ResolutionExtension
    {
        public static void Deconstruct(this Resolution resolution, out int width, out int height)
        {
            width = resolution.width;
            height = resolution.height;
        }

        public static void Deconstruct(this Resolution resolution, out int width, out int height, out int refreshRate)
        {
            width = resolution.width;
            height = resolution.height;
            refreshRate = resolution.refreshRate;
        }

        public static Resolution With(this Resolution resolution, int? width = null, int? height = null, int? refreshRate = null)
        {
            var result = new Resolution {width = width ?? resolution.width, height = height ?? resolution.height, refreshRate = refreshRate ?? resolution.refreshRate};
            return result;
        }
    }
}