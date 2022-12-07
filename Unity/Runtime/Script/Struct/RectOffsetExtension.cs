using UnityEngine;

namespace Aya.Extension
{
    public static class RectOffsetExtension
    {
        public static void Deconstruct(this RectOffset rectOffset, out int left, out int right, out int top, out int bottom)
        {
            left = rectOffset.left;
            right = rectOffset.right;
            top = rectOffset.top;
            bottom = rectOffset.bottom;
        }

        public static RectOffset With(this RectOffset rectOffset, int? left = null, int? right = null, int? top = null, int? bottom = null)
        {
            var result = new RectOffset(left ?? rectOffset.left, right ?? rectOffset.right, top ?? rectOffset.top, bottom ?? rectOffset.bottom);
            return result;
        }
    }
}