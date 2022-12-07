using UnityEngine;

namespace Aya.Extension
{
    public static partial class RectExtension
    {
        #region Deconstruct
       
        public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
        {
            x = rect.x;
            y = rect.y;
            width = rect.width;
            height = rect.height;
        }

        public static void Deconstruct(this Rect rect, out Vector2 position, out Vector2 size)
        {
            position = rect.position;
            size = rect.size;
        } 

        #endregion

        #region With

        public static Rect With(this Rect rect, float? x = null, float? y = null, float? width = null, float? height = null)
        {
            var result = new Rect(x ?? rect.x, y ?? rect.y, width ?? rect.width, height ?? rect.height);
            return result;
        }

        public static Rect With(this Rect rect, Vector2? position = null, Vector2? size = null)
        {
            var result = new Rect(position ?? rect.position, size ?? rect.size);
            return result;
        }

        #endregion

        #region Width / Height / Size

        public static Rect SetWidth(this ref Rect rect, float width)
        {
            rect.width = width;
            return rect;
        }

        public static Rect SetHeight(this ref Rect rect, float height)
        {
            rect.height = height;
            return rect;
        }

        public static Rect SetSize(this ref Rect rect, float width, float height)
        {
            rect.width = width;
            rect.height = height;
            return rect;
        }

        public static Rect SetSize(this ref Rect rect, Vector2 size)
        {
            rect.size = size;
            return rect;
        }

        #endregion

        #region Center

        public static Rect SetCenterX(this ref Rect rect, float x)
        {
            rect.center = new Vector2(x, rect.center.y);
            return rect;
        }

        public static Rect SetCenterY(this ref Rect rect, float y)
        {
            rect.center = new Vector2(rect.center.x, y);
            return rect;
        }

        public static Rect SetCenter(this ref Rect rect, float x, float y)
        {
            rect.center = new Vector2(x, y);
            return rect;
        }

        public static Rect SetCenter(this ref Rect rect, Vector2 center)
        {
            rect.center = center;
            return rect;
        }

        #endregion

        #region X / Y / Position

        public static Rect SetX(this ref Rect rect, float x)
        {
            rect.x = x;
            return rect;
        } 

        public static Rect SetY(this ref Rect rect, float y)
        {
            rect.y = y;
            return rect;
        }

        public static Rect SetPosition(this ref Rect rect, Vector2 position)
        {
            rect.position = position;
            return rect;
        }

        #endregion

        #region Expand / Reduce

        public static Rect Expand(this Rect rect, float expandSize)
        {
            rect.x -= expandSize;
            rect.y -= expandSize;
            rect.width += expandSize * 2f;
            rect.height += expandSize * 2f;
            return rect;
        }

        public static Rect Expand(this Rect rect, Rect expandRect)
        {
            rect.x -= expandRect.x;
            rect.y -= expandRect.y;
            rect.width += expandRect.width;
            rect.height += expandRect.height;
            return rect;
        }

        public static Rect Reduce(this Rect rect, float reduceSize)
        {
            rect.x += reduceSize;
            rect.y += reduceSize;
            rect.width -= reduceSize * 2f;
            rect.height -= reduceSize * 2f;
            return rect;
        }

        public static Rect Reduce(this Rect rect, Rect reduceRect)
        {
            rect.x += reduceRect.x;
            rect.y += reduceRect.y;
            rect.width -= reduceRect.width;
            rect.height -= reduceRect.height;
            return rect;
        }

        #endregion

        #region Split

        public static Rect SplitHorizontal(this Rect rect, int index, int count)
        {
            var num = rect.width / (float)count;
            rect.width = num;
            rect.x += num * (float)index;
            return rect;
        }

        public static Rect SplitVertical(this Rect rect, int index, int count)
        {
            var num = rect.height / (float)count;
            rect.height = num;
            rect.y += num * (float)index;
            return rect;
        }

        public static Rect SplitGrid(this Rect rect, float width, float height, int index)
        {
            var num1 = (int)((double)rect.width / (double)width);
            var num2 = num1 > 0 ? num1 : 1;
            var num3 = index % num2;
            var num4 = index / num2;
            rect.x += (float)num3 * width;
            rect.y += (float)num4 * height;
            rect.width = width;
            rect.height = height;
            return rect;
        }

        public static Rect SplitTableGrid(this Rect rect, int columnCount, float rowHeight, int index)
        {
            var num1 = index % columnCount;
            var num2 = index / columnCount;
            var num3 = rect.width / (float)columnCount;
            rect.x += (float)num1 * num3;
            rect.y += (float)num2 * rowHeight;
            rect.width = num3;
            rect.height = rowHeight;
            return rect;
        }

        #endregion
    }
}
