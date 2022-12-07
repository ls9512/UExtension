using UnityEngine;

namespace Aya.Extension
{
    public static class Vector3Extension
    {
        #region Deconstruct & With

        public static void Deconstruct(in this Vector3 vector, out float x, out float y, out float z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        public static Vector3 With(in this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            var result = new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
            return result;
        }

        #endregion

        #region Distance

        public static float Distance2Point(this Vector3 vector, Vector3 point)
        {
            var result = Vector3.Distance(vector, point);
            return result;
        }

        public static float Distance2Line(Vector2 vector, Vector2 linePoint1, Vector2 linePoint2)
        {
            float space;
            var a = Vector2.Distance(linePoint1, linePoint2);
            var b = Vector2.Distance(linePoint1, vector);
            var c = Vector2.Distance(linePoint2, vector);
            if (c <= 1e-6 || b <= 1e-6)
            {
                space = 0;
                return space;
            }

            if (a <= 1e-6)
            {
                space = b;
                return space;
            }

            if (c * c >= a * a + b * b)
            {
                space = b;
                return space;
            }

            if (b * b >= a * a + c * c)
            {
                space = c;
                return space;
            }

            var p = (a + b + c) / 2;
            var s = Mathf.Sqrt(p * (p - a) * (p - b) * (p - c));
            space = 2 * s / a;
            return space;
        }

        #endregion

        #region Clamp

        public static Vector3 Clamp01(this Vector3 vector)
        {
            vector = vector.Clamp(0f, 1f);
            return vector;
        }

        public static Vector3 Clamp(this Vector3 vector, float min, float max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            vector.z = Mathf.Clamp(vector.z, min, max);
            return vector;
        }

        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            vector.z = Mathf.Clamp(vector.z, min.z, max.z);
            return vector;
        }

        #endregion

        #region Flip
        
        public static Vector3 Flip(this Vector3 vector)
        {
            vector = -vector;
            return vector;
        }

        public static Vector3 FlipX(this Vector3 vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        public static Vector3 FlipY(this Vector3 vector)
        {
            vector.y = -vector.y;
            return vector;
        }

        public static Vector3 FlipZ(this Vector3 vector)
        {
            vector.z = -vector.z;
            return vector;
        }

        #endregion

        #region XYZ -> Vecotr2

        public static Vector2 GetXy(this Vector3 vector)
        {
            var result = new Vector2(vector.x, vector.y);
            return result;
        }

        public static Vector2 GetYz(this Vector3 vector)
        {
            var result = new Vector2(vector.y, vector.z);
            return result;
        }

        public static Vector2 GetXz(this Vector3 vector)
        {
            var result = new Vector2(vector.x, vector.z);
            return result;
        }

        #endregion

        #region Rotate

        public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Vector3 eulerAngles)
        {
            var dir = point - pivot;
            dir = Quaternion.Euler(eulerAngles) * dir;
            return dir + pivot;
        }

        public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            var dir = point - pivot;
            dir = rotation * dir;
            return dir + pivot;
        }

        #endregion

        public static bool IsNaN(this Vector3 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
        }
    }
}