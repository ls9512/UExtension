
namespace Aya.Extension
{
    public static class CharExtension
    {
        public static bool IsControl(this char @char)
        {
            return char.IsControl(@char);
        }

        public static bool IsDigit(this char @char)
        {
            return char.IsDigit(@char);
        }

        public static bool IsHighSurrogate(this char @char)
        {
            return char.IsHighSurrogate(@char);
        }

        public static bool IsLowSurrogate(this char @char)
        {
            return char.IsLowSurrogate(@char);
        }

        public static bool IsPunctuation(this char @char)
        {
            return char.IsPunctuation(@char);
        }

        public static bool IsLetter(this char @char)
        {
            return char.IsLetter(@char);
        }

        public static bool IsLetterOrDigit(this char @char)
        {
            return char.IsLetterOrDigit(@char);
        }

        public static bool IsSymbol(this char @char)
        {
            return char.IsSymbol(@char);
        }

        public static bool IsSeparator(this char @char)
        {
            return char.IsSeparator(@char);
        }

        public static bool IsSurrogate(this char @char)
        {
            return char.IsSurrogate(@char);
        }

        public static bool IsLower(this char @char)
        {
            return char.IsLower(@char);
        }

        public static bool IsUpper(this char @char)
        {
            return char.IsUpper(@char);
        }

        public static char ToLower(this char @char)
        {
            return char.ToLower(@char);
        }

        public static char ToUpper(this char @char)
        {
            return char.ToUpper(@char);
        }
        public static bool IsWhiteSpace(this char @char)
        {
            return char.IsWhiteSpace(@char);
        }
    }
}
