using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class LongExtension
    {
        #region Abs

        public static long Abs(this long value)
        {
            var result = Math.Abs(value);
            return result;
        }

        public static IEnumerable<long> Abs(this IEnumerable<long> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        }

        #endregion

        #region Range

        public static bool IsInRange(this long value, long minValue, long maxValue)
        {
            var result = value >= minValue && value <= maxValue;
            return result;
        }

        public static double InRange(this long value, long minValue, long maxValue, long defaultValue)
        {
            var result = value.IsInRange(minValue, maxValue) ? value : defaultValue;
            return result;
        }

        #endregion

        #region Times

        public static void Times(this long value, Action action)
        {
            for (var i = 0; i < value; i++)
            {
                action();
            }
        }

        public static void Times(this int value, Action<long> action)
        {
            for (var i = 0; i < value; i++)
            {
                action(i);
            }
        }

        #endregion

        #region Odd / Even

        public static bool IsEven(this long value)
        {
            var result = value % 2 == 0;
            return result;
        }

        public static bool IsOdd(this long value)
        {
            var result = value % 2 != 0;
            return result;
        }

        #endregion

        #region Prime

        public static long ToPrime(this long value)
        {
            value = Math.Max(0, value);

            long result = 0;
            for (long i = 2; i < long.MaxValue; i = i << 1)
            {
                if (i < value)
                {
                    continue;
                }

                result = i;
                break;
            }

            return result;
        }

        #endregion
    }
}