using System;
using System.ComponentModel;

namespace Aya.Extension
{
    public static class EnumExtension
    {
        #region Flag

        public static T ClearFlag<T>(this T enumValue, T flag) where T : Enum
        {
            var result = ClearFlags(enumValue, flag);
            return result;
        }

        public static T ClearFlags<T>(this T enumValue, params T[] flags) where T : Enum
        {
            var value = Convert.ToInt32(enumValue);
            foreach (var flag in flags)
            {
                value &= ~Convert.ToInt32(flag);
            }

            var result = (T) Enum.Parse(enumValue.GetType(), value.ToString());
            return result;
        }

        public static T SetFlag<T>(this T enumValue, T flag) where T : Enum
        {
            var result = SetFlags(enumValue, flag);
            return result;
        }

        public static T SetFlags<T>(this T enumValue, params T[] flags) where T : Enum
        {
            var value = Convert.ToInt32(enumValue);
            foreach (var flag in flags)
            {
                value |= Convert.ToInt32(flag);
            }

            var result = (T) Enum.Parse(enumValue.GetType(), value.ToString());
            return result;
        }

        public static bool ContainsFlag<T>(this T enumValue, T flag) where T : Enum
        {
            var value = Convert.ToInt32(enumValue);
            var index = 1 << Convert.ToInt32(flag);
            var result = (value & index) == index;
            return result;
        }

        public static bool ContainsFlagUnsafe<T>(this T enumValue, T flag) where T :
#if CSHARP_7_3_OR_NEWER
            unmanaged, Enum
#else
            struct
#endif
        {
            unsafe
            {
#if CSHARP_7_3_OR_NEWER
                switch (sizeof(T))
                {
                    case 1:
                        return (*(byte*) &enumValue & *(byte*) &flag) > 0;
                    case 2:
                        return (*(ushort*) &enumValue & *(ushort*) &flag) > 0;
                    case 4:
                        return (*(uint*) &enumValue & *(uint*) &flag) > 0;
                    case 8:
                        return (*(ulong*) &enumValue & *(ulong*) &flag) > 0;
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }
#else
                switch (UnsafeUtility.SizeOf<TEnum>())
                {
                    case 1:
                        {
                            byte valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            byte valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 2:
                        {
                            ushort valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            ushort valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 4:
                        {
                            uint valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            uint valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 8:
                        {
                            ulong valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            ulong valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }
#endif
            }
        }

        #endregion

        #region String

        public static T FromString<T>(this T enumValue, string strValue) where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), strValue))
            {
                return default(T);
            }

            var result = (T) Enum.Parse(typeof(T), strValue);
            return result;
        }

        public static bool TryParse<T>(this T enumValue, string strValue, out T returnValue) where T : Enum
        {
            returnValue = default(T);
            if (!Enum.IsDefined(typeof(T), strValue)) return false;
            var converter = TypeDescriptor.GetConverter(typeof(T));
            returnValue = (T) converter.ConvertFromString(strValue);
            return true;
        }

        #endregion

        #region Index

        public static int EnumIndex<T>(this T enumValue, int intValue) where T : Enum
        {
            var index = 0;
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                if ((int) value == intValue)
                {
                    return index;
                }

                ++index;
            }

            return -1;
        }

        public static int EnumIndex<T>(this T enumValue, byte byteValue) where T : Enum
        {
            var index = 0;
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                if ((byte) value == byteValue)
                {
                    return index;
                }

                ++index;
            }

            return -1;
        }

        #endregion
    }
}