using System;

namespace Aya.Extension
{
    public static class IComparableExtension 
    {
        public static bool Between<T>(this T value, T lowerBound, T upperBound, bool includeLowerBound = false, bool includeUpperBound = false) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var lowerCompareResult = value.CompareTo(lowerBound);
            var upperCompareResult = value.CompareTo(upperBound);
            var result = (includeLowerBound && lowerCompareResult == 0) ||
                         (includeUpperBound && upperCompareResult == 0) ||
                         (lowerCompareResult > 0 && upperCompareResult < 0);
            return result;
        }

        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var result = value.LessThan(min) ? min : value.GreaterThan(max) ? max : value;
            return result;
        }

        public static bool LessThan<T>(this T value, T other) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var result = value.CompareTo(other) < 0;
            return result;
        }

        public static bool LessOrEqual<T>(this T value, T other) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var result = value.CompareTo(other) <= 0;
            return result;
        }

        public static bool GreaterThan<T>(this T value, T other) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var result = value.CompareTo(other) > 0;
            return result;
        }

        public static bool GreaterOrEqual<T>(this T value, T other) where T : IComparable<T>
        {
            if (value == null) throw new ArgumentNullException();
            var result = value.CompareTo(other) >= 0;
            return result;
        }
    }
}
