using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class ICollectionExtension
    {
        #region Null / Empty

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            var result = collection == null || collection.Count == 0;
            return result;
        }

        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }

            var result = collection.Count == 0;
            return result;
        }

        #endregion

        #region Add Unique

        public static bool AddUnique<T>(this ICollection<T> collection, T value)
        {
            var alreadyHas = collection.Contains(value);
            if (!alreadyHas)
            {
                collection.Add(value);
            }

            return alreadyHas;
        }

        public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                if (collection.AddUnique(value))
                {
                    count++;
                }
            }

            return count;
        }

        #endregion
    }
}
