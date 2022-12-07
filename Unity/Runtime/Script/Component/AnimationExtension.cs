using System;
using UnityEngine;

namespace Aya.Extension
{
    public static class AnimationExtension
    {
        #region Event

        public static Animation AddEvent(this Animation animation, string clipName, string methodName, float time)
        {
            var clip = animation[clipName].clip;
            var animationEvent = new AnimationEvent
            {
                functionName = methodName,
                time = time
            };
            clip.AddEvent(animationEvent);
            return animation;
        }

        public static Animation RemoveEvent(this Animation animation, string clipName, string methodName)
        {
            var clip = animation[clipName].clip;
            var list = clip.events.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                var e = list[i];
                if (e.functionName != methodName) continue;
                list.Remove(e);
                break;
            }

            clip.events = list.ToArray();
            return animation;
        }

        #endregion

        public static Animation SetSpeed(this Animation animation, float speed)
        {
            animation[animation.clip.name].speed = speed;
            return animation;
        }

        public static Animation SetTime(this Animation animation, float time)
        {
            var clip = animation[animation.clip.name].clip;
            clip.SampleAnimation(animation.gameObject, time);
            return animation;
        }

        public static Animation SetProgress(this Animation animation, float progress)
        {
            var clip = animation[animation.clip.name].clip;
            var time = clip.length * progress;
            clip.SampleAnimation(animation.gameObject, time);
            return animation;
        }

        public static AnimationClip GetPlayingClip(this Animation animation)
        {
            AnimationClip clip = null;
            var weight = 0f;
            var enumerator = animation.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var current = (AnimationState) enumerator.Current;
                    if (current == null) continue;
                    if (!current.enabled || (!(weight < current.weight))) continue;
                    weight = current.weight;
                    clip = current.clip;
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }

            return clip;
        }
    }
}