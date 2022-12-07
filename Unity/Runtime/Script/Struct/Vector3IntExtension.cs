using UnityEngine;

namespace Aya.Extension
{
    public static partial class Vector3IntExtension
    {
        #region Deconstruct & With

        public static void Deconstruct(in this Vector3Int vector, out int x, out int y, out int z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        public static Vector3Int With(in this Vector3Int vector, int? x = null, int? y = null, int? z= null)
        {
            var result = new Vector3Int(x ?? vector.x, y ?? vector.y, z ?? vector.z);
            return result;
        }

        #endregion
    }
}