using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Aya.Extension
{
    public static class ObjectExtension
    {
        #region Null

        public static bool IsNull(this object obj)
        {
            var result = ReferenceEquals(obj, null);
            return result;
        }

        public static bool IsNotNull(this object obj)
        {
            var result = !ReferenceEquals(obj, null);
            return result;
        }

        #endregion

        #region Type

        public static T CastType<T>(this object obj)
        {
            try
            {
                var result = (T) obj.CastType(typeof(T));
                return result;
            }
            catch
            {
                var result = default(T);
                return result;
            }
        }


        public static object CastType(this object obj, Type type)
        {
            try
            {
                var result = Convert.ChangeType(obj, type, CultureInfo.InvariantCulture);
                return result;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
                var result = type.DefaultValue();
                return result;
            }
        }

        public static T ConvertTo<T>(this object obj, T defaultValue = default(T))
        {
            if (obj != null)
            {
                var targetType = typeof(T);

                if (obj.GetType() == targetType) return (T) obj;

                var converter = TypeDescriptor.GetConverter(obj);
                if (converter.CanConvertTo(targetType))
                {
                    return (T) converter.ConvertTo(obj, targetType);
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter.CanConvertFrom(obj.GetType()))
                {
                    return (T) converter.ConvertFrom(obj);
                }
            }

            return defaultValue;
        }

        public static bool CanConvertTo<T>(this object obj)
        {
            if (obj != null)
            {
                var targetType = typeof(T);

                var converter = TypeDescriptor.GetConverter(obj);
                if (converter.CanConvertTo(targetType))
                {
                    return true;
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter.CanConvertFrom(obj.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Interface

        public static bool ImplementsInterface<T>(this object obj)
        {
            var type = obj.GetType();
            var result = !type.IsInterface && type.GetInterfaces().Contains(typeof(T));
            return result;
        }

        #endregion

        #region Inherit / Assignable

        public static bool IsInherits(this object obj, Type type)
        {
            var objectType = obj.GetType();

            do
            {
                if (objectType == type)
                {
                    return true;
                }

                if ((objectType == objectType.BaseType) || (objectType.BaseType == null))
                {
                    return false;
                }

                objectType = objectType.BaseType;
            } while (true);
        }

        public static bool IsAssignableTo<T>(this object obj)
        {
            var result = obj.IsAssignableTo(typeof(T));
            return result;
        }

        public static bool IsAssignableTo(this object obj, Type type)
        {
            var objectType = obj.GetType();
            var result = type.IsAssignableFrom(objectType);
            return result;
        }

        #endregion

        #region Field

        public static object GetField(this object obj, string fieldName,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        {
            var fieldInfo = obj.GetType().GetField(fieldName, flags);
            return fieldInfo != null ? fieldInfo.GetValue(obj) : null;
        }

        public static void SetField(this object obj, string fieldName, object value,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        {
            var fieldInfo = obj.GetType().GetField(fieldName, flags);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(obj, value);
            }
        }

        public static List<FieldInfo> GetFieldsWithAttribute<T>(this object obj,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static) where T : Attribute
        {
            var result = new List<FieldInfo>();
            var fields = obj.GetType().GetFields(flags);
            for (var i = 0; i < fields.Length; i++)
            {
                var fieldInfo = fields[i];
                var attribute = fieldInfo.GetCustomAttribute<T>();
                if (attribute != null)
                {
                    result.Add(fieldInfo);
                }
            }

            return result;
        }

        #endregion

        #region Property

        public static object GetProperty(this object obj, string propertyName,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName, flags);
            return propertyInfo != null ? propertyInfo.GetValue(obj, null) : null;
        }

        public static void SetProperty(this object obj, string propertyName, object value,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName, flags);
            if (propertyInfo != null)
            {
                var setMethod = propertyInfo.GetSetMethod(true);
                setMethod?.Invoke(obj, new object[] {value});
            }
        }

        public static List<PropertyInfo> GetPropertiesWithAttribute<T>(this object obj,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static) where T : Attribute
        {
            var result = new List<PropertyInfo>();
            var properties = obj.GetType().GetProperties(flags);
            for (var i = 0; i < properties.Length; i++)
            {
                var propertyInfo = properties[i];
                var attribute = propertyInfo.GetCustomAttribute<T>();
                if (attribute != null)
                {
                    result.Add(propertyInfo);
                }
            }

            return result;
        }

        #endregion

        #region Method

        public static MethodInfo GetMethod(this object obj, string methodName,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
        {
            var methodInfo = obj.GetType().GetMethod(methodName, flags);
            return methodInfo;
        }

        public static object InvokeMethod(this object obj, string methodName, params object[] param)
        {
            var methodInfo = GetMethod(obj, methodName);
            return methodInfo != null ? methodInfo.Invoke(obj, param) : null;
        }

        public static object InvokeMethod(this object obj, string methodName, BindingFlags flags, params object[] param)
        {
            var methodInfo = GetMethod(obj, methodName, flags);
            return methodInfo != null ? methodInfo.Invoke(obj, param) : null;
        }

        public static List<MethodInfo> GetMethodsWithAttribute<T>(this object obj,
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static) where T : Attribute
        {
            var result = new List<MethodInfo>();
            var methods = obj.GetType().GetMethods(flags);
            for (var i = 0; i < methods.Length; i++)
            {
                var methodInfo = methods[i];
                var attribute = methodInfo.GetCustomAttribute<T>();
                if (attribute != null)
                {
                    result.Add(methodInfo);
                }
            }

            return result;
        }

        #endregion

        #region Attribute

        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            var result = GetAttribute<T>(obj, true);
            return result;
        }

        public static T GetAttribute<T>(this object obj, bool includeInherited) where T : Attribute
        {
            var type = (obj as Type ?? obj.GetType());
            var attributes = type.GetCustomAttributes(typeof(T), includeInherited);
            var first = attributes.First();
            var result = first as T;
            return result;
        }

        public static T[] GetAttributes<T>(this object obj) where T : Attribute
        {
            var result = GetAttributes<T>(obj, true);
            return result;
        }

        public static T[] GetAttributes<T>(this object obj, bool includeInherited) where T : Attribute
        {
            var type = (obj as Type ?? obj.GetType());
            var attributes = type.GetCustomAttributes(typeof(T), includeInherited);
            var result = attributes.ToArray(v => v as T);
            return result;
        }

        #endregion

        #region As

        public static string AsString(this object obj)
        {
            var result = ReferenceEquals(obj, null) ? null : $"{obj}";
            return result;
        }

        public static string AsString(this object obj, IFormatProvider formatProvider)
        {
            var result = string.Format(formatProvider, "{0}", obj);
            return result;
        }

        public static string AsInvariantString(this object obj)
        {
            var result = string.Format(CultureInfo.InvariantCulture, "{0}", obj);
            return result;
        }

        public static int AsInt(this object obj)
        {
            var result = obj.CastType<int>();
            return result;
        }

        public static long AsLong(this object obj)
        {
            var result = obj.CastType<long>();
            return result;
        }

        public static short AsShort(this object obj)
        {
            var result = obj.CastType<short>();
            return result;
        }

        public static float AsFloat(this object obj)
        {
            var result = obj.CastType<float>();
            return result;
        }

        public static double AsDouble(this object obj)
        {
            var result = obj.CastType<double>();
            return result;
        }

        public static decimal AsDecimal(this object obj)
        {
            var result = obj.CastType<decimal>();
            return result;
        }

        #endregion

        #region Copy Property / Field

        public static void CopyPropertiesFrom(this object obj, object source)
        {
            CopyPropertiesFrom(obj, source, string.Empty);
        }

        public static void CopyPropertiesFrom(this object obj, object source, string ignoreProperty)
        {
            CopyPropertiesFrom(obj, source, new[] {ignoreProperty});
        }

        public static void CopyPropertiesFrom(this object obj, object source, string[] ignoreProperties)
        {
            var type = source.GetType();
            if (obj.GetType() != type)
            {
                throw new ArgumentException("The source type must be the same as the target");
            }

            var ignoreList = new List<string>();
            foreach (var item in ignoreProperties)
            {
                if (!string.IsNullOrEmpty(item) && !ignoreList.Contains(item))
                {
                    ignoreList.Add(item);
                }
            }

            foreach (var propertyInfo in type.GetProperties())
            {
                if (!propertyInfo.CanWrite || !propertyInfo.CanRead || ignoreList.Contains(propertyInfo.Name)) continue;
                var val = propertyInfo.GetValue(source, null);
                propertyInfo.SetValue(obj, val, null);
            }
        }

        public static void CopyFieldsFrom(this object obj, object source)
        {
            CopyFieldsFrom(obj, source, string.Empty);
        }

        public static void CopyFieldsFrom(this object obj, object source, string ignoreField)
        {
            CopyFieldsFrom(obj, source, new[] {ignoreField});
        }

        public static void CopyFieldsFrom(this object obj, object source, string[] ignoreFields)
        {
            var type = source.GetType();
            if (obj.GetType() != type)
            {
                throw new ArgumentException("The source type must be the same as the target");
            }

            var ignoreList = new List<string>();
            foreach (var item in ignoreFields)
            {
                if (!string.IsNullOrEmpty(item) && !ignoreList.Contains(item))
                {
                    ignoreList.Add(item);
                }
            }

            foreach (var fieldInfo in type.GetFields())
            {
                if (ignoreList.Contains(fieldInfo.Name)) continue;
                var val = fieldInfo.GetValue(source);
                fieldInfo.SetValue(obj, val);
            }
        }

        public static void CopyPropertiesAndFieldsFrom(this object obj, object source)
        {
            CopyPropertiesFrom(obj, source);
            CopyFieldsFrom(obj, source);
        }

        #endregion
    }
}