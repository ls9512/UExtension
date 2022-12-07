using System;
using System.Reflection;

namespace Aya.Extension
{
    public static class MemberInfoExtension
    {
        public static void SetValue(this MemberInfo memberInfo, object obj, object value)
        {
            switch (memberInfo)
            {
                case FieldInfo fieldInfo:
                    fieldInfo.SetValue(obj, value);
                    break;
                case PropertyInfo propertyInfo:
                    var setMethod = propertyInfo.GetSetMethod(true);
                    if (setMethod != null)
                    {
                        setMethod.Invoke(obj, new object[1]);
                    }

                    break;
                default:
                    break;
            }
        }

        public static Type GetMemberType(this MemberInfo memberInfo)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Event:
                    return ((EventInfo)memberInfo).EventHandlerType;
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).FieldType;
                case MemberTypes.Method:
                    return ((MethodInfo)memberInfo).ReturnType;
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).PropertyType;
                default:
                    return default;
            }
        }
    }
}

