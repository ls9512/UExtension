using System.Text;

namespace Aya.Extension
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Reverse(this StringBuilder builder)
        {
            var result = new StringBuilder();
            for (var i = builder.Length - 1; i >= 0; i--)
            {
                result.Append(builder[i]);
            }

            builder.Remove(0, builder.Length);
            builder.Append(result);
            return builder;
        }

        public static StringBuilder Clear(this StringBuilder builder)
        {
            builder.Remove(0, builder.Length);
            return builder;
        }
    }
}