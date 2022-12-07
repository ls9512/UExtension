using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class DoubleExtension
    {
        #region Round

        public static double RoundDecimalPoints(this double value, int decimalPoints)
        {
            var result = Math.Round(value, decimalPoints);
            return result;
        }

        public static double RoundToTwoDecimalPoints(this double value)
        {
            var result = Math.Round(value, 2);
            return result;
        }

        #endregion

        #region Abs

        public static double Abs(this double value)
        {
            var result = Math.Abs(value);
            return result;
        }


        public static IEnumerable<double> Abs(this IEnumerable<double> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        }

        #endregion

        #region Range

        public static bool IsInRange(this double value, double minValue, double maxValue)
        {
            var result = value >= minValue && value <= maxValue;
            return result;
        }

        public static double InRange(this double value, double minValue, double maxValue, double defaultValue)
        {
            var result = value.IsInRange(minValue, maxValue) ? value : defaultValue;
            return result;
        } 
       
        #endregion

        #region TimeSpan

        public static TimeSpan ToDays(this double value)
        {
            var result = TimeSpan.FromDays(value);
            return result;
        }

        public static TimeSpan ToHours(this double value)
        {
            var result = TimeSpan.FromHours(value);
            return result;
        }

        public static TimeSpan ToMilliseconds(this double value)
        {
            var result = TimeSpan.FromMilliseconds(value);
            return result;
        }

        public static TimeSpan ToMinutes(this double value)
        {
            var result = TimeSpan.FromMinutes(value);
            return result;
        }

        public static TimeSpan ToSeconds(this double value)
        {
            var result = TimeSpan.FromSeconds(value);
            return result;
        } 
        
        #endregion
    }
}
