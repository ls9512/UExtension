using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aya.Extension
{
    public static partial class AssemblyExtension
    {
        public static List<Type> GetTypes(this Assembly assembly, Predicate<Type> predicate)
        {
            var result = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (predicate(type))
                {
                    result.Add(type);
                }
            }

            return result;
        }

        public static List<Type> GetTypesWithAttribute<T>(this Assembly assembly) where T : Attribute
        {
            var result = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var attributes = type.GetAttributes<T>();
                if (attributes != null && attributes.Length > 0)
                {
                    result.Add(type);
                }
            }

            return result;
        }

        public static List<Type> GetTypesWithAttribute<T>(this Assembly assembly, Predicate<Type> predicate) where T : Attribute
        {
            var result = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var attributes = type.GetAttributes<T>();
                if (attributes != null && attributes.Length > 0 && predicate(type))
                {
                    result.Add(type);
                }
            }

            return result;
        }

        public static Type GetTypeWithAttribute<T>(this Assembly assembly) where T : Attribute
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var attributes = type.GetAttributes<T>();
                if (attributes != null && attributes.Length > 0)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
