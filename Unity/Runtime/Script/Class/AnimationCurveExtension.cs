using UnityEngine;

namespace Aya.Extension
{
    public static class AnimationCurveExtension
    {
        public static bool IsLooping(this AnimationCurve animationCurve)
        {
            var result = animationCurve != null && (animationCurve.postWrapMode.Equals(WrapMode.Loop) || animationCurve.postWrapMode.Equals(WrapMode.PingPong));
            return result;
        }

        public static float GetMaxValue(this AnimationCurve animationCurve)
        {
            var ret = float.MinValue;
            var frames = animationCurve.keys;
            for (var i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];
                var value = frame.value;
                if (value > ret)
                {
                    ret = value;
                }
            }

            return ret;
        }

        public static float GetMinValue(this AnimationCurve animationCurve)
        {
            var ret = float.MaxValue;
            var frames = animationCurve.keys;
            for (var i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];
                var value = frame.value;
                if (value < ret)
                {
                    ret = value;
                }
            }

            return ret;
        }

        public static void Reverse(this AnimationCurve animationCurve)
        {
            var keys = animationCurve.keys;
            var newKeys = new Keyframe[keys.Length];

            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                newKeys[keys.Length - 1 - i] = new Keyframe(1f - key.time, key.value, -key.outTangent,  -key.inTangent);
            }

            animationCurve.keys = newKeys;
        }
    }
}