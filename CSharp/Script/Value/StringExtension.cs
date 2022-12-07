using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace Aya.Extension
{
    public static class StringExtension
    {
        private static readonly StringBuilder StringBuilder = new StringBuilder();

        #region Null / Empty

        public static bool IsNullOrEmpty(this string value)
        {
            var result = string.IsNullOrEmpty(value);
            return result;
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            var result = !string.IsNullOrEmpty(value);
            return result;
        }

        public static bool IsEmptyOrWhiteSpace(this string value)
        {
            if (value.IsEmpty()) return true;
            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (!char.IsWhiteSpace(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNotEmptyOrWhiteSpace(this string value)
        {
            var result = value.IsEmptyOrWhiteSpace() == false;
            return result;
        }

        public static string IfEmptyOrWhiteSpace(this string value, string defaultValue)
        {
            var result = value.IsEmptyOrWhiteSpace() ? defaultValue : value;
            return result;
        }

        #endregion

        #region Convert To bool,short,int,long,float,double

        public static bool IsBoolean(this string value)
        {
            var result = bool.TryParse(value, out _);
            return result;
        }

        public static bool AsBoolean(this string value)
        {
            var result = bool.Parse(value);
            return result;
        }

        public static bool IsShort(this string value)
        {
            var result = short.TryParse(value, out _);
            return result;
        }

        public static short AsShort(this string value)
        {
            var result = short.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        public static bool IsInt(this string value)
        {
            var result = int.TryParse(value, out _);
            return result;
        }

        public static int AsInt(this string value)
        {
            var result = int.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        public static bool IsLong(this string value)
        {
            var result = long.TryParse(value, out _);
            return result;
        }

        public static long AsLong(this string value)
        {
            var result = long.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        public static bool IsFloat(this string value)
        {
            var result = float.TryParse(value, out _);
            return result;
        }

        public static float AsFloat(this string value)
        {
            var result = float.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        public static bool IsDouble(this string value)
        {
            var result = double.TryParse(value, out _);
            return result;
        }

        public static double AsDouble(this string value)
        {
            var result = double.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        public static bool IsDecimal(this string value)
        {
            var result = decimal.TryParse(value, out _);
            return result;
        }

        public static decimal AsDecimal(this string value)
        {
            var result = decimal.Parse(value, CultureInfo.InvariantCulture);
            return result;
        }

        #endregion

        #region Trim

        public static string TrimToMaxLength(this string value, int maxLength)
        {
            var result = value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength);
            return result;
        }

        public static string TrimToMaxLength(this string value, int maxLength, string suffix)
        {
            var result = value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix);
            return result;
        }

        #endregion

        #region Contains

        public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
        {
            var result = (value.IndexOf(comparisonValue, comparisonType) != -1);
            return result;
        }

        public static bool ContainsAny(this string value, params string[] values)
        {
            var result = value.ContainsAny(StringComparison.CurrentCulture, values);
            return result;
        }

        public static bool ContainsAny(this string value, StringComparison comparisonType, params string[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                var str = values[i];
                if (Contains(value, str, comparisonType)) return true;
            }

            return false;
        }

        public static bool ContainsAll(this string value, params string[] values)
        {
            var result = value.ContainsAll(StringComparison.CurrentCulture, values);
            return result;
        }

        public static bool ContainsAll(this string value, StringComparison comparisonType, params string[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                var str = values[i];
                if (Contains(value, str, comparisonType)) return true;
            }

            return false;
        }

        public static bool EqualsAny(this string value, StringComparison comparisonType, params string[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                var str = values[i];
                if (value.Equals(str, comparisonType)) return true;
            }

            return false;
        }

        #endregion

        #region Get

        public static string Before(this string value, string x)
        {
            var xPos = value.IndexOf(x, StringComparison.Ordinal);
            var result = xPos == -1 ? string.Empty : value.Substring(0, xPos);
            return result;
        }

        public static string Between(this string value, string x, string y)
        {
            var xPos = value.IndexOf(x, StringComparison.Ordinal);
            var yPos = value.LastIndexOf(y, StringComparison.Ordinal);

            if (xPos == -1)
            {
                return string.Empty;
            }

            var startIndex = xPos + x.Length;
            var result = startIndex >= yPos ? string.Empty : value.Substring(startIndex, yPos - startIndex).Trim();
            return result;
        }

        public static string After(this string value, string x)
        {
            var xPos = value.LastIndexOf(x, StringComparison.Ordinal);

            if (xPos == -1)
            {
                return string.Empty;
            }

            var startIndex = xPos + x.Length;
            var result = startIndex >= value.Length ? string.Empty : value.Substring(startIndex).Trim();
            return result;
        }

        public static string Left(this string value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (characterCount >= value.Length)
                throw new ArgumentOutOfRangeException(nameof(characterCount), characterCount, "characterCount must be less than length of string");
            var result = value.Substring(0, characterCount);
            return result;
        }

        public static string Right(this string value, int characterCount)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (characterCount >= value.Length)
                throw new ArgumentOutOfRangeException(nameof(characterCount), characterCount, "characterCount must be less than length of string");
            var result = value.Substring(value.Length - characterCount);
            return result;
        }

        public static string Substring(this string value, int index)
        {
            var result = index < 0 ? value : value.Substring(index, value.Length - index);
            return result;
        }

        #endregion

        #region Join

        public static string Join<T>(this string separator, T[] values)
        {
            if (values == null || values.Length == 0)
            {
                return string.Empty;
            }

            if (separator == null)
            {
                separator = string.Empty;
            }

            string Converter(T o) => o.ToString();
            var result = string.Join(separator, Array.ConvertAll(values, (Converter<T, string>) Converter));
            return result;
        }

        #endregion

        #region Remove

        public static string Remove(this string value, params char[] chars)
        {
            var result = value;
            if (!string.IsNullOrEmpty(result) && chars != null)
            {
                Array.ForEach(chars, c => result = result.Remove(c.ToString()));
            }

            return result;

        }

        public static string Remove(this string value, params string[] strings)
        {
            for (var i = 0; i < strings.Length; i++)
            {
                var str = strings[i];
                value = value.Replace(str, string.Empty);
            }

            return value;
        }

        #endregion

        #region Pad

        public static string PadBoth(this string value, int width, char padChar, bool truncate = false)
        {
            var diff = width - value.Length;
            if (diff == 0 || diff < 0 && !(truncate))
            {
                return value;
            }
            else if (diff < 0)
            {
                return value.Substring(0, width);
            }
            else
            {
                return value.PadLeft(width - diff / 2, padChar).PadRight(width, padChar);
            }
        }

        #endregion

        #region Start / End With

        public static string EnsureStartsWith(this string value, string prefix)
        {
            var result = value.StartsWith(prefix) ? value : string.Concat(prefix, value);
            return result;
        }

        public static string EnsureEndsWith(this string value, string suffix)
        {
            var result = value.EndsWith(suffix) ? value : string.Concat(value, suffix);
            return result;
        }

        #endregion

        #region Contact

        public static string ConcatWith(this string value, params string[] values)
        {
            var result = string.Concat(value, string.Concat(values));
            return result;
        }

        #endregion

        #region Repeat

        public static string Repeat(this string value, int repeatCount)
        {
            if (value.Length == 1)
            {
                return new string(value[0], repeatCount);
            }

            var stringBuilder = new StringBuilder(repeatCount * value.Length);
            while (repeatCount-- > 0)
            {
                stringBuilder.Append(value);
            }

            var result = stringBuilder.ToString();
            return result;
        }

        #endregion

        #region Replace

        public static string ReplaceAll(this string value, IEnumerable<string> oldValues, Func<string, string> replacePredicate)
        {
            var stringBuilder = new StringBuilder(value);
            foreach (var oldValue in oldValues)
            {
                var newValue = replacePredicate(oldValue);
                stringBuilder.Replace(oldValue, newValue);
            }

            return stringBuilder.ToString();
        }

        public static string ReplaceAll(this string value, IEnumerable<string> oldValues, string newValue)
        {
            var stringBuilder = new StringBuilder(value);
            foreach (var oldValue in oldValues)
            {
                stringBuilder.Replace(oldValue, newValue);
            }

            return stringBuilder.ToString();
        }

        public static string ReplaceAll(this string value, IEnumerable<string> oldValues, IEnumerable<string> newValues)
        {
            var stringBuilder = new StringBuilder(value);
            var newValueEnum = newValues.GetEnumerator();
            foreach (var old in oldValues)
            {
                if (!newValueEnum.MoveNext()) throw new ArgumentOutOfRangeException(nameof(newValues), "newValues sequence is shorter than oldValues sequence");
                stringBuilder.Replace(old, newValueEnum.Current ?? throw new InvalidOperationException());
            }

            if (newValueEnum.MoveNext()) throw new ArgumentOutOfRangeException(nameof(newValues), "newValues sequence is longer than oldValues sequence");
            newValueEnum.Dispose();
            return stringBuilder.ToString();
        }

        public static string ReplaceWith(this string value, string regexPattern, string replaceValue)
        {
            var result = ReplaceWith(value, regexPattern, replaceValue, RegexOptions.None);
            return result;
        }

        public static string ReplaceWith(this string value, string regexPattern, string replaceValue, RegexOptions options)
        {
            var result = Regex.Replace(value, regexPattern, replaceValue, options);
            return result;
        }

        #endregion

        #region Spilt

        public static string[] SplitWith(this string value, string regexPattern)
        {
            var result = value.SplitWith(regexPattern, RegexOptions.None);
            return result;
        }

        public static string[] SplitWith(this string value, string regexPattern, RegexOptions options)
        {
            var result = Regex.Split(value, regexPattern, options);
            return result;
        }

        public static string[] GetWords(this string value)
        {
            var result = value.SplitWith(@"\W");
            return result;
        }

        public static string GetWordByIndex(this string value, int index)
        {
            var words = value.GetWords();
            if ((index < 0) || (index > words.Length - 1)) throw new IndexOutOfRangeException("The word number is out of range.");
            var result = words[index];
            return result;
        }

        #endregion

        #region In

        public static bool In(this string value, params string[] strings)
        {
            var result = Array.IndexOf(strings, value) > -1;
            return result;
        }

        #endregion

        #region Line

        public static int GetLines(this string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            var splits = value.Split('\r');
            var result = splits.Length;
            return result;
        }

        public static string SubStringWithLine(this string value, int startLine = 0, string endStr = "\n")
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException();
            }

            var splits = value.Split(new[] {endStr}, StringSplitOptions.None);
            var lineCount = splits.Length;
            var lines = lineCount - startLine;
            if (startLine < 0 || lines + startLine > lineCount)
            {
                throw new IndexOutOfRangeException(
                    "startLine = " + startLine +
                    ",\tlines = " + lines +
                    ",\t Line Count : " + lineCount + ".");
            }

            var startIndex = 0;
            var length = 0;
            var index = 0;
            for (; index < startLine; index++)
            {
                startIndex += splits[index].Length + endStr.Length;
            }

            for (; index < startLine + lines; index++)
            {
                length += splits[index].Length + endStr.Length;
            }

            length--;
            var result = value.Substring(startIndex, length);
            return result;
        }

        public static string SubStringWithLine(this string value, int startLine, int lines, string endStr = "\n")
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException();
            }

            var splits = value.Split(new[] {endStr}, StringSplitOptions.None);
            var lineCount = splits.Length;
            if (startLine < 0 || lines + startLine > lineCount)
            {
                throw new IndexOutOfRangeException(
                    "startLine = " + startLine +
                    ",\tlines = " + lines +
                    ",\t Line Count : " + lineCount + ".");
            }

            var startIndex = 0;
            var length = 0;
            var index = 0;
            for (; index < startLine; index++)
            {
                startIndex += splits[index].Length + endStr.Length;
            }

            for (; index < startLine + lines; index++)
            {
                length += splits[index].Length + endStr.Length;
            }

            length--;
            var result = value.Substring(startIndex, length);
            return result;
        }

        #endregion

        #region Formart

        public static string Format(this string value, params object[] args)
        {
            var result = string.Format(value, args);
            return result;
        }

        public static string Format(this string value, object arg0)
        {
            var result = string.Format(value, arg0);
            return result;
        }

        public static string Format(this string value, object arg0, object arg1)
        {
            var result = string.Format(value, arg0, arg1);
            return result;
        }

        public static string Format(this string value, object arg0, object arg1, object arg2)
        {
            var result = string.Format(value, arg0, arg1, arg2);
            return result;
        }

        public static string Format(this string value, IFormatProvider provider, params object[] args)
        {
            var result = string.Format(provider, value, args);
            return result;
        }

        public static string ToUpperFirstLetter(this string value)
        {
            if (value.IsEmptyOrWhiteSpace()) return string.Empty;
            var valueChars = value.ToCharArray();
            valueChars[0] = char.ToUpper(valueChars[0]);
            var result = new string(valueChars);
            return result;
        }

        public static string ToTitleCase(this string value)
        {
            var result = ToTitleCase(value, CultureInfo.CurrentCulture);
            return result;
        }

        public static string ToTitleCase(this string value, CultureInfo cultureInfo)
        {
            var result = cultureInfo.TextInfo.ToTitleCase(value);
            return result;
        }

        public static string ToPlural(this string singular)
        {
            var index = singular.LastIndexOf(" of ", StringComparison.Ordinal);
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            if (singular.EndsWith("o")) return singular.Remove(singular.Length - 1, 1) + "oes";
            return singular + "s";
        }

        public static string SpaceOnUpper(this string value)
        {
            var result = Regex.Replace(value, "([A-Z])(?=[a-z])|(?<=[a-z])([A-Z]|[0-9]+)", " $1$2").TrimStart();
            return result;
        }

        #endregion

        #region Regex

        public static bool IsMatch(this string value, string pattern)
        {
            var result = value != null && Regex.IsMatch(value, pattern);
            return result;
        }

        public static bool IsMatch(this string value, Regex regex)
        {
            var result = value != null && regex.IsMatch(value);
            return result;
        }

        public static string Match(this string value, string pattern)
        {
            var result = value == null ? "" : Regex.Match(value, pattern).Value;
            return result;
        }

        public static string Match(this string value, Regex regex)
        {
            var result = value == null ? "" : regex.Match(value).Value;
            return result;
        }

        public static MatchCollection Matches(this string value, string regexPattern)
        {
            var result = Matches(value, regexPattern, RegexOptions.None);
            return result;
        }

        public static MatchCollection Matches(this string value, string regexPattern, RegexOptions options)
        {
            var result = Regex.Matches(value, regexPattern, options);
            return result;
        }

        public static IEnumerable<string> MatchValues(this string value, string regexPattern)
        {
            var result = MatchValues(value, regexPattern, RegexOptions.None);
            return result;
        }

        public static IEnumerable<string> MatchValues(this string value, string regexPattern, RegexOptions options)
        {
            foreach (Match match in Matches(value, regexPattern, options))
            {
                if (match.Success) yield return match.Value;
            }
        }

        #endregion

        #region Like

        public static bool IsLikeAny(this string value, params string[] patterns)
        {
            for (var i = 0; i < patterns.Length; i++)
            {
                var pattern = patterns[i];
                if (IsLike(value, pattern)) return true;
            }

            return false;
        }

        public static bool IsLike(this string value, string pattern)
        {
            if (value == pattern) return true;
            if (pattern[0] == '*' && pattern.Length > 1)
            {
                for (var index = 0; index < value.Length; index++)
                {
                    if (value.Substring(index).IsLike(pattern.Substring(1)))
                    {
                        return true;
                    }
                }
            }
            else if (pattern[0] == '*')
            {
                return true;
            }
            else if (pattern[0] == value[0])
            {
                return value.Substring(1).IsLike(pattern.Substring(1));
            }

            return false;
        }

        #endregion

        #region Guid

        public static Guid ToGuid(this string value)
        {
            var result = new Guid(value);
            return result;
        }

        public static Guid ToGuidSafe(this string value)
        {
            var result = value.ToGuidSafe(Guid.Empty);
            return result;
        }

        public static Guid ToGuidSafe(this string value, Guid defaultValue)
        {
            if (value.IsEmpty())
            {
                return defaultValue;
            }

            try
            {
                return value.ToGuid();
            }
            catch
            {
                //
            }

            return defaultValue;
        }

        #endregion

        #region Stream

        public static Stream ToStream(this string value, Encoding encoding = null)
        {
            var result = new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(value));
            return result;
        }

        #endregion

        #region Check Type

        public static bool IsNumber(this string value)
        {
            var result = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"\d+");
            return result;
        }

        public static bool IsChinese(this string value)
        {
            var result = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[\u4e00-\u9fa5]$");
            return result;
        }

        #endregion

        #region Reverse

        public static string Reverse(this string value)
        {
            if (value.IsEmpty() || (value.Length == 1))
            {
                return value;
            }

            var chars = value.ToCharArray();
            Array.Reverse(chars);
            var result = new string(chars);
            return result;
        }

        public static string ReverseLine(this string value)
        {
            lock (StringBuilder)
            {
                try
                {
                    var lines = value.Split('\n');
                    for (var i = lines.Length - 1; i >= 0; i--)
                    {
                        StringBuilder.Append(lines[i]);
                        if (i == lines.Length - 1 && !lines[i].EndsWith("\n")) StringBuilder.Append("\n");
                    }

                    var result = StringBuilder.ToString();
                    return result;
                }
                finally
                {
                    StringBuilder.Clear();
                }
            }
        }

        public static string RemoveLeft(this string value, int length)
        {
            var result = value.Length <= length ? "" : value.Substring(length);
            return result;
        }

        public static string RemoveRight(this string value, int length)
        {
            var result = value.Length <= length ? "" : value.Substring(0, value.Length - length);
            return result;
        }

        #endregion

        #region Enum

        public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        {
            var result = value.IsInEnum<TEnum>() ? default(TEnum) : (TEnum) Enum.Parse(typeof(TEnum), value, default(bool));
            return result;
        }

        public static bool IsInEnum<TEnum>(this string value) where TEnum : struct
        {
            var result = string.IsNullOrEmpty(value) || !Enum.IsDefined(typeof(TEnum), value);
            return result;
        }

        #endregion

        #region Encoding

        public static byte[] GetBytes(this string value)
        {
            var result = Encoding.Default.GetBytes(value);
            return result;
        }

        public static byte[] GetBytes(this string value, Encoding encoding)
        {
            var result = encoding.GetBytes(value);
            return result;
        }

        public static string Encode(this string value, Encoding oldEncode, Encoding newEncode)
        {
            var oldBytes = oldEncode.GetBytes(value);
            var newBytes = Encoding.Convert(oldEncode, newEncode, oldBytes);
            var result = newEncode.GetString(newBytes);
            return result;
        }

        #endregion

        #region Base64

        public static string EncodeBase64(this string value)
        {
            var result = value.EncodeBase64(null);
            return result;
        }

        public static string EncodeBase64(this string value, Encoding encoding)
        {
            encoding = (encoding ?? Encoding.UTF8);
            var bytes = encoding.GetBytes(value);
            var result = Convert.ToBase64String(bytes);
            return result;
        }

        public static string DecodeBase64(this string value)
        {
            var result = value.DecodeBase64(null);
            return result;
        }

        public static string DecodeBase64(this string value, Encoding encoding)
        {
            encoding = (encoding ?? Encoding.UTF8);
            var bytes = Convert.FromBase64String(value);
            var result = encoding.GetString(bytes);
            return result;
        }

        #endregion

        #region Compress

        public static string Compress(this string value)
        {
            var inputBytes = Encoding.Default.GetBytes(value);
            using (var outStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(outStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                    zipStream.Close();
                    var result = Convert.ToBase64String(outStream.ToArray());
                    return result;
                }
            }
        }

        public static string Decompress(this string value)
        {
            var inputBytes = Convert.FromBase64String(value);
            using (var inputStream = new MemoryStream(inputBytes))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        var bytes = new byte[4096];
                        int n;
                        while ((n = zipStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            outStream.Write(bytes, 0, n);
                        }

                        var result = Encoding.Default.GetString(outStream.ToArray());
                        return result;
                    }
                }
            }
        }

        #endregion

        #region IO Directory

        public static bool ExistDirectory(this string directoryPath)
        {
            var result = Directory.Exists(directoryPath);
            return result;
        }

        public static string CreateDirectory(this string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public static string DeleteDirectory(this string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath);
            }

            return directoryPath;
        }

        #endregion

        #region IO File

        public static bool ExistFile(this string filePath)
        {
            var result = File.Exists(filePath);
            return result;
        }

        public static string DeleteFile(this string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return filePath;
        }

        public static string WriteAllText(this string text, string saveFilePath)
        {
            File.WriteAllText(saveFilePath, text);
            return text;
        }

        public static string ReadAllText(this string filePath)
        {
            var result = File.ReadAllText(filePath);
            return result;
        }

        public static byte[] ReadAllBytes(this string filePath)
        {
            var result = File.ReadAllBytes(filePath);
            return result;
        }

        public static string[] ReadAllLines(this string filePath)
        {
            var result = File.ReadAllLines(filePath);
            return result;
        }

        #endregion

        #region IO Path

        public static string CombinePath(this string path, string nextPath)
        {
            var result = Path.Combine(path, nextPath);
            return result;
        }

        public static string CombinePaths(this string path, params string[] paths)
        {
            var result = path;
            for (var i = 0; i < paths.Length; i++)
            {
                var next = paths[i];
                result = Path.Combine(result, next);
            }

            return result;
        }

        #endregion

        #region Html

        public static string ToHtmlSafe(this string value)
        {
            var result = value.ToHtmlSafe(false, false);
            return result;
        }

        public static string ToHtmlSafe(this string value, bool all)
        {
            var result = value.ToHtmlSafe(all, false);
            return result;
        }

        public static string ToHtmlSafe(this string value, bool all, bool replace)
        {
            if (value.IsEmptyOrWhiteSpace()) return string.Empty;
            var entities = new[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 31, 34, 39, 38, 60, 62, 123, 124, 125, 126,
                127, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189,
                190, 191, 215, 247, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218,
                219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
                250, 251, 252, 253, 254, 255, 256, 8704, 8706, 8707, 8709, 8711, 8712, 8713, 8715, 8719, 8721, 8722, 8727, 8730, 8733, 8734, 8736, 8743, 8744, 8745, 8746,
                8747, 8756, 8764, 8773, 8776, 8800, 8801, 8804, 8805, 8834, 8835, 8836, 8838, 8839, 8853, 8855, 8869, 8901, 913, 914, 915, 916, 917, 918, 919, 920, 921,
                922, 923, 924, 925, 926, 927, 928, 929, 931, 932, 933, 934, 935, 936, 937, 945, 946, 947, 948, 949, 950, 951, 952, 953, 954, 955, 956, 957, 958, 959, 960,
                961, 962, 963, 964, 965, 966, 967, 968, 969, 977, 978, 982, 338, 339, 352, 353, 376, 402, 710, 732, 8194, 8195, 8201, 8204, 8205, 8206, 8207, 8211, 8212,
                8216, 8217, 8218, 8220, 8221, 8222, 8224, 8225, 8226, 8230, 8240, 8242, 8243, 8249, 8250, 8254, 8364, 8482, 8592, 8593, 8594, 8595, 8596, 8629, 8968,
                8969, 8970, 8971, 9674, 9824, 9827, 9829, 9830
            };
            var stringBuilder = new StringBuilder();
            foreach (var c in value)
            {
                if (all || entities.Contains(c))
                {
                    stringBuilder.Append("&#" + ((int) c) + ";");
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            var result = replace ? stringBuilder.Replace("", "<br />").Replace("\n", "<br />").Replace(" ", "&nbsp;").ToString() : stringBuilder.ToString();
            return result;
        }

        #endregion
    }
}