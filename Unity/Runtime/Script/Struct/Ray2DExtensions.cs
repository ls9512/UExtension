using UnityEngine;

namespace Aya.Extension
{
    public static partial class Ray2DExtensions
    {
        public static void Deconstruct(this Ray2D ray, out Vector3 origin, out Vector3 direction)
        {
            origin = ray.origin;
            direction = ray.direction;
        }

        public static Ray2D With(this Ray2D ray, in Vector3? origin = null, in Vector3? direction = null)
        {
            var result = new Ray2D(origin ?? ray.origin, direction ?? ray.direction);
            return result;
        }
    }
}