using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class FloatExtension
    {
        #region Clamp

        public static float ClampMin0(this float value)
        {
            value = ClampMin(value, 0);
            return value;
        }

        public static float ClampMin(this float value, float min)
        {
            value = value < min ? min : value;
            return value;
        }

        public static float ClampMax0(this float value)
        {
            value = ClampMax(value, 0);
            return value;
        }

        public static float ClampMax(this float value, float max)
        {
            value = value > max ? max : value;
            return value;
        }

        public static float Clamp01(this float value)
        {
            value = Clamp(value, 0, 1);
            return value;
        }

        public static float Clamp(this float value, float min, float max)
        {
            value = value < min ? min : value;
            value = value > max ? max : value;
            return value;
        }

        #endregion

        #region Round

        public static float RoundDecimalPoints(this float value, int decimalPoints)
        {
            var result = (float) Math.Round(value, decimalPoints);
            return result;
        }

        public static float RoundToTwoDecimalPoints(this float value)
        {
            var result = (float) Math.Round(value, 2);
            return result;
        }

        #endregion

        #region Abs

        public static float Abs(this float value)
        {
            var result = Math.Abs(value);
            return result;
        }

        public static IEnumerable<float> Abs(this IEnumerable<float> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        }

        #endregion

        #region Range

        public static bool IsInRange(this float value, float minValue, float maxValue)
        {
            var result = value >= minValue && value <= maxValue;
            return result;
        }

        public static double InRange(this float value, float minValue, float maxValue, float defaultValue)
        {
            var result = value.IsInRange(minValue, maxValue) ? value : defaultValue;
            return result;
        }

        #endregion

        #region TimeSpan

        public static TimeSpan ToDays(this float value)
        {
            var result = TimeSpan.FromDays(value);
            return result;
        }

        public static TimeSpan ToHours(this float value)
        {
            var result = TimeSpan.FromHours(value);
            return result;
        }

        public static TimeSpan ToMilliseconds(this float value)
        {
            var result = TimeSpan.FromMilliseconds(value);
            return result;
        }

        public static TimeSpan ToMinutes(this float value)
        {
            var result = TimeSpan.FromMinutes(value);
            return result;
        }

        public static TimeSpan ToSeconds(this float value)
        {
            var result = TimeSpan.FromSeconds(value);
            return result;
        }

        #endregion
    }
}
