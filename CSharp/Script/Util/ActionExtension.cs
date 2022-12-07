using System;

namespace Aya.Extension
{
    public static partial class ActionExtension
    {
        public static void Invoke(this Action[] actions)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action();
            }
        }

        public static void Invoke<T1>(this Action<T1>[] actions, T1 t1)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1);
            }
        }

        public static void Invoke<T1, T2>(this Action<T1, T2>[] actions, T1 t1, T2 t2)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2);
            }
        }

        public static void Invoke<T1, T2, T3>(this Action<T1, T2, T3>[] actions, T1 t1, T2 t2, T3 t3)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3);
            }
        }

        public static void Invoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4>[] actions, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3, t4);
            }
        }

        public static void Invoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5>[] actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3, t4, t5);
            }
        }

        public static void Invoke<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6>[] actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3, t4, t5, t6);
            }
        }

        public static void Invoke<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7>[] actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3, t4, t5, t6, t7);
            }
        }

        public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8>[] actions, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(t1, t2, t3, t4, t5, t6, t7, t8);
            }
        }
    }
}
