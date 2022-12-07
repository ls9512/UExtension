using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class IEnumerableExtension
    {
        #region Null / Empty / Any

        public static bool Any<T>(this IEnumerable<T> source)
        {
            if (source == null) return false;
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext()) return true;
            }

            return false;
        }

        public static bool Any<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) return false;
            foreach (var item in source)
            {
                if (predicate(item)) return true;
            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            var result = source == null || !source.Any();
            return result;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source.Any();
        }

        #endregion

        #region Get

        public static T Has<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) return item;
            }

            return default(T);
        }

        public static T Find<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            var ret = default(T);
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    ret = item;
                    break;
                }
            }

            return ret;
        }

        public static List<T> FindAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item)) list.Add(item);
            }

            return list;
        }

        public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector, out TValue maxValue)
            where TValue : IComparable<TValue>
        {
            T maxItem = default;
            maxValue = default(TValue);
            foreach (var item in source)
            {
                if (item == null) continue;
                var itemValue = selector(item);
                if ((maxItem != null) && (itemValue.CompareTo(maxValue) <= 0)) continue;
                maxValue = itemValue;
                maxItem = item;
            }

            return maxItem;
        }

        public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter)
            where TValue : IComparable<TValue>
        {
            var result = source.Max(keyGetter, out _);
            return result;
        }

        public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter, out TValue minValue)
            where TValue : IComparable
        {
            T minItem = default;
            minValue = default(TValue);
            foreach (var item in source)
            {
                if (item == null) continue;
                var itemValue = keyGetter(item);
                if ((minItem != null) && (itemValue.CompareTo(minValue) >= 0)) continue;
                minValue = itemValue;
                minItem = item;
            }

            return minItem;
        }

        public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
            where TValue : IComparable
        {
            var result = source.Min(selector, out _);
            return result;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector, bool allowNull = true)
        {
            foreach (var item in source)
            {
                var select = selector(item);
                if (allowNull || !Equals(select, default(T)))
                {
                    yield return select;
                }
            }
        }

        public static T First<T>(this IEnumerable<T> source)
        {
            if (source == null) return default(T);
            foreach (var item in source)
            {
                return item;
            }

            return default(T);
        }

        public static IList<T> First<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) return null;
            var result = new List<T>();
            var counter = 0;
            foreach (var item in source)
            {
                result.Add(item);
                counter++;
                if (counter >= count) break;
            }

            return result;
        }

        public static T Last<T>(this IEnumerable<T> source)
        {
            if (source == null) return default(T);
            var result = default(T);
            foreach (var item in source)
            {
                result = item;
            }

            return result;
        }

        public static IList<T> Last<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) return null;
            var result = new List<T>();
            var sum = 0;
            foreach (var _ in source)
            {
                sum++;
            }

            var counter = 0;
            foreach (var item in source)
            {
                counter++;
                if (counter > sum - count)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion

        #region Foreach

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null) return source;
            foreach (var item in source)
            {
                action(item);
            }

            return source;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Func<T, bool> selector, Action<T> action)
        {
            if (selector == null || action == null) return source;
            foreach (var item in source)
            {
                if (!selector(item)) continue;
                action(item);
            }

            return source;
        }

        #endregion

        #region Array \ List \ HashSet

        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                list.Add(item);
            }

            return list;
        }

        public static List<TResult> ToList<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            var list = new List<TResult>();
            foreach (var item in source)
            {
                list.Add(selector(item));
            }

            return list;
        }

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                list.Add(item);
            }

            return list.ToArray();
        }

        public static TResult[] ToArray<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            var list = new List<TResult>();
            foreach (var item in source)
            {
                list.Add(selector(item));
            }

            return list.ToArray();
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            var result = new HashSet<T>(source);
            return result;
        }

        #endregion
    }
}