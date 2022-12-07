using System;
using System.Collections;
using System.Collections.Generic;

namespace Aya.Extension
{
    public enum SortMode
    {
        Asc = 0,
        Desc = 1,
    }

    public static partial class ComparerUtil
    {
        #region IComparer

        public static IComparer GetAscComparer(params Func<object, IComparable>[] keyGetters)
        {
            return new AscComparer(keyGetters);
        }

        public static IComparer GetDescComparer(params Func<object, IComparable>[] keyGetters)
        {
            return new DescComparer(keyGetters);
        }

        public static IComparer GetCustomComparer(params Func<object, (IComparable, SortMode)>[] keyGetters)
        {
            return new CustomComparer(keyGetters);
        }

        #endregion

        #region IComparer<T>
        
        public static IComparer<T> GetAscComparer<T>(params Func<T, IComparable>[] keyGetters)
        {
            return new AscComparer<T>(keyGetters);
        }

        public static IComparer<T> GetDescComparer<T>(params Func<T, IComparable>[] keyGetters)
        {
            return new DescComparer<T>(keyGetters);
        }

        public static IComparer<T> GetCustomComparer<T>(params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            return new CustomComparer<T>(keyGetters);
        } 

        #endregion
    }

    #region Common Comparer : IComparer<T>

    public abstract class CommonComparer<T> : IComparer<T>
    {
        public Comparison<T> Comparison { get; protected set; }

        protected CommonComparer()
        {
        }

        public abstract int Compare(T v1, T v2);
    }

    public class AscComparer<T> : CommonComparer<T>
    {
        public Func<T, IComparable>[] KeyGetters { get; }

        public AscComparer(params Func<T, IComparable>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetAscComparison(keyGetters);
        }

        public override int Compare(T v1, T v2)
        {
            return Comparison(v1, v2);
        }
    }

    public class DescComparer<T> : CommonComparer<T>
    {
        public Func<T, IComparable>[] KeyGetters { get; }

        public DescComparer(params Func<T, IComparable>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetDescComparison(keyGetters);
        }

        public override int Compare(T v1, T v2)
        {
            return Comparison(v1, v2);
        }
    }

    public class CustomComparer<T> : CommonComparer<T>
    {
        public Func<T, (IComparable, SortMode)>[] KeyGetters { get; }

        public CustomComparer(params Func<T, (IComparable, SortMode)>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetCustomComparison(keyGetters);
        }

        public override int Compare(T v1, T v2)
        {
            return Comparison(v1, v2);
        }
    }

    #endregion

    #region Common Comparer : IComparer

    public abstract class CommonComparer : IComparer
    {
        public Comparison<object> Comparison { get; protected set; }

        protected CommonComparer()
        {
        }

        public abstract int Compare(object v1, object v2);
    }

    public class AscComparer : CommonComparer
    {
        public Func<object, IComparable>[] KeyGetters { get; }

        public AscComparer(params Func<object, IComparable>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetAscComparison(keyGetters);
        }

        public override int Compare(object v1, object v2)
        {
            return Comparison(v1, v2);
        }
    }

    public class DescComparer : CommonComparer
    {
        public Func<object, IComparable>[] KeyGetters { get; }

        public DescComparer(params Func<object, IComparable>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetDescComparison(keyGetters);
        }

        public override int Compare(object v1, object v2)
        {
            return Comparison(v1, v2);
        }
    }

    public class CustomComparer : CommonComparer
    {
        public Func<object, (IComparable, SortMode)>[] KeyGetters { get; }

        public CustomComparer(params Func<object, (IComparable, SortMode)>[] keyGetters)
        {
            KeyGetters = keyGetters;
            Comparison = ComparisonUtil.GetCustomComparison(keyGetters);
        }

        public override int Compare(object v1, object v2)
        {
            return Comparison(v1, v2);
        }
    }

    #endregion
}
