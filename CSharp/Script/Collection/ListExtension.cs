using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class ListExtension
    {
        internal static Random Rand = new Random();

        #region Sort

        public static List<T> RandSort<T>(this List<T> list)
        {
            var count = list.Count * 3;
            for (var i = 0; i < count; i++)
            {
                var index1 = Rand.Next(0, list.Count);
                var item1 = list[index1];
                var index2 = Rand.Next(0, list.Count);
                var item2 = list[index2];
                var temp = item2;
                list[index2] = item1;
                list[index1] = temp;
            }

            return list;
        }

        public static List<T> SortAsc<T>(this List<T> list) where T : IComparable
        {
            list.SortAsc(i => i);
            return list;
        }

        public static List<T> SortAsc<T>(this List<T> list, params Func<T, IComparable>[] keyGetters)
        {
            var compression = ComparisonUtil.GetAscComparison(keyGetters);
            list.Sort(compression);
            return list;
        }

        public static List<T> SortDesc<T>(this List<T> list) where T : IComparable
        {
            list.SortDesc(i => i);
            return list;
        }

        public static List<T> SortDesc<T>(this List<T> list, params Func<T, IComparable>[] keyGetters)
        {
            var compression = ComparisonUtil.GetDescComparison(keyGetters);
            list.Sort(compression);
            return list;
        }

        public static List<T> Sort<T>(this List<T> list, params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            var compression = ComparisonUtil.GetCustomComparison(keyGetters);
            list.Sort(compression);
            return list;
        }

        #endregion
    }
}
