using System.Collections.Generic;
using UnityEngine;

namespace Aya.Extension
{
    public static class LayerMaskExtension
    {
        public static bool Contains(this LayerMask layerMask, LayerMask otherLayerMask)
        {
            var value = 1 << layerMask.value;
            var result = (value & otherLayerMask.value) > 0;
            return result;
        }

        public static bool Contains(this LayerMask layerMask, int layerIndex)
        {
            return (layerMask.value & (1 << layerIndex)) > 0;
        }

        public static int GetLayerIndex(this LayerMask layerMask)
        {
            var i = 0;
            while (layerMask.value >> i != 0x1)
            {
                i++;
                if (i <= 32) continue;
                Debug.LogError("Get LayerMask Index Error");
                return -1;
            }

            return i;
        }

        public static LayerMask Inverse(this LayerMask layerMask)
        {
            return ~layerMask;
        }

        public static LayerMask AddToMask(this LayerMask layerMask, params string[] name)
        {
            return layerMask | NameToMask(name);
        }

        public static LayerMask RemoveFromMask(this LayerMask layerMask, params string[] name)
        {
            var invertedOriginal = ~layerMask;
            return ~(invertedOriginal | NameToMask(name));
        }

        public static string[] MaskToNames(this LayerMask layerMask)
        {
            var output = new List<string>();

            for (var i = 0; i < 32; ++i)
            {
                var shifted = 1 << i;
                if ((layerMask & shifted) != shifted) continue;
                var layerName = LayerMask.LayerToName(i);
                if (!string.IsNullOrEmpty(layerName))
                {
                    output.Add(layerName);
                }
            }

            return output.ToArray();
        }

        public static string MaskToString(this LayerMask layerMask)
        {
            return MaskToString(layerMask, ", ");
        }

        public static string MaskToString(this LayerMask layerMask, string delimiter)
        {
            return string.Join(delimiter, MaskToNames(layerMask));
        }

        internal static LayerMask NameToMask(params string[] layerNames)
        {
            var ret = (LayerMask)0;
            for (var i = 0; i < layerNames.Length; i++)
            {
                var nameTemp = layerNames[i];
                ret |= (1 << LayerMask.NameToLayer(nameTemp));
            }

            return ret;
        }
    }
}