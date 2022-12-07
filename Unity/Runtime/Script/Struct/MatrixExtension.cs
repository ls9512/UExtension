using UnityEngine;

namespace Aya.Extension
{
    public static class MatrixExtensions
    {
        #region Deconstruct
        
        public static void Deconstruct(this Matrix4x4 matrix,
                               out Vector4 column0, out Vector4 column1,
                               out Vector4 column2, out Vector4 column3)
        {
            column0 = matrix.GetColumn(0); column1 = matrix.GetColumn(1);
            column2 = matrix.GetColumn(2); column3 = matrix.GetColumn(3);
        }

        public static void Deconstruct(in this Matrix4x4 matrix,
                                       out float m00, out float m01, out float m02, out float m03,
                                       out float m10, out float m11, out float m12, out float m13,
                                       out float m20, out float m21, out float m22, out float m23,
                                       out float m30, out float m31, out float m32, out float m33)
        {
            m00 = matrix.m00; m01 = matrix.m01; m02 = matrix.m02; m03 = matrix.m03;
            m10 = matrix.m10; m11 = matrix.m11; m12 = matrix.m12; m13 = matrix.m13;
            m20 = matrix.m20; m21 = matrix.m21; m22 = matrix.m22; m23 = matrix.m23;
            m30 = matrix.m30; m31 = matrix.m31; m32 = matrix.m32; m33 = matrix.m33;
        }

        #endregion

        #region With
        
        public static Matrix4x4 With(this Matrix4x4 matrix,
                             in Vector4? column0 = null, in Vector4? column1 = null,
                             in Vector4? column2 = null, in Vector4? column3 = null)
        {
            var result = new Matrix4x4(
                column0 ?? matrix.GetColumn(0), column1 ?? matrix.GetColumn(1),
                column2 ?? matrix.GetColumn(2), column3 ?? matrix.GetColumn(3)
            );
            return result;
        }

        public static Matrix4x4 With(in this Matrix4x4 matrix,
                                     float? m00 = null, float? m01 = null, float? m02 = null, float? m03 = null,
                                     float? m10 = null, float? m11 = null, float? m12 = null, float? m13 = null,
                                     float? m20 = null, float? m21 = null, float? m22 = null, float? m23 = null,
                                     float? m30 = null, float? m31 = null, float? m32 = null, float? m33 = null)
        {
            var result = new Matrix4x4
            {
                m00 = m00 ?? matrix.m00,
                m01 = m01 ?? matrix.m01,
                m02 = m02 ?? matrix.m02,
                m03 = m03 ?? matrix.m03,
                m10 = m10 ?? matrix.m10,
                m11 = m11 ?? matrix.m11,
                m12 = m12 ?? matrix.m12,
                m13 = m13 ?? matrix.m13,
                m20 = m20 ?? matrix.m20,
                m21 = m21 ?? matrix.m21,
                m22 = m22 ?? matrix.m22,
                m23 = m23 ?? matrix.m23,
                m30 = m30 ?? matrix.m30,
                m31 = m31 ?? matrix.m31,
                m32 = m32 ?? matrix.m32,
                m33 = m33 ?? matrix.m33
            };
            return result;
        } 

        #endregion
    }
}