using UnityEngine;

namespace Aya.Extension
{
    public static partial class RectIntExtension
    {
        #region Deconstruct
        
        public static void Deconstruct(this RectInt rect, out int x, out int y, out int width, out int height)
        {
            x = rect.x;
            y = rect.y;
            width = rect.width;
            height = rect.height;
        }

        public static void Deconstruct(this RectInt rect, out Vector2Int position, out Vector2Int size)
        {
            position = rect.position;
            size = rect.size;
        } 

        #endregion

        #region With

        public static RectInt With(this RectInt rect, int? x = null, int? y = null, int? width = null, int? height = null)
        {
            var result = new RectInt(x ?? rect.x, y ?? rect.y, width ?? rect.width, height ?? rect.height);
            return result;
        }

        public static RectInt With(this RectInt rect, Vector2Int? position = null, Vector2Int? size = null)
        {
            var result = new RectInt(position ?? rect.position, size ?? rect.size);
            return result;
        }

        #endregion
    }
}