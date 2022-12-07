using UnityEngine;

namespace Aya.Extension
{
    public static partial class BoundsExtension
    {
        #region Deconstruct
        
        public static void Deconstruct(this Bounds bounds, out Vector3 center, out Vector3 size)
        {
            center = bounds.center;
            size = bounds.size;
        }

        public static void Deconstruct(this Bounds bounds, out Vector3 center, out Vector3 size, out Vector3 min, out Vector3 max)
        {
            center = bounds.center;
            size = bounds.size;
            min = bounds.min;
            max = bounds.max;
        }

        #endregion

        #region With

        public static Bounds With(this Bounds bounds, in Vector3? center = null, in Vector3? size = null)
        {
            var result = new Bounds(center ?? bounds.center, size ?? bounds.size);
            return result;
        }

        #endregion
    }
}