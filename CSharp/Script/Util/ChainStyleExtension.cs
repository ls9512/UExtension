using System;

namespace Aya.Extension
{
    public static partial class ChainStyleExtension
    {
        #region Do

        public static T Do<T>(this T target, params Action[] actions)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action();
            }

            return target;
        }

        public static T Do<T>(this T target, params Action<T>[] actions)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action(target);
            }

            return target;
        }

        #endregion

        #region If / Else

        public static T If<T>(this T target, Func<bool> predicate, Action successAction)
        {
            if (predicate())
            {
                successAction();
            }

            return target;
        }

        public static T If<T>(this T target, Func<bool> predicate, Action successAction, Action failAction)
        {
            if (predicate())
            {
                successAction();
            }
            else
            {
                failAction();
            }

            return target;
        }

        public static T If<T>(this T target, Func<bool> predicate, Action<T> successAction)
        {
            if (predicate())
            {
                successAction(target);
            }

            return target;
        }

        public static T If<T>(this T target, Func<bool> predicate, Action<T> successAction, Action<T> failAction)
        {
            if (predicate())
            {
                successAction(target);
            }
            else
            {
                failAction(target);
            }

            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action successAction)
        {
            if (predicate(target))
            {
                successAction();
            }

            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action successAction, Action failAction)
        {
            if (predicate(target))
            {
                successAction();
            }
            else
            {
                failAction();
            }

            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action<T> successAction)
        {
            if (predicate(target))
            {
                successAction(target);
            }

            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action<T> successAction, Action<T> failAction)
        {
            if (predicate(target))
            {
                successAction(target);
            }
            else
            {
                failAction(target);
            }

            return target;
        }

        public static T If<T>(this T target, Func<bool> predicate, Action<bool> action)
        {
            action(predicate());
            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action<bool> action)
        {
            action(predicate(target));
            return target;
        }

        public static T If<T>(this T target, Func<bool> predicate, Action<T, bool> action)
        {
            action(target, predicate());
            return target;
        }

        public static T If<T>(this T target, Predicate<T> predicate, Action<T, bool> action)
        {
            action(target, predicate(target));
            return target;
        }

        #endregion

        #region While

        public static T While<T>(this T target, Func<bool> predicate, params Action[] actions) where T : class
        {
            while (predicate())
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action();
                }
            }
            return target;
        }

        public static T While<T>(this T target, Func<bool> predicate, params Action<T>[] actions) where T : class
        {
            while (predicate())
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action(target);
                }
            }
            return target;
        }

        public static T While<T>(this T target, Predicate<T> predicate, params Action[] actions) where T : class
        {
            while (predicate(target))
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action();
                }
            }
            return target;
        }

        public static T While<T>(this T target, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            while (predicate(target))
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action(target);
                }
            }
            return target;
        }

        #endregion

        #region Do While

        public static T DoWhile<T>(this T target, Func<bool> predicate, params Action[] actions) where T : class
        {
            do
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action();
                }
            } while (predicate());
            return target;
        }

        public static T DoWhile<T>(this T target, Func<bool> predicate, params Action<T>[] actions) where T : class
        {
            do
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action(target);
                }
            } while (predicate());

            return target;
        }

        public static T DoWhile<T>(this T target, Predicate<T> predicate, params Action[] actions) where T : class
        {
            do
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action();
                }
            } while (predicate(target));

            return target;
        }

        public static T DoWhile<T>(this T target, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            do
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    var action = actions[i];
                    action(target);
                }
            } while (predicate(target));

            return target;
        }

        #endregion

        #region For

        public static T For<T>(this T target, int count, Action<int> action)
        {
            return For(target, 0, count, 1, action);
        }

        public static T For<T>(this T target, int from, int to, Action<int> action)
        {
            return For(target, from, to, 1, action);
        }

        public static T For<T>(this T target, int from, int to, int step, Action<int> action)
        {
            for (var index = from; index < to; index += step)
            {
                action(index);
            }

            return target;
        }

        public static T For<T>(this T target, int count, Action<int, T> action)
        {
            return For(target, 0, count, 1, action);
        }

        public static T For<T>(this T target, int from, int to, Action<int, T> action)
        {
            return For(target, from, to, 1, action);
        }

        public static T For<T>(this T target, int from, int to, int step, Action<int, T> action)
        {
            for (var index = from; index < to; index += step)
            {
                action(index, target);
            }

            return target;
        }

        #endregion

        #region Switch Case

        //  How to use :	var typeName = string.Empty;
        //					var typeID = 2;
        //					typeID.Switch((string s) => typeName = s)
        //								.Case(0, "食品")
        //								.Case(1, "饮料")
        //								.Case(2, "酒水")
        //								.Case(3, "毒药")
        //								.Default("未知");
        //								Debug.Log(typeName);
        //
        //  Warning :	链式编程中，当第一个条件就满足需要break时，只能返回null，然后传递直至所有条件结束，无法中途退出，有一定性能浪费。

        #region Swith

        public static SwitchCase<TCase, TOther> Switch<TCase, TOther>(this TCase @case, Action<TOther> action) where TCase : IEquatable<TCase>
        {
            var result = new SwitchCase<TCase, TOther>(@case, action);
            return result;
        }

        public static SwitchCase<TCase, TOther> Switch<TInput, TCase, TOther>(this TInput input, Func<TInput, TCase> selector, Action<TOther> action) where TCase : IEquatable<TCase>
        {
            var result = new SwitchCase<TCase, TOther>(selector(input), action);
            return result;
        }

        #endregion

        #region Case

        public static SwitchCase<TCase, TOther> Case<TCase, TOther>(this SwitchCase<TCase, TOther> switchCase, TCase option, TOther other) where TCase : IEquatable<TCase>
        {
            var result = Case(switchCase, option, other, true);
            return result;
        }

        public static SwitchCase<TCase, TOther> Case<TCase, TOther>(this SwitchCase<TCase, TOther> switchCase, TCase option, TOther other, bool bBreak) where TCase : IEquatable<TCase>
        {
            var result = Case(switchCase, c => c.Equals(option), other, bBreak);
            return result;
        }

        public static SwitchCase<TCase, TOther> Case<TCase, TOther>(this SwitchCase<TCase, TOther> switchCase, Predicate<TCase> predicate, TOther other) where TCase : IEquatable<TCase>
        {
            var result = Case(switchCase, predicate, other, true);
            return result;
        }

        public static SwitchCase<TCase, TOther> Case<TCase, TOther>(this SwitchCase<TCase, TOther> swichCase, Predicate<TCase> predicate, TOther other, bool bBreak) where TCase : IEquatable<TCase>
        {
            if (swichCase == null) return null;
            if (!predicate(swichCase.Value)) return swichCase;
            swichCase.Action(other);
            var result = bBreak ? null : swichCase;
            return result;
        }

        #endregion

        #region Default

        public static SwitchCase<TCase, TOther> Default<TCase, TOther>(this SwitchCase<TCase, TOther> switchCase, TOther other)
        {
            switchCase?.Action(other);
            return switchCase;
        }

        #endregion

        #region SwithCase

        public class SwitchCase<TCase, TOther>
        {
            public SwitchCase(TCase value, Action<TOther> action)
            {
                Value = value;
                Action = action;
            }

            public TCase Value { get; private set; }
            public Action<TOther> Action { get; private set; }
        }

        #endregion

        #endregion
    }
}
