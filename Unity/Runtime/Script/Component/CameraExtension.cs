using UnityEngine;

namespace Aya.Extension
{
    public static class CameraExtension
    {
        #region Coordinate

        public static Vector3 ScreenToWorldPointIgnoreDeep(this Camera camera, Vector3 position)
        {
            var deep = camera.transform.position.z;
            var result = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, deep));
            return result;
        }

        #endregion

        #region Meter / Pixel

        public static float MetersPerPixel(this Camera orthographicCamera)
        {
            var result = orthographicCamera.orthographicSize * 2 / Screen.height;
            return result;
        }

        public static float PixelsPerMeter(this Camera orthographicCamera)
        {
            var result = Screen.height * 0.5f / orthographicCamera.orthographicSize;
            return result;
        }

        #endregion

        #region Capture

        public static Texture2D Capture(this Camera camera)
        {
            var texture = camera.Capture(new Rect(0, 0, Screen.width, Screen.height));
            return texture;
        }

        public static Texture2D Capture(this Camera camera, Rect rect)
        {
            var renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
            camera.targetTexture = renderTexture;
            camera.Render();
            RenderTexture.active = renderTexture;
            var screenShot = new Texture2D((int) rect.width, (int) rect.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();
            camera.targetTexture = null;
            RenderTexture.active = null;
            Object.Destroy(renderTexture);

            return screenShot;
        }

        #endregion

        #region Size

        public static float ScreenToWorldSize(this Camera camera, float pixelSize, float clipPlane)
        {
            float result;
            if (camera.orthographic)
            {
                result = pixelSize * camera.orthographicSize * 2f / camera.pixelHeight;
            }
            else
            {
                result = pixelSize * clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f / camera.pixelHeight;
            }

            return result;
        }

        public static float WorldToScreenSize(this Camera camera, float worldSize, float clipPlane)
        {
            float result;
            if (camera.orthographic)
            {
                result = worldSize * camera.pixelHeight * 0.5f / camera.orthographicSize;
            }
            else
            {
                result = worldSize * camera.pixelHeight * 0.5f / (clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
            }

            return result;
        }

        #endregion

        #region Clip Plane

        public static Vector4 GetClipPlane(this Camera camera, Vector3 point, Vector3 normal)
        {
            var wtoc = camera.worldToCameraMatrix;
            point = wtoc.MultiplyPoint(point);
            normal = wtoc.MultiplyVector(normal).normalized;
            var result = new Vector4(normal.x, normal.y, normal.z, -Vector3.Dot(point, normal));
            return result;
        }

        #endregion

        #region ZBuffer

        public static Vector4 GetZBufferParams(this Camera camera)
        {
            double f = camera.farClipPlane;
            double n = camera.nearClipPlane;

            var rn = 1f / n;
            var rf = 1f / f;
            var fpn = f / n;

            var result = SystemInfo.usesReversedZBuffer
                ? new Vector4((float) (fpn - 1.0), 1f, (float) (rn - rf), (float) rf)
                : new Vector4((float) (1.0 - fpn), (float) fpn, (float) (rf - rn), (float) rn);
            return result;
        }

        #endregion
    }
}