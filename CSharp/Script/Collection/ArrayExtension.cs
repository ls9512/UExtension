using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class ArrayExtension
    {
        #region Null / Empty

        public static bool IsNullOrEmpty(this Array array)
        {
            var result = array == null || array.Length == 0;
            return result;
        }

        public static bool IsEmpty(this Array array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            var result = array.Length == 0;
            return result;
        }

        #endregion

        #region Index

        public static bool WithinIndex(this Array array, int index)
        {
            var result = array != null && index >= 0 && index < array.Length;
            return result;
        }

        public static bool WithinIndex(this Array array, int index, int dimension)
        {
            return array != null && index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
        }

        #endregion

        #region Switch

        public static T[] SwitchPos<T>(this T[] array, int index1, int index2)
        {
            (array[index1], array[index2]) = (array[index2], array[index1]);
            return array;
        }

        #endregion

        #region Find

        public static List<T> Find<T>(this T[] array, Predicate<T> predicate)
        {
            var ret = new List<T>();
            for (var i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (predicate(item))
                {
                    ret.Add(item);
                }
            }

            return ret;
        }

        public static int IndexOf<T>(this T[] array, object item)
        {
            var index = 0;
            foreach (var i in array)
            {
                if (item.Equals(i)) break;
                index++;
            }

            if (index >= array.Length) index = -1;
            return index;
        }

        #endregion

        #region Combine

        public static T[] CombineArray<T>(this T[] array, T[] other)
        {
            if (array == default(T[]) || other == default(T[])) return array;
            var initialSize = array.Length;
            Array.Resize<T>(ref array, initialSize + other.Length);
            Array.Copy(other, other.GetLowerBound(0), array, initialSize, other.Length);
            return array;
        }

        #endregion

        #region Clear

        public static Array ClearAt(this Array array, int index)
        {
            if (array == null) return null;
            if (index >= 0 && index < array.Length)
            {
                Array.Clear(array, index, 1);
            }

            return array;
        }

        public static T[] ClearAt<T>(this T[] array, int index)
        {
            if (array == null) return null;
            if (index >= 0 && index < array.Length)
            {
                array[index] = default(T);
            }

            return array;
        }

        public static Array ClearAll(this Array array)
        {
            if (array != null)
            {
                Array.Clear(array, 0, array.Length);
            }

            return array;
        }

        public static T[] ClearAll<T>(this T[] array)
        {
            if (array == null) return null;
            for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); ++i)
            {
                array[i] = default(T);
            }

            return array;
        }

        #endregion

        #region Block Copy

        public static T[] BlockCopy<T>(this T[] array, int index, int length)
        {
            var result = BlockCopy(array, index, length, false);
            return result;
        }

        public static T[] BlockCopy<T>(this T[] array, int index, int length, bool padToLength)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            var n = length;
            T[] result = null;
            if (array.Length < index + length)
            {
                n = array.Length - index;
                if (padToLength)
                {
                    result = new T[length];
                }
            }

            if (result == null) result = new T[n];
            Array.Copy(array, index, result, 0, n);
            return result;
        }

        public static IEnumerable<T[]> BlockCopy<T>(this T[] array, int count, bool padToLength = false)
        {
            for (var i = 0; i < array.Length; i += count)
            {
                yield return array.BlockCopy(i, count, padToLength);
            }
        }

        #endregion

        #region Sort

        internal static Random Rand = new Random();

        public static T[] Sort<T>(this T[] array, Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                return array;
            }

            Array.Sort(array, comparison);
            return array;
        }

        public static T[] Sort<T>(this T[] array, int index, int length, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                return array;
            }

            Array.Sort(array, index, length, comparer);
            return array;
        }

        public static T[] RandSort<T>(this T[] array)
        {
            var count = array.Length * 3;
            for (var i = 0; i < count; i++)
            {
                var index1 = Rand.Next(0, array.Length);
                var item1 = array[index1];
                var index2 = Rand.Next(0, array.Length);
                var item2 = array[index2];
                var temp = item2;
                array[index2] = item1;
                array[index1] = temp;
            }

            return array;
        }

        public static T[] SortAsc<T>(this T[] array) where T : IComparable
        {
            array.SortAsc(i => i);
            return array;
        }

        public static T[] SortAsc<T>(this T[] array, params Func<T, IComparable>[] keyGetters)
        {
            array.Sort(ComparisonUtil.GetAscComparison(keyGetters));
            return array;
        }

        public static T[] SortAsc<T>(this T[] array, int index, int length, params Func<T, IComparable>[] keyGetters)
        {
            array.Sort(index, length, ComparerUtil.GetAscComparer(keyGetters));
            return array;
        }

        public static T[] SortDesc<T>(this T[] array) where T : IComparable
        {
            array.SortDesc(i => i);
            return array;
        }

        public static T[] SortDesc<T>(this T[] array, params Func<T, IComparable>[] keyGetters)
        {
            array.Sort(ComparisonUtil.GetDescComparison(keyGetters));
            return array;
        }

        public static T[] SortDesc<T>(this T[] array, int index, int length, params Func<T, IComparable>[] keyGetters)
        {
            array.Sort(index, length, ComparerUtil.GetDescComparer(keyGetters));
            return array;
        }

        public static T[] Sort<T>(this T[] array, params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            array.Sort(ComparisonUtil.GetCustomComparison(keyGetters));
            return array;
        }

        public static T[] Sort<T>(this T[] array, int index, int length, params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            array.Sort(index, length, ComparerUtil.GetCustomComparer(keyGetters));
            return array;
        }

        #endregion

        #region Convert

        public static object[] AsObjects<T>(this T[] array)
        {
            var result = new object[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            return result;
        }

        #endregion
    }
}
