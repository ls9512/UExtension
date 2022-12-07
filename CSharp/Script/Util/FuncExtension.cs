using System;

namespace Aya.Extension
{
    public static class FuncExtension
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> func, Func<T2, T3> composeFunc)
        {
            return result => composeFunc(func(result));
        }
    }
}
