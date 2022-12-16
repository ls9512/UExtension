#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEngine;

namespace Aya.Extension
{
    public static partial class AnimatorExtension
    {
        #region State

        public static bool CheckStateExist(this Animator animator, string stateName)
        {
            return animator.CheckStateExist(0, stateName);
        }

        public static bool CheckStateExist(this Animator animator, int layerIndex, string stateName)
        {
            var controller = animator.runtimeAnimatorController as AnimatorController;
            if (controller == null) return false;
            var states = controller.layers[layerIndex].stateMachine.states;
            foreach (var state in states)
            {
                if (state.state.name == stateName) return true;
            }

            return false;
        }

        #endregion
    }
}
#endif