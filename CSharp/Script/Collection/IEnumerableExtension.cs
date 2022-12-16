using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class IEnumerableExtension
    {
        #region Null / Empty

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

        #region Find

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

        #region HashSet

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            var result = new HashSet<T>(source);
            return result;
        }

        #endregion
    }
}