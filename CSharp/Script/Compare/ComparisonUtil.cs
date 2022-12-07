using System;

namespace Aya.Extension
{
    public static partial class ComparisonUtil
    {
        #region Comparison T,IComparable

        public static Comparison<T> GetAscComparison<T>(params Func<T, IComparable>[] keyGetters)
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    diff = getter(t1).CompareTo(getter(t2));
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        public static Comparison<T> GetDescComparison<T>(params Func<T, IComparable>[] keyGetters)
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    diff = getter(t2).CompareTo(getter(t1));
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        public static Comparison<T> GetCustomComparison<T>(params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    var (v1, sortMode) = getter(t1);
                    var (v2, _) = getter(t2);
                    diff = sortMode == SortMode.Asc ? v1.CompareTo(v2) : v2.CompareTo(v1);
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        #endregion

        #region Comparison T,IComparable<TValue>

        public static Comparison<T> GetAscComparison<T, TValue>(params Func<T, TValue>[] keyGetters) where TValue : IComparable<TValue>
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    diff = getter(t1).CompareTo(getter(t2));
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        public static Comparison<T> GetDescComparison<T, TValue>(params Func<T, TValue>[] keyGetters) where TValue : IComparable<TValue>
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    diff = getter(t2).CompareTo(getter(t1));
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        public static Comparison<T> GetCustomComparison<T, TValue>(params Func<T, (TValue, SortMode)>[] keyGetters) where TValue : IComparable<TValue>
        {
            var length = keyGetters.Length;
            int Comparison(T t1, T t2)
            {
                var index = 0;
                int diff;
                do
                {
                    var getter = keyGetters[index];
                    var (v1, sortMode) = getter(t1);
                    var (v2, _) = getter(t2);
                    diff = sortMode == SortMode.Asc ? v1.CompareTo(v2) : v2.CompareTo(v1);
                    index++;
                } while (index < length && diff == 0);

                return diff;
            }

            return Comparison;
        }

        #endregion
    }
}
