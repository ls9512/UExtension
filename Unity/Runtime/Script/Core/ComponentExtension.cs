using System.Reflection;
using UnityEngine;

namespace Aya.Extension
{
    public static class ComponentExtension
    {
        public static void CacheAllComponents<T>(this T component) where T : Component
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            var type = component.GetType();
            var fieldInfos = type.GetFields(bindingFlags);
            var propertyInfos = type.GetProperties(bindingFlags);

            foreach (var fieldInfo in fieldInfos)
            {
                var componentType = fieldInfo.FieldType;
                if (!componentType.IsSubclassOf(typeof(Component))) continue;
                var value = component.GetComponent(componentType);
                if (value == null)
                {
                    value = component.GetComponentInChildren(componentType, true);
                }

                if (value != null)
                {
                    fieldInfo.SetValue(component, value);
                }
            }

            foreach (var propertyInfo in propertyInfos)
            {
                var componentType = propertyInfo.PropertyType;
                if (!componentType.IsSubclassOf(typeof(Component))) continue;
                var value = component.GetComponent(componentType);
                if (value == null)
                {
                    value = component.GetComponentInChildren(componentType, true);
                }

                if (value != null)
                {
                    var setMethod = propertyInfo.GetSetMethod(true);
                    setMethod?.Invoke(component, new object[] {value});
                }
            }
        }

        public static bool TryGetComponent<T>(this Component component, out T outComponent)
        {
            var result = component.gameObject.TryGetComponent(out outComponent);
            return result;
        }

        public static bool TryGetComponentInParent<T>(this Component component, out T outComponent)
        {
            var result = component.gameObject.TryGetComponentInParent(out outComponent);
            return result;
        }

        public static bool TryGetComponentInChildren<T>(this Component component, out T outComponent)
        {
            var result = component.gameObject.TryGetComponentInChildren(out outComponent);
            return result;
        }
    }
}