using UnityEngine;
using UnityEngine.Rendering;

namespace Aya.Extension
{
    public static class ShaderExtension
    {
        public static bool ContainsProperty(this Shader shader, string propertyName)
        {
            if (propertyName.EndsWith("_ST")) propertyName = propertyName.Replace("_ST", "");
            for (var i = 0; i < shader.GetPropertyCount(); i++)
            {
                var name = shader.GetPropertyName(i);
                if (name == propertyName) return true;
            }

            return false;
        }

        public static bool ContainsProperty(this Shader shader, string propertyName, ShaderPropertyType propertyType)
        {
            if (propertyName.EndsWith("_ST")) propertyName = propertyName.Replace("_ST", "");
            for (var i = 0; i < shader.GetPropertyCount(); i++)
            {
                var name = shader.GetPropertyName(i);
                var type = shader.GetPropertyType(i);
                if (name == propertyName && type == propertyType) return true;
            }

            return false;
        }
    }
}
