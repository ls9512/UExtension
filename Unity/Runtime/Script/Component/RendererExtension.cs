using UnityEngine;

namespace Aya.Extension
{
    public static class RendererExtension
    {
        public static bool IsVisible(this Renderer renderer, Camera camera)
        {
            var planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }

        public static Bounds GetBounds(this Renderer renderer, bool includeChildren = true)
        {
            if (includeChildren)
            {
                var center = renderer.transform.position;
                var bounds = new Bounds(center, Vector3.zero);
                var rendererList = renderer.gameObject.GetComponentsInChildren<Renderer>();
                if (rendererList.Length == 0) return bounds;
                foreach (var r in rendererList)
                {
                    bounds.Encapsulate(r.bounds);
                }
                return bounds;
            }
            else
            {
                return renderer.bounds;
            }
        }

        public static Material GetMaterial(this Renderer renderer, int materialIndex)
        {
            if (materialIndex < 0 || materialIndex >= renderer.sharedMaterials.Length) return null;
            return Application.isPlaying ? renderer.materials[materialIndex] : renderer.sharedMaterials[materialIndex];
        }
    }
}