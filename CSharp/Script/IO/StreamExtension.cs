using System;
using System.IO;
using System.Text;

namespace Aya.Extension
{
    public static class StreamExtension
    {
        #region Reader / Writer

        public static StreamReader GetReader(this Stream stream)
        {
            var result = new StreamReader(stream);
            return result;
        }

        public static StreamReader GetReader(this Stream stream, Encoding encoding)
        {
            if (stream.CanRead == false) throw new InvalidOperationException("Stream does not support reading.");
            encoding = (encoding ?? Encoding.Default);
            var result = new StreamReader(stream, encoding);
            return result;
        }

        public static StreamWriter GetWriter(this Stream stream)
        {
            var result = new StreamWriter(stream);
            return result;
        }

        public static StreamWriter GetWriter(this Stream stream, Encoding encoding)
        {
            if (stream.CanWrite == false) throw new InvalidOperationException("Stream does not support writing.");
            encoding = (encoding ?? Encoding.Default);
            var result = new StreamWriter(stream, encoding);
            return result;
        }

        #endregion

        #region Read / Write

        public static string ReadToEnd(this Stream stream)
        {
            using (var reader = stream.GetReader())
            {
                var result = reader.ReadToEnd();
                return result;
            }
        }

        public static string ReadToEnd(this Stream stream, Encoding encoding)
        {
            using (var reader = stream.GetReader(encoding))
            {
                var result = reader.ReadToEnd();
                return result;
            }
        }

        public static byte[] ReadAllBytes(this Stream stream)
        {
            using (var memoryStream = stream.CopyToMemory())
            {
                var result = memoryStream.ToArray();
                return result;
            }
        }

        public static byte[] ReadFixedBufferSize(this Stream stream, int bufferSize)
        {
            var result = new byte[bufferSize];
            var offset = 0;
            do
            {
                var cnt = stream.Read(result, offset, bufferSize - offset);
                if (cnt == 0) return null;
                offset += cnt;
            } while (offset < bufferSize);

            return result;
        }

        public static Stream Write(this Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
            return stream;
        }

        #endregion

        #region Seek

        public static Stream SeekToBegin(this Stream stream)
        {
            if (stream.CanSeek == false) throw new InvalidOperationException("Stream does not support seeking.");
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public static Stream SeekToEnd(this Stream stream)
        {
            if (stream.CanSeek == false) throw new InvalidOperationException("Stream does not support seeking.");
            stream.Seek(0, SeekOrigin.End);
            return stream;
        }


        #endregion

        #region Copy

        public static Stream CopyTo(this Stream stream, Stream targetStream)
        {
            stream.CopyTo(targetStream, 4096);
            return stream;
        }

        public static Stream CopyTo(this Stream stream, Stream targetStream, int bufferSize)
        {
            if (stream.CanRead == false) throw new InvalidOperationException("Source stream does not support reading.");
            if (targetStream.CanWrite == false) throw new InvalidOperationException("Target stream does not support writing.");
            var buffer = new byte[bufferSize];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, bufferSize)) > 0)
            {
                targetStream.Write(buffer, 0, bytesRead);
            }

            return stream;
        }

        public static MemoryStream CopyToMemory(this Stream stream)
        {
            var result = new MemoryStream((int) stream.Length);
            stream.CopyTo(result);
            return result;
        }

        #endregion

        #region Text

        [ThreadStatic] private static readonly byte[] Buffer = new byte[4096];

        public static string ToText(this Stream stream, Encoding encoding = null, bool closed = true)
        {
            if (stream == null) throw new NullReferenceException();
            if (!stream.CanRead) throw new Exception("Can not read stream, source.CanRead == false");
            try
            {
                encoding = encoding ?? Encoding.UTF8;
                if (stream is MemoryStream memoryStream)
                {
                    byte[] buffer;
                    try
                    {
                        buffer = memoryStream.GetBuffer();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        buffer = memoryStream.ToArray();
                    }

                    return encoding.GetString(buffer, 0, (int) memoryStream.Length);
                }

                var length = 0;
                try
                {
                    length = (int) stream.Length;
                }
                catch (NotSupportedException)
                {
                    // ignore
                }

                MemoryStream targetStream;
                if (length > 0 && length <= Buffer.Length)
                {
                    targetStream = new MemoryStream(Buffer, 0, Buffer.Length, true, true);
                }
                else
                {
                    targetStream = new MemoryStream(length);
                }

                using (targetStream)
                {
                    stream.CopyTo(targetStream);
                    var read = stream.Length;
                    return encoding.GetString(targetStream.GetBuffer(), 0, (int) read);
                }
            }
            finally
            {
                if (closed)
                {
                    stream?.Dispose();
                }
            }
        }

        #endregion
    }
}