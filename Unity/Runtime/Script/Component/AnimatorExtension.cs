#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
using UnityEngine;

namespace Aya.Extension
{
    public static class AnimatorExtension
    {
        #region Parameter
        
        public static void ResetParameters(this Animator animator)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var param = animator.parameters[i];
                switch (param.type)
                {
                    case AnimatorControllerParameterType.Bool:
                        animator.SetBool(param.name, param.defaultBool);
                        break;
                    case AnimatorControllerParameterType.Int:
                        animator.SetInteger(param.name, param.defaultInt);
                        break;
                    case AnimatorControllerParameterType.Float:
                        animator.SetFloat(param.name, param.defaultFloat);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        animator.ResetTrigger(param.name);
                        break;
                }
            }
        }

        public static bool CheckParameterExist(this Animator animator, string parameterName)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var parameter = animator.parameters[i];
                if (parameter.name == parameterName) return true;
            }

            return false;
        }

        public static bool CheckParameterExist(this Animator animator, string parameterName, AnimatorControllerParameterType type)
        {
            for (var i = 0; i < animator.parameters.Length; i++)
            {
                var parameter = animator.parameters[i];
                if (parameter.name == parameterName && parameter.type == type) return true;
            }

            return false;
        }

        #endregion

        #region State

#if UNITY_EDITOR

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

#endif

        #endregion

        #region Clip

        public static bool CheckClipExist(this Animator animator, string clipName)
        {
            var controller = animator.runtimeAnimatorController;
            if (controller == null) return false;
            var clips = controller.animationClips;
            for (var i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                if (clip.name == clipName) return true;
            }

            return false;
        }

        #endregion

        #region Layer

        public static float GetLayerWeight(this Animator animator, string layerName)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            var weight = animator.GetLayerWeight(layerIndex);
            return weight;
        }

        public static void SetLayerWeight(this Animator animator, string layerName, float weight)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            animator.SetLayerWeight(layerIndex, weight);
        }

        public static bool CheckLayerExist(this Animator animator, string layerName)
        {
            for (var i = 0; i < animator.layerCount; i++)
            {
                var name = animator.GetLayerName(i);
                if (name == layerName)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Animator State Info

        public static AnimatorStateInfo GetCurrentAnimatorStateInfo(this Animator animator, string layerName)
        {
            var layerIndex = animator.GetLayerIndex(layerName);
            var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
            return animatorStateInfo;
        }

        #endregion
    }
}
