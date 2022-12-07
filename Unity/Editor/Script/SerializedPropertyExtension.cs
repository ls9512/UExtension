#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;

namespace Aya.Extension
{
    public static class SerializedPropertyExtension
    {
        public static T GetAttribute<T>(SerializedProperty serializedProperty, bool inherit) where T : Attribute
        {
            var attributes = GetAttributes<T>(serializedProperty, inherit);
            if (attributes == null || attributes.Length == 0) return default;
            return attributes[0];
        }

        public static T[] GetAttributes<T>(SerializedProperty serializedProperty, bool inherit) where T : Attribute
        {
            if (serializedProperty == null)
            {
                return null;
            }

            var type = serializedProperty.serializedObject.targetObject.GetType();
            FieldInfo fieldInfo = null;
            PropertyInfo propertyInfo = null;
            foreach (var name in serializedProperty.propertyPath.Split('.'))
            {
                fieldInfo = type.GetField(name, (BindingFlags) (-1));
                if (fieldInfo == null)
                {
                    propertyInfo = type.GetProperty(name, (BindingFlags) (-1));
                    if (propertyInfo == null)
                    {
                        return null;
                    }

                    type = propertyInfo.PropertyType;
                }
                else
                {
                    type = fieldInfo.FieldType;
                }
            }

            T[] attributes;

            if (fieldInfo != null)
            {
                attributes = fieldInfo.GetCustomAttributes(typeof(T), inherit) as T[];
            }
            else if (propertyInfo != null)
            {
                attributes = propertyInfo.GetCustomAttributes(typeof(T), inherit) as T[];
            }
            else
            {
                return null;
            }

            return attributes;
        }
    }
}
#endif