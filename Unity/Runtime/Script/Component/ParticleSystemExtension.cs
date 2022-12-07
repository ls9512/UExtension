using UnityEngine;

namespace Aya.Extension
{
    public static class ParticleSystemExtension
    {
        public static float GetDuration(this ParticleSystem particle, bool allowLoop = false)
        {
            if (!particle.emission.enabled) return 0f;
            if (particle.main.loop && !allowLoop)
            {
                return -1f;
            }
            if (particle.emission.rateOverTime.GetMinValue() <= 0)
            {
                return particle.main.startDelay.GetMaxValue() + particle.main.startLifetime.GetMaxValue();
            }
            else
            {
                return particle.main.startDelay.GetMaxValue() + Mathf.Max(particle.main.duration, particle.main.startLifetime.GetMaxValue());
            }
        }
    }
}