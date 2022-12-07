using UnityEngine;

namespace Aya.Extension
{
    public static partial class Vector2Extension
    {
        #region Deconstruct & With

        public static void Deconstruct(in this Vector2 vector, out float x, out float y)
        {
            x = vector.x;
            y = vector.y;
        }

        public static Vector2 With(in this Vector2 vector, float? x = null, float? y = null)
        {
            var result = new Vector2(x ?? vector.x, y ?? vector.y);
            return result;
        } 

        #endregion

        #region Distance

        public static float Distance2Line(this Vector2 vector, Vector2 linePoint1, Vector2 linePoint2)
        {
            var vec1 = vector - linePoint1;
            var vec2 = linePoint2 - linePoint1;
            var project = Vector3.Project(vec1, vec2);
            var dis = Mathf.Sqrt(Mathf.Pow(Vector3.Magnitude(vec1), 2) - Mathf.Pow(Vector3.Magnitude(project), 2));
            return dis;
        }

        #endregion

        #region Rotate

        public static Vector3 Rotate(Vector3 origin, Vector3 point, Vector3 axis, float angle)
        {
            var quaternion = Quaternion.AngleAxis(angle, axis);
            var offset = origin - point;
            offset = quaternion * offset;
            var result = point + offset;
            return result;
        }

        #endregion

        #region Flip

        public static Vector2 Flip(this Vector2 vector)
        {
            vector = -vector;
            return vector;
        }

        public static Vector2 FlipX(this Vector2 vector)
        {
            vector.x = -vector.x;
            return vector;
        }

        public static Vector2 FlipY(this Vector2 vector)
        {
            vector.y = -vector.y;
            return vector;
        }

        #endregion

        #region Clamp

        public static Vector2 Clamp01(this Vector2 vector)
        {
            vector = vector.Clamp(0f, 1f);
            return vector;
        }

        public static Vector2 Clamp(this Vector2 vector, float min, float max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            return vector;
        }

        public static Vector2 Clamp(this Vector2 vector, Vector2 min, Vector2 max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            return vector;
        }

        #endregion

        public static bool IsNaN(this Vector2 vector)
        {
            return float.IsNaN(vector.x) || float.IsNaN(vector.y);
        }
    }
}