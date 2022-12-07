using System.IO;
using UnityEngine;

namespace Aya.Extension
{
    public static class Texture2DExtension
    {
        #region Load File

        public static void LoadFromFile(this Texture2D texture2D, string path)
        {
            var bytes = File.ReadAllBytes(path);
            texture2D.LoadImage(bytes);
        }

        #endregion

        #region Save File

        public static void SaveToFile(this Texture2D texture2D, string path)
        {
            SaveToFilePng(texture2D, path);
        }

        public static void SaveToFileExr(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToEXR();
            File.WriteAllBytes(path, bytes);
        }

        public static void SaveToFileTga(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToTGA();
            File.WriteAllBytes(path, bytes);
        }

        public static void SaveToFileJpg(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToJPG();
            File.WriteAllBytes(path, bytes);
        }

        public static void SaveToFilePng(this Texture2D texture2D, string path)
        {
            var bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }

        #endregion

        #region Rotate

        public static Texture2D Rotate(this Texture2D texture2D, bool clockwise = true)
        {
            var original = texture2D.GetPixels32();
            var rotated = new Color32[original.Length];
            var textureWidth = texture2D.width;
            var textureHeight = texture2D.height;
            var origLength = original.Length;

            for (var heightIndex = 0; heightIndex < textureHeight; ++heightIndex)
            {
                for (var widthIndex = 0; widthIndex < textureWidth; ++widthIndex)
                {
                    var rotIndex = (widthIndex + 1) * textureHeight - heightIndex - 1;

                    var origIndex = clockwise
                        ? origLength - 1 - (heightIndex * textureWidth + widthIndex)
                        : heightIndex * textureWidth + widthIndex;

                    rotated[rotIndex] = original[origIndex];
                }
            }

            var rotatedTexture = new Texture2D(textureHeight, textureWidth);
            rotatedTexture.SetPixels32(rotated);
            rotatedTexture.Apply();
            return rotatedTexture;
        }


        #endregion
    }
}