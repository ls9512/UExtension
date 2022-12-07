using UnityEngine;

namespace Aya.Extension
{
    public static class BehaviourExtension
    {
        public static T Enable<T>(this T behaviour) where T : Behaviour
        {
            behaviour.enabled = true;
            return behaviour;
        }

        public static T Disable<T>(this T behaviour) where T : Behaviour
        {
            behaviour.enabled = false;
            return behaviour;
        }
    }
}
