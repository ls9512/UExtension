using UnityEngine;

namespace Aya.Extension
{
    public static partial class Vector2IntExtension
    {
        #region Deconstruct & With

        public static void Deconstruct(in this Vector2Int vector, out int x, out int y)
        {
            x = vector.x;
            y = vector.y;
        }

        public static Vector2Int With(in this Vector2Int vector, int? x = null, int? y = null)
        {
            var result = new Vector2Int(x ?? vector.x, y ?? vector.y);
            return result;
        }

        #endregion
    }
}