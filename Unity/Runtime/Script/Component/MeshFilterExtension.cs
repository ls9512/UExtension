using UnityEngine;

namespace Aya.Extension
{
    public static class MeshFilterExtension
    {
        public static Bounds GetBounds(this MeshFilter meshFilter, bool includeChildren = true)
        {
            if (includeChildren)
            {
                var center = meshFilter.transform.position;
                var bounds = new Bounds(center, Vector3.zero);
                var meshFilters = meshFilter.gameObject.GetComponentsInChildren<MeshFilter>();
                if (meshFilters.Length == 0) return bounds;
                foreach (var filter in meshFilters)
                {
                    if (filter.mesh != null)
                    {
                        bounds.Encapsulate(filter.mesh.bounds);
                    }
                }

                return bounds;
            }
            else
            {
                return meshFilter.mesh.bounds;
            }
        }
    }
}