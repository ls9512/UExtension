using System;
using System.IO;

namespace Aya.Extension
{
    public static class FileInfoExtension
    {
        public static FileInfo Rename(this FileInfo fileInfo, string newName)
        {
            var directoryName = Path.GetDirectoryName(fileInfo.FullName);
            if (directoryName == null) throw new NullReferenceException(nameof(directoryName));
            var filePath = Path.Combine(directoryName, newName);
            fileInfo.MoveTo(filePath);
            return fileInfo;
        }

        public static FileInfo RenameFileWithoutExtension(this FileInfo fileInfo, string newName)
        {
            var fileName = string.Concat(newName, fileInfo.Extension);
            fileInfo.Rename(fileName);
            return fileInfo;
        }

        public static FileInfo ChangeExtension(this FileInfo fileInfo, string newExtension)
        {
            newExtension = newExtension.EnsureStartsWith(".");
            var fileName = string.Concat(Path.GetFileNameWithoutExtension(fileInfo.FullName), newExtension);
            fileInfo.Rename(fileName);
            return fileInfo;
        }

        public static FileInfo[] ChangeExtensions(this FileInfo[] fileInfos, string newExtension)
        {
            fileInfos.ForEach(f => f.ChangeExtension(newExtension));
            return fileInfos;
        }

        public static void Delete(this FileInfo[] fileInfos)
        {
            foreach (var file in fileInfos)
            {
                file.Delete();
            }
        }
    }
}
