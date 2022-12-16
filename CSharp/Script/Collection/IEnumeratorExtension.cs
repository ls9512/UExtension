using System.Collections;

namespace Aya.Extension
{
    public static class IEnumeratorExtension
    {
#if CSHARP_9_OR_NEWER
        public static IEnumerator GetEnumerator(this int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return i;
            }
        }
#endif
    }
}