using System;

namespace Aya.Extension
{
    public static partial class ArrayExtension
    {
        #region First / Last
      
        public static T First<T>(this T[] array)
        {
            if (array.Length == 0) return default(T);
            return array[0];
        }

        public static T First<T>(this T[] array, Predicate<T> predicate)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this T[] array)
        {
            if (array.Length == 0) return default(T);
            return array[array.Length - 1];
        }

        public static T Last<T>(this T[] array, Predicate<T> predicate)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                var item = array[i];
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        #endregion

        #region Contains

        public static bool Contains<T>(this T[] array, T item)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                if (temp.Equals(item)) return true;
            }

            return false;
        }

        public static bool Contains<T>(this T[] array, Predicate<T> predicate)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                if (predicate(temp)) return true;
            }

            return false;
        }

        #endregion
    }
}