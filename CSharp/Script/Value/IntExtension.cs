using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class IntExtension
    {
        #region Clamp

        public static int ClampMin0(this int value)
        {
            value = ClampMin(value, 0);
            return value;
        }

        public static int ClampMin(this int value, int min)
        {
            value = value < min ? min : value;
            return value;
        }

        public static int ClampMax0(this int value)
        {
            value = ClampMax(value, 0);
            return value;
        }

        public static int ClampMax(this int value, int max)
        {
            value = value > max ? max : value;
            return value;
        }

        public static int Clamp01(this int value)
        {
            value = Clamp(value, 0, 1);
            return value;
        }

        public static int Clamp(this int value, int min, int max)
        {
            value = value < min ? min : value;
            value = value > max ? max : value;
            return value;
        }

        #endregion

        #region Abs

        public static int Abs(this int value)
        {
            var result = Math.Abs(value);
            return result;
        }

        public static IEnumerable<int> Abs(this IEnumerable<int> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        }

        #endregion

        #region Range

        public static bool IsInRange(this int value, int minValue, int maxValue)
        {
            var result = value >= minValue && value <= maxValue;
            return result;
        }

        public static double InRange(this int value, int minValue, int maxValue, int defaultValue)
        {
            var result = value.IsInRange(minValue, maxValue) ? value : defaultValue;
            return result;
        }

        #endregion

        #region Times

        public static void Times(this int value, Action action)
        {
            for (var i = 0; i < value; i++)
            {
                action();
            }
        }

        public static void Times(this int value, Action<int> action)
        {
            for (var i = 0; i < value; i++)
            {
                action(i);
            }
        }

        #endregion

        #region Odd / Even

        public static bool IsEven(this int value)
        {
            var result = value % 2 == 0;
            return result;
        }

        public static bool IsOdd(this int value)
        {
            var result = value % 2 != 0;
            return result;
        }

        #endregion

        #region Index

        public static int GetArrayIndex(this int value)
        {
            var result = value == 0 ? 0 : value;
            return result;
        }

        public static bool IsIndexInArray(this int value, Array arrayToCheck)
        {
            var result = value.GetArrayIndex().IsInRange(arrayToCheck.GetLowerBound(0), arrayToCheck.GetUpperBound(0));
            return result;
        }

        #endregion

        #region Prime

        public static int ToPrime(this int value)
        {
            value = Math.Max(0, value);

            var result = 0;
            for (var i = 2; i < int.MaxValue; i = i << 1)
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