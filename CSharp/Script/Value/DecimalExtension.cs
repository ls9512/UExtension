using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class DecimalExtension
    {
        #region Round
        
        public static decimal RoundDecimalPoints(this decimal value, int decimalPoints)
        {
            var result = Math.Round(value, decimalPoints);
            return result;
        }

        public static decimal RoundToTwoDecimalPoints(this decimal value)
        {
            var result = Math.Round(value, 2);
            return result;
        }

        #endregion

        #region Abs
        
        public static decimal Abs(this decimal value)
        {
            var result = Math.Abs(value);
            return result;
        }

        public static IEnumerable<decimal> Abs(this IEnumerable<decimal> value)
        {
            foreach (var d in value)
            {
                yield return d.Abs();
            }
        } 
        
        #endregion
    }
}
