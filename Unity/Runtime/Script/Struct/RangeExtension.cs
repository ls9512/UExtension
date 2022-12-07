using UnityEngine;

namespace Aya.Extension
{
    public static class RangeExtension
    {
        public static void Deconstruct(in this RangeInt range, out int start, out int length)
        {
            start = range.start;
            length = range.length;
        }

        public static RangeInt With(in this RangeInt range, int? start = null, int? length = null)
        {
            var result = new RangeInt(start ?? range.start, length ?? range.length);
            return result;
        }
    }
}