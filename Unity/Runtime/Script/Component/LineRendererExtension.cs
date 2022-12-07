using System.Collections.Generic;
using UnityEngine;

namespace Aya.Extension
{
    public static class LineRendererExtension
    {
        public static void SetPath(this LineRenderer lineRenderer, List<Vector3> pointList)
        {
            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());
        }

        public static void SetPath(this LineRenderer lineRenderer, Vector3[] pointList)
        {
            lineRenderer.positionCount = pointList.Length;
            lineRenderer.SetPositions(pointList);
        }

        public static void Clear(this LineRenderer lineRenderer)
        {
            lineRenderer.positionCount = 0;
        }
    }
}
