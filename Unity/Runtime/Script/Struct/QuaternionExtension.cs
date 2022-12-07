using UnityEngine;

namespace Aya.Extension
{
    public static class QuaternionExtension
    {
        #region Deconstruct & With
        
        public static void Deconstruct(in this Quaternion quaternion, out float x, out float y, out float z, out float w)
        {
            x = quaternion.x;
            y = quaternion.y;
            z = quaternion.z;
            w = quaternion.w;
        }

        public static Quaternion With(in this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            var result = new Quaternion(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);
            return result;
        }

        public static Quaternion WithEuler(this Quaternion quaternion, float? x = null, float? y = null, float? z = null)
        {
            var e = quaternion.eulerAngles;
            var result = Quaternion.Euler(x ?? e.x, y ?? e.y, z ?? e.z);
            return result;
        }

        public static Quaternion WithAngleAxis(this Quaternion quaternion, float? angle = null, in Vector3? axis = null)
        {
            quaternion.ToAngleAxis(out var selfAngle, out var selfAxis);
            var result = Quaternion.AngleAxis(angle ?? selfAngle, axis ?? selfAxis);
            return result;
        } 

        #endregion

        #region Math

        public static Quaternion Pow(this Quaternion quaternion, float power)
        {
            var inputMagnitude = quaternion.Magnitude();
            var nHat = new Vector3(quaternion.x, quaternion.y, quaternion.z).normalized;
            var vectorBit = new Quaternion(nHat.x, nHat.y, nHat.z, 0).ScalarMultiply(power * Mathf.Acos(quaternion.w / inputMagnitude)).Exp();
            var result = vectorBit.ScalarMultiply(Mathf.Pow(inputMagnitude, power));
            return result;
        }

        public static Quaternion Exp(this Quaternion quaternion)
        {
            var inputA = quaternion.w;
            var inputV = new Vector3(quaternion.x, quaternion.y, quaternion.z);
            var outputA = Mathf.Exp(inputA) * Mathf.Cos(inputV.magnitude);
            var outputV = Mathf.Exp(inputA) * (inputV.normalized * Mathf.Sin(inputV.magnitude));
            var result = new Quaternion(outputV.x, outputV.y, outputV.z, outputA);
            return result;
        }

        public static float Magnitude(this Quaternion quaternion)
        {
            var result = Mathf.Sqrt(quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w);
            return result;
        }

        public static Quaternion ScalarMultiply(this Quaternion quaternion, float scalar)
        {
            var result = new Quaternion(quaternion.x * scalar, quaternion.y * scalar, quaternion.z * scalar, quaternion.w * scalar);
            return result;
        }

        #endregion
    }
}