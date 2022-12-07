using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aya.Extension
{
    public static class MethodInfoExtension
    {
        #region Run

        public static void Execute(this MethodInfo methodInfo, object target, params object[] param)
        {
            if (methodInfo.IsStatic)
            {
                var parameters = new object[param.Length + 1];
                parameters[0] = target;
                for (var i = 0; i < param.Length; ++i)
                {
                    parameters[i + 1] = param[i];
                }

                methodInfo.Invoke(null, parameters);
            }
            else
            {
                methodInfo.Invoke(target, param);
            }
        }

        #endregion

        #region Check

        public static bool IsExtensionMethod(this MethodBase methodInfo)
        {
            var declaringType = methodInfo.DeclaringType;
            if (declaringType == null) return false;
            if (declaringType.IsSealed && !declaringType.IsGenericType && !declaringType.IsNested)
            {
                return methodInfo.IsDefined(typeof(ExtensionAttribute), false);
            }

            return false;
        }

        #endregion

        #region Signature

        public static string GetSignature(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                return "";
            }

            var stringBuilder = new StringBuilder();

            if (methodInfo.IsPrivate)
            {
                stringBuilder.Append("private ");
            }
            else if (methodInfo.IsPublic)
            {
                stringBuilder.Append("public ");
            }

            if (methodInfo.IsPrivate)
            {
                stringBuilder.Append("private ");
            }
            else if (methodInfo.IsPublic)
            {
                stringBuilder.Append("public ");
            }
            else if (methodInfo.IsFamily)
            {
                stringBuilder.Append("protected ");
            }
            else if (methodInfo.IsAssembly)
            {
                stringBuilder.Append("internal ");
            }
            else if (methodInfo.IsFamilyOrAssembly)
            {
                stringBuilder.Append("protected internal ");
            }

            if (methodInfo.IsStatic)
            {
                stringBuilder.Append("static ");
            }

            if (methodInfo.IsAbstract)
            {
                stringBuilder.Append("abstract ");
            }
            else if (methodInfo.IsVirtual)
            {
                stringBuilder.Append("virtual ");
            }

            stringBuilder.Append(methodInfo.ReturnType.Name);
            stringBuilder.Append(" ");
            stringBuilder.Append(methodInfo.Name);
            stringBuilder.Append("(");
            var parameters = methodInfo.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                stringBuilder.Append(parameter.ParameterType.Name);
                stringBuilder.Append(" ");
                stringBuilder.Append(parameter.Name);
                if (i < parameters.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }

            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        #endregion

    }
}