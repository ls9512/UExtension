using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Aya.Extension
{
    public static partial class ByteExtension
    {
        #region IndexOf

        public static int IndexOf(this byte[] bytes, byte[] other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (other.Length == 0)
            {
                return 0;
            }

            var j = -1;
            var end = bytes.Length - other.Length;
            while ((j = Array.IndexOf(bytes, other[0], j + 1)) <= end && j != -1)
            {
                var i = 1;
                while (bytes[j + i] == other[i])
                {
                    if (++i == other.Length)
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        #endregion

        #region Hex

        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        public static string ToHex(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string ToHexWithSpace(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }

            return sb.ToString();
        }

        #endregion

        #region Base64

        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        #endregion

        #region Convert To int,long,float,double,bool,string,char

        public static int ToInt(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt32(bytes, startIndex);
        }

        public static long ToLong(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt64(bytes, startIndex);
        }

        public static char ToChar(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToChar(bytes, startIndex);
        }

        public static float ToFloat(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToSingle(bytes, startIndex);
        }

        public static double ToDouble(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToDouble(bytes, startIndex);
        }

        public static bool ToBoolean(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToBoolean(bytes, startIndex);
        }

        public static string ToString(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToString(bytes, startIndex);
        }

        public static T ToType<T>(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                var bf = new BinaryFormatter();
                ms.Position = 0;
                var x = bf.Deserialize(ms);
                return (T)x;
            }
        }

        #endregion

        #region Encoding

        public static string Decode(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        #endregion

        #region Hash

        public static byte[] Hash(this byte[] bytes, string hashName = "ModSystem.Security.Cryptography.HashAlgorithm")
        {
            var algorithm = string.IsNullOrEmpty(hashName) ? HashAlgorithm.Create() : HashAlgorithm.Create(hashName);
            return algorithm?.ComputeHash(bytes);
        }

        #endregion

        #region Bitwise

        public static bool GetBit(this byte b, int index)
        {
            return (b & (1 << index)) > 0;
        }

        public static byte SetBit(this byte b, int index)
        {
            b |= (byte) (1 << index);
            return b;
        }

        public static byte ClearBit(this byte b, int index)
        {
            b &= (byte) ((1 << 8) - 1 - (1 << index));
            return b;
        }
        public static byte ReverseBit(this byte b, int index)
        {
            b ^= (byte) (1 << index);
            return b;
        }

        #endregion

        #region File

        public static byte[] Save(this byte[] bytes, string path)
        {
            File.WriteAllBytes(path, bytes);
            return bytes;
        }

        #endregion

        #region MemoryStream

        public static MemoryStream ToMemoryStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        #endregion
    }
}