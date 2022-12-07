using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class IListExtension
    {
        internal static Random Rand = new Random();

        #region Null / Empty

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            var result = list == null || list.Count == 0;
            return result;
        }

        public static bool IsEmpty<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }

            var result = list.Count == 0;
            return result;
        }

        #endregion

        #region Switch

        public static IList<T> SwitchPos<T>(this IList<T> list, int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);
            return list;
        }

        #endregion

        #region Add / Insert

        public static bool AddUnique<T>(this IList<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            }

            return false;
        }

        public static bool InsertUnique<T>(this IList<T> list, int index, T item)
        {
            if (list.Contains(item)) return false;
            list.Insert(index, item);
            return true;
        }

        public static int InsertRangeUnique<T>(this IList<T> list, int startIndex, IEnumerable<T> items)
        {
            var index = startIndex;
            var count = 0;
            foreach (var item in items)
            {
                if (list.Contains(item)) continue;
                list.Insert(index, item);
                count++;
                index++;
            }

            return count;
        }

        #endregion

        #region Get

        public static T TryGetValue<T>(this IList<T> list, T value)
        {
            var index = list.IndexOf(value);
            var result = index < 0 ? default(T) : value;
            return result;
        }

        public static T GetAndRemove<T>(this IList<T> list, T value)
        {
            var result = TryGetValue(list, value);
            if (result != null) list.Remove(result);
            return result;
        }

        public static T GetAndRemove<T>(this IList<T> list, int index)
        {
            if (index > list.Count - 1) return default(T);
            var result = list[index];
            list.RemoveAt(index);
            return result;
        }

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

        #region Get Before / After

        public static T Before<T>(this IList<T> list, T item)
        {
            var index = list.IndexOf(item);
            var result = index < 1 ? default(T) : list[index - 1];
            return result;
        }

        public static T After<T>(this IList<T> list, T item)
        {
            var index = list.IndexOf(item);
            var result = index > list.Count - 2 ? default(T) : list[index + 1];
            return result;
        }

        #endregion

        #region Get Find

        public static T Find<T>(this IList<T> list, Predicate<T> predicate)
        {
            var result = default(T);
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (predicate(item))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static List<T> FindAll<T>(this IList<T> list, Predicate<T> predicate)
        {
            var result = new List<T>();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (predicate(item)) result.Add(item);
            }

            return result;
        }

        #endregion

        #region Max / Min

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

        #endregion

        #region Get Random

        public static T Random<T>(this IList<T> list)
        {
            var result = list.Count > 0 ? list[Rand.Next(0, list.Count)] : default(T);
            return result;
        }

        public static T Random<T>(this IList<T> list, Predicate<T> predicate)
        {
            var indexes = new List<int>();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                if (predicate(list[i]))
                {
                    indexes.Add(i);
                }
            }

            if (indexes.Count == 0) return default(T);
            var randIndex = indexes.Random();
            var result = list[randIndex];
            return result;
        }

        public static List<T> Random<T>(this IList<T> list, int count, bool allowRepeat = false)
        {
            var result = new List<T>();
            var listCount = list.Count;
            if (count > listCount)
            {
                throw new IndexOutOfRangeException();
            }

            for (var i = 0; i < count; i++)
            {
                var item = list[Rand.Next(0, listCount)];
                if (!allowRepeat && result.Contains(item))
                {
                    i--;
                    continue;
                }

                result.Add(item);
            }

            return result;
        }

        public static T Random<T>(this IList<T> list, Func<T, int> weightGetter)
        {
            var weightCount = 0;
            for (var i = 0; i < list.Count; i++)
            {
                weightCount += weightGetter(list[i]);
            }

            var rand = Rand.Next(0, weightCount);
            weightCount = 0;
            var index = -1;
            do
            {
                weightCount += weightGetter(list[index + 1]);
                index++;
            } while (weightCount < rand);

            var result = list[index];
            return result;
        }

        public static List<T> Random<T>(this IList<T> list, Func<T, int> weightGetter, int count)
        {
            var listCount = list.Count;
            var result = new List<T>();
            do
            {
                var item = list.Random(weightGetter);
                if (result.Contains(item)) continue;
                result.Add(item);
            } while (result.Count < count && result.Count < listCount);

            return result;
        }

        #endregion

        #region Index

        public static int IndexOf<T>(this IList<T> list, Func<T, bool> comparison)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                if (comparison(list[i]))
                {
                    return i;
                }
            }

            return -1;
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

        #endregion=

        #region Foreach

        public static IList<T> ForEach<T>(this IList<T> list, Action<T> action)
        {
            if (action == null) return list;
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                action(item);
            }

            return list;
        }

        public static IList<T> ForEach<T>(this IList<T> list, Func<T, bool> selector, Action<T> action)
        {
            if (selector == null || action == null) return list;
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (!selector(item)) continue;
                action(item);
            }

            return list;
        }

        public static IList<T> ForEachReverse<T>(this IList<T> list, Action<T> action)
        {
            if (action == null) return list;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                action(item);
            }

            return list;
        }

        public static IList<T> ForEachReverse<T>(this IList<T> list, Func<T, bool> selector, Action<T> action)
        {
            if (selector == null || action == null) return list;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (!selector(item)) continue;
                action(item);
            }

            return list;
        }

        #endregion

        #region Move Up / Down

        public static bool MoveUp<T>(this IList<T> list, T item, int step = 1)
        {
            if (list == null || !list.Contains(item) || step < 1) return false;
            var index = list.IndexOf(item);
            if (index <= step - 1) return false;
            list.Remove(item);
            list.Insert(index - step, item);
            return true;
        }

        public static bool MoveDown<T>(this IList<T> list, T item, int step = 1)
        {
            if (list == null || !list.Contains(item) || step < 1) return false;
            var index = list.IndexOf(item);
            if (index >= list.Count - step) return false;
            list.Remove(item);
            list.Insert(index + step, item);
            return true;
        }

        #endregion

        #region To Dictionary / List

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

        #region Remove

        public static IList<T> RemoveStartRepeat<T>(this IList<T> list, bool persistOne = true)
        {
            var first = list.First();
            if (first == null) return list;
            var remove = false;
            var index = 1;
            var count = list.Count;
            while (index < count && list[index].Equals(first))
            {
                var temp = list[index];
                if (temp.Equals(first))
                {
                    remove = true;
                    list.RemoveAt(index);
                }
            }

            if (remove && !persistOne)
            {
                list.RemoveAt(0);
            }

            return list;
        }

        public static IList<T> RemoveEndRepeat<T>(this IList<T> list, bool persistOne = true)
        {
            var last = list.Last();
            if (last == null) return list;
            var remove = false;
            var count = list.Count;
            for (var i = count - 2; i >= 0; i--)
            {
                var temp = list[i];
                if (temp.Equals(last))
                {
                    remove = true;
                    list.RemoveAt(i + 1);
                }
            }

            if (remove && !persistOne)
            {
                list.RemoveAt(count - 1);
            }

            return list;
        }

        public static IList<T> Distinct<T>(this IList<T> list)
        {
            var ret = new List<T>();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var temp = list[i];
                if (!ret.Contains(temp))
                {
                    ret.Add(temp);
                }
            }

            list.Clear();
            var retCount = ret.Count;
            for (var i = 0; i < retCount; i++)
            {
                var temp = ret[i];
                list.Add(temp);
            }

            return list;
        }

        #endregion
    }
}