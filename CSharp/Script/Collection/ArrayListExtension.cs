using System;
using System.Collections;

namespace Aya.Extension
{
    public static partial class ArrayListExtension
    {
        internal static Random Rand = new Random();

        #region Null / Empty

        public static bool IsNullOrEmpty(this ArrayList arrayList)
        {
            var result = arrayList == null || arrayList.Count == 0;
            return result;
        }

        public static bool IsEmpty(this ArrayList arrayList)
        {
            if (arrayList == null)
            {
                throw new NullReferenceException();
            }

            var result = arrayList.Count == 0;
            return result;
        }

        #endregion

        #region Get

        public static object First(this ArrayList arrayList)
        {
            var result = arrayList != null && arrayList.Count > 0 ? arrayList[0] : null;
            return result;
        }

        public static T First<T>(this ArrayList arrayList)
        {
            var result = arrayList != null && arrayList.Count > 0 ? (T)arrayList[0] : default(T);
            return result;
        }

        public static object Last(this ArrayList arrayList)
        {
            var result = arrayList != null && arrayList.Count > 0 ? arrayList[arrayList.Count - 1] : null;
            return result;
        }

        public static T Last<T>(this ArrayList arrayList)
        {
            var result = arrayList != null && arrayList.Count > 0 ? (T)arrayList[arrayList.Count - 1] : default(T);
            return result;
        }

        public static object Random(this ArrayList arrayList)
        {
            var result = arrayList.Count > 0 ? arrayList[Rand.Next(0, arrayList.Count)] : null;
            return result;
        }

        public static T Random<T>(this ArrayList arrayList)
        {
            var result = arrayList.Count > 0 ? (T)arrayList[Rand.Next(0, arrayList.Count)] : default(T);
            return result;
        }

        #endregion

        #region Sort

        public static ArrayList RandSort(this ArrayList arrayList)
        {
            var count = arrayList.Count * 3;
            for (var i = 0; i < count; i++)
            {
                var index1 = Rand.Next(0, arrayList.Count);
                var item1 = arrayList[index1];
                var index2 = Rand.Next(0, arrayList.Count);
                var item2 = arrayList[index2];
                var temp = item2;
                arrayList[index2] = item1;
                arrayList[index1] = temp;
            }

            return arrayList;
        }

        public static ArrayList SortAsc(this ArrayList arrayList, params Func<object, IComparable>[] keyGetters)
        {
            arrayList.Sort(ComparerUtil.GetAscComparer(keyGetters));
            return arrayList;
        }

        public static ArrayList SortDesc(this ArrayList arrayList, params Func<object, IComparable>[] keyGetters)
        {
            arrayList.Sort(ComparerUtil.GetDescComparer(keyGetters));
            return arrayList;
        }

        public static ArrayList Sort(this ArrayList arrayList, params Func<object, (IComparable, SortMode)>[] keyGetters)
        {
            arrayList.Sort(ComparerUtil.GetCustomComparer(keyGetters));
            return arrayList;
        }

        #endregion
    }
}
