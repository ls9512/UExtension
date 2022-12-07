using UnityEngine;

namespace Aya.Extension
{
    public static partial class Vector4IntExtension
    {
        #region Deconstruct & With

        public static void Deconstruct(in this Vector4 vector, out float x, out float y, out float z, out float w)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
            w = vector.w;
        }

        public static Vector4 With(in this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            var result = new Vector4(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);
            return result;
        }

        #endregion

        public static bool IsNaN(this Vector4 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z) || float.IsNaN(vector.w);
        }
    }
}