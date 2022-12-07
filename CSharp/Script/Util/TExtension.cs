using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Aya.Extension
{
    public static class TExtension
    {
        #region Null / Empty

        public static bool IsNull<T>(this T value)
        {
            var result = ReferenceEquals(value, null);
            return result;
        }

        public static bool IsNotNull<T>(this T value)
        {
            var result = !ReferenceEquals(value, null);
            return result;
        }

        public static bool IsEmpty<T>(this T value) where T : struct
        {
            var result = value.Equals(default(T));
            return result;
        }

        public static bool IsNotEmpty<T>(this T value) where T : struct
        {
            var result = value.IsEmpty() == false;
            return result;
        }

        public static T? ToNullable<T>(this T value) where T : struct
        {
            var result = value.IsEmpty() ? null : (T?) value;
            return result;
        }

        #endregion

        #region Equal

        public static bool EqualsAny<T>(this T value, params T[] values)
        {
            if (values == null) return false;
            for (var i = 0; i < values.Length; i++)
            {
                var arg = values[i];
                if (value.Equals(arg)) return true;
            }

            return false;
        }

        public static bool EqualsNone<T>(this T value, params T[] values)
        {
            var result = value.EqualsAny(values) == false;
            return result;
        }

        #endregion

        #region Deep Copy

        public static T DeepCopy<T>(this T target)
        {
            T obj2;
            var formatter = new BinaryFormatter();
            var serializationStream = new MemoryStream();
            try
            {
                formatter.Serialize(serializationStream, target);
                serializationStream.Position = 0L;
                obj2 = (T)formatter.Deserialize(serializationStream);
            }
            finally
            {
                serializationStream.Close();
            }

            return obj2;
        }

        #endregion

        #region Flag

        public static bool HasFlags<T>(this T value, params T[] flags) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("variable must be an Enum", nameof(value));
            foreach (var flag in flags)
            {
                if (!Enum.IsDefined(typeof(T), flag))
                {
                    return false;
                }

                var numFlag = Convert.ToUInt64(flag);
                if ((Convert.ToUInt64(value) & numFlag) != numFlag)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}