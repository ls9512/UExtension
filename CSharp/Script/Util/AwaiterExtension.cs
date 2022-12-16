using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Aya.Extension
{
    public static class AwaiterExtension
    {
        public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan).GetAwaiter();
        }

        public static TaskAwaiter GetAwaiter(this int seconds)
        {
            return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
        }

        public static TaskAwaiter GetAwaiter(this float seconds)
        {
            return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
        }
    }
}