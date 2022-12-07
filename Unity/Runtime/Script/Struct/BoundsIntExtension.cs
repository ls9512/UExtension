using UnityEngine;

namespace Aya.Extension
{
    public static partial class BoundsIntExtension
    {
        #region Deconstruct

        public static void Deconstruct(this BoundsInt bounds, out int xMin, out int yMin, out int zMin, out int sizeX, out int sizeY, out int sizeZ)
        {
            xMin = bounds.xMin;
            yMin = bounds.yMin;
            zMin = bounds.zMin;
            sizeX = bounds.size.x;
            sizeY = bounds.size.y;
            sizeZ = bounds.size.z;
        }

        public static void Deconstruct(this BoundsInt bounds, out Vector3Int position, out Vector3Int size)
        {
            position = bounds.position;
            size = bounds.size;
        }

        public static void Deconstruct(this BoundsInt bounds, out Vector3Int position, out Vector3Int size, out Vector3Int min, out Vector3Int max)
        {
            position = bounds.position;
            size = bounds.size;
            min = bounds.min;
            max = bounds.max;
        }

        #endregion

        #region With

        public static BoundsInt With(this BoundsInt bounds, in Vector3Int? position = null, in Vector3Int? size = null)
        {
            var result = new BoundsInt(position ?? bounds.position, size ?? bounds.size);
            return result;
        }

        #endregion
    }
}