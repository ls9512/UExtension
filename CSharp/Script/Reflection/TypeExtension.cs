using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Aya.Extension
{
    public static class TypeExtension
    {
        #region Cache

        public static Assembly Assembly { get; private set; }
        public static Type[] Types { get; private set; }

        static TypeExtension()
        {
            Assembly = Assembly.GetExecutingAssembly();
            Types = Assembly.GetTypes();
        }

        #endregion

        #region List

        public static bool IsGenericList(this Type type)
        {
            var result = type.IsGenericType && (typeof(List<>) == type.GetGenericTypeDefinition() || typeof(IList<>) == type.GetGenericTypeDefinition());
            return result;
        }

        #endregion

        #region Attribute

        public static Dictionary<FieldInfo, List<T>> GetFieldsWithAttribute<T>(this Type type, Predicate<T> predicate = null) where T : Attribute
        {
            var attrType = typeof(T);
            var list = new Dictionary<FieldInfo, List<T>>();
            var fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            for (var i = 0; i < fieldInfos.Length; i++)
            {
                var fieldInfo = fieldInfos[i];
                if (fieldInfo.IsDefined(attrType, false))
                {
                    list.Add(fieldInfo, new List<T>());
                    var attrs = fieldInfo.GetCustomAttributes(false);
                    for (var j = 0; j < attrs.Length; j++)
                    {
                        var attr = attrs[j] as T;
                        if (attr == null) continue;
                        if (predicate != null)
                        {
                            if (!predicate(attr)) continue;
                        }

                        list[fieldInfo].Add(attr);
                    }
                }
            }

            return list;
        }

        public static Dictionary<PropertyInfo, List<T>> GetPropertiesWithAttribute<T>(this Type type, Predicate<T> predicate = null) where T : Attribute
        {
            var attrType = typeof(T);
            var list = new Dictionary<PropertyInfo, List<T>>();
            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            for (var i = 0; i < propertyInfos.Length; i++)
            {
                var propertyInfo = propertyInfos[i];
                if (propertyInfo.IsDefined(attrType, false))
                {
                    list.Add(propertyInfo, new List<T>());
                    var attrs = propertyInfo.GetCustomAttributes(false);
                    for (var j = 0; j < attrs.Length; j++)
                    {
                        var attr = attrs[j] as T;
                        if (attr == null) continue;
                        if (predicate != null)
                        {
                            if (!predicate(attr)) continue;
                        }

                        list[propertyInfo].Add(attr);
                    }
                }
            }

            return list;
        }

        public static Dictionary<MethodInfo, List<T>> GetMethodsWithAttribute<T>(this Type type, Predicate<T> predicate = null) where T : Attribute
        {
            var attrType = typeof(T);
            var list = new Dictionary<MethodInfo, List<T>>();
            var methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            for (var i = 0; i < methodInfos.Length; i++)
            {
                var methodInfo = methodInfos[i];
                if (methodInfo.IsDefined(attrType, false))
                {
                    list.Add(methodInfo, new List<T>());
                    var attrs = methodInfo.GetCustomAttributes(false);
                    for (var j = 0; j < attrs.Length; j++)
                    {
                        var attr = attrs[j] as T;
                        if (attr == null) continue;
                        if (predicate != null)
                        {
                            if (!predicate(attr)) continue;
                        }

                        list[methodInfo].Add(attr);
                    }
                }
            }

            return list;
        }

        #endregion

        #region Default

        public static object DefaultValue(this Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public static bool IsNullableType(this Type type)
        {
            if (!type.IsPrimitive && !type.IsValueType)
            {
                return !type.IsEnum;
            }

            return false;
        }

        #endregion

        #region Types

        public static List<Type> GetSubTypes(this Type baseType)
        {
            var types = baseType.Assembly == Assembly ? Types : baseType.Assembly.GetTypes();
            var result = new List<Type>();
            for (var i = 0; i < types.Length; i++)
            {
                var type = types[i];
                if (type != baseType && baseType.IsAssignableFrom(type))
                {
                    result.Add(type);
                }
            }

            return result;
        }

        public static List<Type> GetDefinedTypes(this Type type)
        {
            var types = type.Assembly.GetTypes();
            var result = new List<Type>();
            for (var i = 0; i < types.Length; i++)
            {
                var t = types[i];
                if (t.IsDefined(type, true))
                {
                    result.Add(t);
                }
            }

            return result;
        }

        #endregion

        #region Interface

        public static bool ImplementsInterface<T>(this Type type)
        {
            return !type.IsInterface && type.GetInterfaces().Contains(typeof(T));
        }

        #endregion

        #region Enumerable

        public static Type GetEnumerableElementType(this Type type)
        {
            if (type == null) return null;
            if (!typeof(IEnumerable).IsAssignableFrom(type)) return null;
            if (type.HasElementType || type.IsArray) return type.GetElementType();
            if (type.IsGenericType)
            {
                var args = type.GetGenericArguments();
                if (args.Length == 1)
                {
                    return args[0];
                }

                if (args.Length == 2)
                {
                    return args[1];
                }
            }

            return null;
        }

        public static bool IsEnumerableCollection(this Type type)
        {
            if (type == null) return false;
            var result = typeof(IEnumerable).IsAssignableFrom(type) && (type.IsGenericType || type.IsArray);
            return result;
        }

        #endregion

        #region Property Type & Field Type

        public static List<PropertyInfo> GetPropertiesWithType(this Type type, Type propertyType)
        {
            var result = new List<PropertyInfo>();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == propertyType)
                {
                    result.Add(property);
                }
            }

            return result;
        }

        public static List<FieldInfo> GetFieldsWithType(this Type type, Type fieldType)
        {
            var result = new List<FieldInfo>();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (field.FieldType == fieldType)
                {
                    result.Add(field);
                }
            }

            return result;
        }

        #endregion

        #region Numeric

        public static bool IsNumericType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return Nullable.GetUnderlyingType(type).IsNumericType();
                    }

                    return false;
                default:
                    return false;
            }
        }

        #endregion

        #region Generic

        public static bool IsAssignableToGenericType(this Type type, Type genericType)
        {
            if (type == null || genericType == null)
            {
                return false;
            }

            return type == genericType
                   || type.MapsToGenericTypeDefinition(genericType)
                   || type.HasInterfaceThatMapsToGenericTypeDefinition(genericType)
                   || type.BaseType.IsAssignableToGenericType(genericType);
        }

        private static bool HasInterfaceThatMapsToGenericTypeDefinition(this Type type, Type genericType)
        {
            return type
                .GetInterfaces()
                .FindAll(it => it.IsGenericType)
                .Any(it => it.GetGenericTypeDefinition() == genericType);
        }

        private static bool MapsToGenericTypeDefinition(this Type type, Type genericType)
        {
            return genericType.IsGenericTypeDefinition
                   && type.IsGenericType
                   && type.GetGenericTypeDefinition() == genericType;
        }

        #endregion
    }
}