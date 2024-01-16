using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class MonoBehaviourExtension
    {
        #region Active

        public static void SetActive(this MonoBehaviour monoBehaviour, bool active)
        {
            monoBehaviour.gameObject.SetActive(active);
        }

        #endregion

        #region Prefab

        public static bool IsPrefab(this MonoBehaviour monoBehaviour)
        {
            var result = monoBehaviour.gameObject.IsPrefab();
            return result;
        }

        #endregion

        #region Coroutine

        #region When

        public static Coroutine ExecuteWhen(this MonoBehaviour monoBehaviour, Action action, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteWhenCoroutine(action, condition));
        }

        private static IEnumerator ExecuteWhenCoroutine(Action action, Func<bool> condition)
        {
            while (condition != null && !condition())
            {
                yield return null;
            }

            action();
        }

        #endregion

        #region Until

        public static Coroutine ExecuteUntil(this MonoBehaviour monoBehaviour, Action action, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteUntilCoroutine(action, condition));
        }

        private static IEnumerator ExecuteUntilCoroutine(Action action, Func<bool> condition)
        {
            while (condition != null && !condition())
            {
                action();
                yield return null;
            }
        }

        #endregion

        #region Count Until

        public static Coroutine ExecuteCountUntil(this MonoBehaviour monoBehaviour, Action action, int count, Func<bool> condition)
        {
            return monoBehaviour.StartCoroutine(ExecuteCountUntilCoroutine(action, count, condition));
        }

        private static IEnumerator ExecuteCountUntilCoroutine(Action action, int count, Func<bool> condition)
        {
            var counter = 0;
            while (condition != null && !condition() && counter < count)
            {
                action();
                counter++;
                yield return null;
            }
        }

        #endregion

        #region Interval Until

        public static Coroutine ExecuteIntervalUntil(this MonoBehaviour monoBehaviour, Action action, float interval, int count, Func<bool> condition, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalUntilCoroutine(action, count, interval, condition, timeScale));
        }

        private static IEnumerator ExecuteIntervalUntilCoroutine(Action action, int count, float interval, Func<bool> condition, bool timeScale)
        {
            var counter = 0;
            while (condition != null && !condition() && counter < count)
            {
                action();
                counter++;
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }

        public static Coroutine ExecuteIntervalUntil(this MonoBehaviour monoBehaviour, Action action, float interval, Func<bool> condition, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalUntilCoroutine(action, interval, condition, timeScale));
        }

        private static IEnumerator ExecuteIntervalUntilCoroutine(Action action, float interval, Func<bool> condition, bool timeScale)
        {
            while (condition != null && !condition())
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }

        #endregion

        #region If Until

        public static Coroutine ExecuteIfUntil(this MonoBehaviour monoBehaviour, Action action, Func<bool> executeCondition, Func<bool> finishCondition)
        {
            return monoBehaviour.StartCoroutine(ExecuteIfUntilCoroutine(action, executeCondition, finishCondition));
        }

        private static IEnumerator ExecuteIfUntilCoroutine(Action action, Func<bool> executeCondition, Func<bool> finishCondition)
        {
            while (finishCondition != null && !finishCondition())
            {
                if (executeCondition())
                {
                    action();
                }

                yield return null;
            }
        }

        #endregion

        #region Delay

        public static Coroutine ExecuteDelay(this MonoBehaviour monoBehaviour, Action action, float seconds, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteDelayCoroutine(action, seconds, timeScale));
        }

        private static IEnumerator ExecuteDelayCoroutine(Action action, float seconds, bool timeScale)
        {
            if (timeScale)
            {
                yield return WaitForSeconds(seconds);
            }
            else
            {
                yield return WaitForSecondsRealtime(seconds);
            }

            action();
        }

        #endregion

        #region Count

        public static Coroutine ExecuteCount(this MonoBehaviour monoBehaviour, Action action, int count)
        {
            return monoBehaviour.StartCoroutine(ExecuteCountCoroutine(action, count));
        }

        private static IEnumerator ExecuteCountCoroutine(Action action, int count)
        {
            for (var i = 0; i < count; i++)
            {
                action();
                yield return null;
            }
        }

        #endregion

        #region Interval

        public static Coroutine ExecuteInterval(this MonoBehaviour monoBehaviour, Action action, float interval, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, interval, timeScale));
        }

        private static IEnumerator ExecuteIntervalCoroutine(Action action, float interval, bool timeScale)
        {
            while (true)
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }

        public static Coroutine ExecuteInterval(this MonoBehaviour monoBehaviour, Action action, float interval, float duration, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, interval, duration, timeScale));
        }

        private static IEnumerator ExecuteIntervalCoroutine(Action action, float interval, float duration, bool timeScale)
        {
            var timer = 0f;
            var executeTimer = 0f;
            while (timer <= duration)
            {
                var deltaTime = timeScale ? Time.deltaTime : Time.unscaledTime;
                timer += deltaTime;
                executeTimer += deltaTime;
                if (executeTimer >= interval)
                {
                    action();
                    executeTimer -= interval;
                }

                yield return null;
            }
        }

        #endregion

        #region Interval Count

        public static Coroutine ExecuteIntervalCount(this MonoBehaviour monoBehaviour, Action action, int count, float interval, bool timeScale = true)
        {
            return monoBehaviour.StartCoroutine(ExecuteIntervalCoroutine(action, count, interval, timeScale));
        }

        private static IEnumerator ExecuteIntervalCountCoroutine(Action action, int count, float interval, bool timeScale)
        {
            for (var i = 0; i < count; i++)
            {
                action();
                if (timeScale)
                {
                    yield return WaitForSeconds(interval);
                }
                else
                {
                    yield return WaitForSecondsRealtime(interval);
                }
            }
        }

        #endregion

        #region Next Frame

        public static Coroutine ExecuteNextFrame(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteNextFrameCoroutine(action));
        }

        private static IEnumerator ExecuteNextFrameCoroutine(Action action)
        {
            yield return null;
            action();
        }

        #endregion

        #region End Of Frame

        public static Coroutine ExecuteEndOfFrame(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteEndOfFrameCoroutine(action));
        }

        private static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();

        private static IEnumerator ExecuteEndOfFrameCoroutine(Action action)
        {
            yield return WaitForEndOfFrame;
            action();
        }

        #endregion

        #region After Frames

        public static Coroutine ExecuteAfterFrames(this MonoBehaviour monoBehaviour, Action action, int frames)
        {
            return monoBehaviour.StartCoroutine(ExecuteAfterFramesCoroutine(action, frames));
        }

        private static IEnumerator ExecuteAfterFramesCoroutine(Action action, int frames)
        {
            var count = 0;
            while (count < frames)
            {
                count++;
                yield return null;
            }

            action();
        }

        #endregion

        #region Next When Fixed Update

        public static Coroutine ExecuteWhenFixedUpdate(this MonoBehaviour monoBehaviour, Action action)
        {
            return monoBehaviour.StartCoroutine(ExecuteWhenFixedUpdateCoroutine(action));
        }

        private static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

        private static IEnumerator ExecuteWhenFixedUpdateCoroutine(Action action)
        {
            yield return WaitForFixedUpdate;
            action();
        }

        #endregion

        #region Restart

        public static Coroutine RestartCoroutine(this MonoBehaviour monoBehaviour, string methodName)
        {
            monoBehaviour.StopCoroutine(methodName);
            return monoBehaviour.StartCoroutine(methodName);
        }

        #endregion

        #region Sync

        public static Coroutine StartCoroutineSync(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
        {
            return monoBehaviour.StartCoroutine(ToFixedCoroutine(enumerator));
        }

        private static IEnumerator ToFixedCoroutine(IEnumerator enumerator)
        {
            var parentsStack = new Stack<IEnumerator>();
            var currentEnumerator = enumerator;
            parentsStack.Push(currentEnumerator);
            while (parentsStack.Count > 0)
            {
                currentEnumerator = parentsStack.Pop();
                while (currentEnumerator.MoveNext())
                {
                    if (currentEnumerator.Current is IEnumerator subEnumerator)
                    {
                        parentsStack.Push(currentEnumerator);
                        currentEnumerator = subEnumerator;
                    }
                    else
                    {
                        if (currentEnumerator.Current is bool check && check) continue;
                        yield return currentEnumerator.Current;
                    }
                }
            }
        }

        #endregion

        #region Wait For

        internal static IEnumerator WaitForSeconds(float second, bool timeScale)
        {
            if (timeScale)
            {
                yield return WaitForSeconds(second);
            }
            else
            {
                yield return WaitForSecondsRealtime(second);
            }
        }

        internal static IEnumerator WaitForSeconds(float second)
        {
            var timer = 0f;
            do
            {
                timer += Time.deltaTime;
                yield return null;
            } while (timer < second);
        }

        internal static IEnumerator WaitForSecondsRealtime(float second)
        {
            var timer = 0f;
            do
            {
                timer += Time.unscaledDeltaTime;
                yield return null;
            } while (timer < second);
        }

        #endregion

        #endregion
    }
}