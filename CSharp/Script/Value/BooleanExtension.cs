using System;

namespace Aya.Extension
{
    public static partial class BooleanExtensions
    {
        #region Convert
        
        public static string ToYesNoString(this bool boolean)
        {
            var result = boolean ? "Yes" : "No";
            return result;
        }

        public static int ToBinaryNumber(this bool boolean)
        {
            var result = boolean ? 1 : 0;
            return result;
        }

        #endregion

        #region Logic 

        // https://github.com/TeodorVecerdi/UnityCommons/blob/main/Runtime/Code/Extensions/BooleanExtensions.cs

        #region And

        public static bool And(this bool boolean, bool other)
        {
            return boolean && other;
        }

        public static bool And(this bool boolean, Func<bool> other)
        {
            return other != null && boolean && other();
        }

        public static bool And<T>(this bool boolean, Func<T, bool> other, T value)
        {
            return other != null && boolean && other(value);
        }

        public static bool And<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
        {
            return other != null && boolean && other(value1, value2);
        }

        public static bool And<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
        {
            return other != null && boolean && other(value1, value2, value3);
        }

        public static bool And<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return other != null && boolean && other(value1, value2, value3, value4);
        }

        public static bool And<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return other != null && boolean && other(value1, value2, value3, value4, value5);
        }

        #endregion

        #region Or

        public static bool Or(this bool boolean, bool other)
        {
            return boolean || other;
        }

        public static bool Or(this bool boolean, Func<bool> other)
        {
            return other == null ? boolean : boolean || other();
        }

        public static bool Or<T>(this bool boolean, Func<T, bool> other, T value)
        {
            return other == null ? boolean : boolean || other(value);
        }

        public static bool Or<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
        {
            return other == null ? boolean : boolean || other(value1, value2);
        }

        public static bool Or<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
        {
            return other == null ? boolean : boolean || other(value1, value2, value3);
        }

        public static bool Or<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return other == null ? boolean : boolean || other(value1, value2, value3, value4);
        }

        public static bool Or<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return other == null ? boolean : boolean || other(value1, value2, value3, value4, value5);
        }

        #endregion

        #region AndNot

        public static bool AndNot(this bool boolean, bool other)
        {
            return boolean && !other;
        }

        public static bool AndNot(this bool boolean, Func<bool> other)
        {
            return other != null && boolean && !other();
        }

        public static bool AndNot<T>(this bool boolean, Func<T, bool> other, T value)
        {
            return other != null && boolean && !other(value);
        }

        public static bool AndNot<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
        {
            return other != null && boolean && !other(value1, value2);
        }

        public static bool AndNot<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
        {
            return other != null && boolean && !other(value1, value2, value3);
        }

        public static bool AndNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return other != null && boolean && !other(value1, value2, value3, value4);
        }

        public static bool AndNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return other != null && boolean && !other(value1, value2, value3, value4, value5);
        }

        #endregion

        #region OrNot

        public static bool OrNot(this bool boolean, bool other)
        {
            return boolean || !other;
        }

        public static bool OrNot(this bool boolean, Func<bool> other)
        {
            return other == null ? boolean : boolean || !other();
        }

        public static bool OrNot<T>(this bool boolean, Func<T, bool> other, T value)
        {
            return other == null ? boolean : boolean || !other(value);
        }

        public static bool OrNot<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)
        {
            return other == null ? boolean : boolean || !other(value1, value2);
        }

        public static bool OrNot<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)
        {
            return other == null ? boolean : boolean || !other(value1, value2, value3);
        }

        public static bool OrNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return other == null ? boolean : boolean || !other(value1, value2, value3, value4);
        }

        public static bool OrNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return other == null ? boolean : boolean || !other(value1, value2, value3, value4, value5);
        }

        #endregion

        #endregion
    }
}
