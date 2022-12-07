using UnityEngine;

namespace Aya.Extension
{
    public static class RayExtensions
    {
        public static void Deconstruct(this Ray ray, out Vector3 origin, out Vector3 direction)
        {
            origin = ray.origin;
            direction = ray.direction;
        }

        public static Ray With(this Ray ray, in Vector3? origin = null, in Vector3? direction = null)
        {
            var result = new Ray(origin ?? ray.origin, direction ?? ray.direction);
            return result;
        }
    }
}