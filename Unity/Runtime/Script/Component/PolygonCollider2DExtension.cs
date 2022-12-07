using System.Collections.Generic;
using UnityEngine;

namespace Aya.Extension
{
    public static class PolygonCollider2DExtension
    {
        public static void SetColliderWithPath(this PolygonCollider2D collider2D, float width, List<Vector2> pointList)
        {
            var pointListCache = new List<Vector2>();
            for (var i = 0; i < pointList.Count; i++)
            {
                pointListCache.Add(pointList[i]);
            }

            // var edgePointList = new List<Vector2>();
            for (var j = 1; j < pointListCache.Count; j++)
            {
                var distanceVector = pointListCache[j - 1] - pointListCache[j];
                var crossVector = Vector3.Cross(distanceVector, Vector3.forward);
                Vector2 offsetVector = crossVector.normalized;
                var up = pointListCache[j - 1] + 0.5f * width * offsetVector;
                var down = pointListCache[j - 1] - 0.5f * width * offsetVector;
                // edgePointList.Insert(0, down);
                // edgePointList.Add(up);
                if (j == pointListCache.Count - 1)
                {
                    up = pointListCache[j] + 0.5f * width * offsetVector;
                    down = pointListCache[j] - 0.5f * width * offsetVector;
                    // edgePointList.Insert(0, down);
                    // edgePointList.Add(up);
                }
            }

            collider2D.SetPath(0, pointListCache.ToArray());
        }
    }
}