using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class IListExtension
    {
        #region First / Last

        public static T First<T>(this IList<T> list)
        {
            var result = list != null && list.Count > 0 ? list[0] : default(T);
            return result;
        }

        public static T First<T>(this IList<T> list, Predicate<T> predicate)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (predicate(item)) return item;
            }

            return default(T);
        }

        public static List<T> First<T>(this IList<T> list, int count, Predicate<T> predicate = null)
        {
            if (list == null) return null;
            var result = new List<T>();
            var listCount = list.Count;
            for (var i = 0; result.Count < count && i < listCount; i++)
            {
                var item = list[i];
                if (predicate != null)
                {
                    if (predicate(item))
                    {
                        result.Add(item);
                    }
                }
                else
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static T Last<T>(this IList<T> list)
        {
            var result = list != null && list.Count > 0 ? list[list.Count - 1] : default(T);
            return result;
        }

        public static T Last<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (predicate(item)) return item;
            }

            return default(T);
        }

        public static List<T> Last<T>(this IList<T> list, int count, Predicate<T> predicate = null)
        {
            if (list == null) return null;
            var result = new List<T>();
            for (var i = list.Count - 1; result.Count < count && i >= 0; i--)
            {
                var item = list[i];
                if (predicate != null)
                {
                    if (predicate(item))
                    {
                        result.Add(item);
                    }
                }
                else
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion

        #region Min / Max

        public static T Min<T>(this IList<T> list) where T : IComparable
        {
            return Min(list, i => i);
        }

        public static T Min<T>(this IList<T> list, Func<T, IComparable> keyGetter) where T : IComparable
        {
            if (list == null || list.Count == 0) return default;
            var listCount = list.Count;
            var min = keyGetter(list[0]);
            var index = 0;
            for (var i = 1; i < listCount; i++)
            {
                var current = keyGetter(list[i]);
                if (current.CompareTo(min) < 0)
                {
                    min = current;
                    index = i;
                }
            }

            return list[index];
        }

        public static List<T> Min<T>(this IList<T> list, int count) where T : IComparable
        {
            return Min(list, i => i, count);
        }

        public static List<T> Min<T>(this IList<T> list, Func<T, IComparable> keyGetter, int count)
        {
            if (list == null || list.Count == 0) return default;
            var listCount = list.Count;
            if (count > listCount) throw new ArgumentOutOfRangeException();
            var indexList = new List<int>();
            for (var i = 0; i < listCount; i++)
            {
                indexList.Add(i);
            }

            indexList.SortAsc(i => keyGetter(list[i]));
            var result = new List<T>();
            for (var i = 0; i < count; i++)
            {
                result.Add(list[indexList[i]]);
            }

            return result;
        }


        public static T Max<T>(this IList<T> list) where T : IComparable
        {
            return Max(list, i => i);
        }

        public static T Max<T>(this IList<T> list, Func<T, IComparable> keyGetter) where T : IComparable
        {
            if (list == null || list.Count == 0) return default;
            var listCount = list.Count;
            var max = keyGetter(list[0]);
            var index = 0;
            for (var i = 1; i < listCount; i++)
            {
                var current = keyGetter(list[i]);
                if (current.CompareTo(max) > 0)
                {
                    max = current;
                    index = i;
                }
            }

            return list[index];
        }

        public static List<T> Max<T>(this IList<T> list, int count) where T : IComparable
        {
            return Max(list, i => i, count);
        }

        public static List<T> Max<T>(this IList<T> list, Func<T, IComparable> keyGetter, int count)
        {
            if (list == null || list.Count == 0) return default;
            var listCount = list.Count;
            if (count > listCount) throw new ArgumentOutOfRangeException();

            var indexList = new List<int>();
            for (var i = 0; i < listCount; i++)
            {
                indexList.Add(i);
            }

            indexList.SortDesc(i => keyGetter(list[i]));
            var result = new List<T>();
            for (var i = 0; i < count; i++)
            {
                result.Add(list[indexList[i]]);
            }

            return result;
        }

        #endregion

        #region Contains

        public static bool Contains<T>(this IList<T> list, Predicate<T> predicate)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var temp = list[i];
                if (predicate(temp)) return true;
            }

            return false;
        }

        #endregion

        #region To List

        public static List<TResult> ToList<T, TResult>(this IList<T> list, Func<T, TResult> selector)
        {
            var result = new List<TResult>();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                var value = selector(item);
                result.Add(value);
            }

            return result;
        }

        #endregion

        #region To Dictionary

        public static Dictionary<TKey, T> ToDictionary<TKey, T>(this IList<T> list, Func<T, TKey> getKeyFunc)
        {
            var result = new Dictionary<TKey, T>();
            if (list == null) return result;
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                result.Add(getKeyFunc(item), item);
            }

            return result;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue, T>(this IList<T> list, Func<T, TKey> getKeyFunc, Func<T, TValue> getValueFunc)
        {
            var result = new Dictionary<TKey, TValue>();
            if (list == null) return result;
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                result.Add(getKeyFunc(item), getValueFunc(item));
            }

            return result;
        }

        #endregion
    }
}