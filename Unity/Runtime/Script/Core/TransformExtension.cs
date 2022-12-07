using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Aya.Extension
{
    public static class TransformExtension
    {
        #region Position

        #region Set

        public static Transform SetPositionX(this Transform transform, float x)
        {
            var position = transform.position;
            position.x = x;
            transform.position = position;
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, float y)
        {
            var position = transform.position;
            position.y = y;
            transform.position = position;
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, float z)
        {
            var position = transform.position;
            position.z = z;
            transform.position = position;
            return transform;
        }

        public static Transform SetPositionXY(this Transform transform, float x, float y)
        {
            var position = transform.position;
            position.x = x;
            position.y = y;
            transform.position = position;
            return transform;
        }

        public static Transform SetPositionXZ(this Transform transform, float x, float z)
        {
            var position = transform.position;
            position.x = x;
            position.z = z;
            transform.position = position;
            return transform;
        }

        public static Transform SetPositionYZ(this Transform transform, float y, float z)
        {
            var position = transform.position;
            position.y = y;
            position.z = z;
            transform.position = position;
            return transform;
        }

        #endregion

        #region Get

        public static float GetPositionX(this Transform transform)
        {
            return transform.position.x;
        }

        public static float GetPositionY(this Transform transform)
        {
            return transform.position.y;
        }

        public static float GetPositionZ(this Transform transform)
        {
            return transform.position.z;
        }

        public static Vector2 GetPositionXY(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.x, position.y);
        }

        public static Vector2 GetPositionXZ(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.x, position.z);
        }

        public static Vector2 GetPositionYZ(this Transform transform)
        {
            var position = transform.position;
            return new Vector2(position.y, position.z);
        }

        #endregion

        #endregion

        #region Rotation

        #region Get

        public static float GetRotationX(this Transform transform)
        {
            return transform.rotation.x;
        }

        public static float GetRotationY(this Transform transform)
        {
            return transform.rotation.y;
        }

        public static float GetRotationZ(this Transform transform)
        {
            return transform.rotation.z;
        }

        public static float GetRotationW(this Transform transform)
        {
            return transform.rotation.w;
        }

        #endregion

        #region Set

        public static Transform SetRotationX(this Transform transform, float x)
        {
            var rotation = transform.rotation;
            rotation.x = x;
            transform.rotation = rotation;
            return transform;
        }

        public static Transform SetRotationY(this Transform transform, float y)
        {
            var rotation = transform.rotation;
            rotation.y = y;
            transform.rotation = rotation;
            return transform;
        }

        public static Transform SetRotationZ(this Transform transform, float z)
        {
            var rotation = transform.rotation;
            rotation.z = z;
            transform.rotation = rotation;
            return transform;
        }

        public static Transform SetRotationW(this Transform transform, float w)
        {
            var rotation = transform.rotation;
            rotation.w = w;
            transform.rotation = rotation;
            return transform;
        }

        #endregion

        #endregion

        #region EulerAngles

        #region Set

        public static Transform SetEulerAnglesX(this Transform transform, float x)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAnglesY(this Transform transform, float y)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y = y;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAnglesZ(this Transform transform, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAnglesXY(this Transform transform, float x, float y)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            eulerAngles.y = y;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAnglesXZ(this Transform transform, float x, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.x = x;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAnglesYZ(this Transform transform, float y, float z)
        {
            var eulerAngles = transform.eulerAngles;
            eulerAngles.y = y;
            eulerAngles.z = z;
            transform.eulerAngles = eulerAngles;
            return transform;
        }

        #endregion

        #region Get

        public static float GetEulerAnglesX(this Transform transform)
        {
            return transform.eulerAngles.x;
        }

        public static float GetEulerAnglesY(this Transform transform)
        {
            return transform.eulerAngles.y;
        }

        public static float GetEulerAnglesZ(this Transform transform)
        {
            return transform.eulerAngles.z;
        }

        public static Vector2 GetEulerAnglesXY(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.x, eulerAngles.y);
        }

        public static Vector2 GetEulerAnglesXZ(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.x, eulerAngles.z);
        }

        public static Vector2 GetEulerAnglesYZ(this Transform transform)
        {
            var eulerAngles = transform.eulerAngles;
            return new Vector2(eulerAngles.y, eulerAngles.z);
        }

        #endregion

        #endregion

        #region LocalPosition

        #region Set

        public static Transform SetLocalPositionX(this Transform transform, float x)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionXY(this Transform transform, float x, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionXZ(this Transform transform, float x, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionYZ(this Transform transform, float y, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            localPosition.z = z;
            transform.localPosition = localPosition;
            return transform;
        }

        #endregion

        #region Get

        public static float GetLocalPositionX(this Transform transform)
        {
            return transform.localPosition.x;
        }

        public static float GetLocalPositionY(this Transform transform)
        {
            return transform.localPosition.y;
        }

        public static float GetLocalPositionZ(this Transform transform)
        {
            return transform.localPosition.z;
        }

        public static Vector2 GetLocalPositionXY(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.x, localPosition.y);
        }

        public static Vector2 GetLocalPositionXZ(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.x, localPosition.z);
        }

        public static Vector2 GetLocalPositionYZ(this Transform transform)
        {
            var localPosition = transform.localPosition;
            return new Vector2(localPosition.y, localPosition.z);
        }

        #endregion

        #endregion

        #region LocalRotation

        #region Set

        public static Transform SetLocalRotationX(this Transform transform, float x)
        {
            var localRotation = transform.localRotation;
            localRotation.x = x;
            transform.localRotation = localRotation;
            return transform;
        }

        public static Transform SetLocalRotationY(this Transform transform, float y)
        {
            var localRotation = transform.localRotation;
            localRotation.y = y;
            transform.localRotation = localRotation;
            return transform;
        }

        public static Transform SetLocalRotationZ(this Transform transform, float z)
        {
            var localRotation = transform.localRotation;
            localRotation.z = z;
            transform.localRotation = localRotation;
            return transform;
        }

        public static Transform SetLocalRotationW(this Transform transform, float w)
        {
            var localRotation = transform.localRotation;
            localRotation.w = w;
            transform.localRotation = localRotation;
            return transform;
        }

        #endregion

        #region Get

        public static float GetLocalRotationX(this Transform transform)
        {
            return transform.localRotation.x;
        }

        public static float GetLocalRotationY(this Transform transform)
        {
            return transform.localRotation.y;
        }

        public static float GetLocalRotationZ(this Transform transform)
        {
            return transform.localRotation.z;
        }

        public static float GetLocalRotationW(this Transform transform)
        {
            return transform.localRotation.w;
        }

        #endregion

        #endregion

        #region LocalEulerAngles

        #region Set

        public static Transform SetLocalEulerAnglesX(this Transform transform, float x)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAnglesY(this Transform transform, float y)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.y = y;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAnglesZ(this Transform transform, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAnglesXY(this Transform transform, float x, float y)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            localEulerAngles.y = y;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAnglesXZ(this Transform transform, float x, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.x = x;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAnglesYZ(this Transform transform, float y, float z)
        {
            var localEulerAngles = transform.localEulerAngles;
            localEulerAngles.y = y;
            localEulerAngles.z = z;
            transform.localEulerAngles = localEulerAngles;
            return transform;
        }

        #endregion

        #region Get

        public static float GetLocalEulerAnglesX(this Transform transform)
        {
            return transform.localEulerAngles.x;
        }

        public static float GetLocalEulerAnglesY(this Transform transform)
        {
            return transform.localEulerAngles.y;
        }

        public static float GetLocalEulerAnglesZ(this Transform transform)
        {
            return transform.localEulerAngles.z;
        }

        public static Vector2 GetLocalEulerAnglesXY(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.x, localEulerAngles.y);
        }

        public static Vector2 GetLocalEulerAnglesXZ(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.x, localEulerAngles.z);
        }

        public static Vector2 GetLocalEulerAnglesYZ(this Transform transform)
        {
            var localEulerAngles = transform.localEulerAngles;
            return new Vector2(localEulerAngles.y, localEulerAngles.z);
        }

        #endregion

        #endregion

        #region LocalScale

        #region Set

        public static Transform SetLocalScaleX(this Transform transform, float x)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScaleY(this Transform transform, float y)
        {
            var localScale = transform.localScale;
            localScale.y = y;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScaleZ(this Transform transform, float z)
        {
            var localScale = transform.localScale;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScaleXY(this Transform transform, float x, float y)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            localScale.y = y;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScaleXZ(this Transform transform, float x, float z)
        {
            var localScale = transform.localScale;
            localScale.x = x;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScaleYZ(this Transform transform, float y, float z)
        {
            var localScale = transform.localScale;
            localScale.y = y;
            localScale.z = z;
            transform.localScale = localScale;
            return transform;
        }

        public static Transform SetLocalScale(this Transform transform, float uniformScale)
        {
            transform.localScale = new Vector3(uniformScale, uniformScale, uniformScale);
            return transform;
        }

        public static Transform SetLocalScale(this Transform transform, Vector3 uniformScale)
        {
            transform.localScale = uniformScale;
            return transform;
        }

        #endregion

        #region Get

        public static float GetLocalScaleX(this Transform transform)
        {
            return transform.localScale.x;
        }

        public static float GetLocalScaleY(this Transform transform)
        {
            return transform.localScale.y;
        }

        public static float GetLocalScaleZ(this Transform transform)
        {
            return transform.localScale.z;
        }

        public static Vector2 GetLocalScaleXY(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.x, localScale.y);
        }

        public static Vector2 GetLocalScaleXZ(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.x, localScale.z);
        }

        public static Vector2 GetLocalScaleYZ(this Transform transform)
        {
            var localScale = transform.localScale;
            return new Vector2(localScale.y, localScale.z);
        }

        #endregion

        #endregion

        #region Child

        public static List<T> GetAllChild<T>(this Transform transform) where T : Component
        {
            var children = new List<T>();
            for (var i = 0; i < transform.childCount; i++)
            {
                var com = transform.GetChild(i).GetComponent<T>();
                if (com)
                    children.Add(com);
            }

            return children;
        }

        public static Transform FindInAllChildFuzzy(this Transform transform, string name, bool includeInactive = false)
        {
            var list = transform.GetComponentsInChildren<Transform>(includeInactive);
            for (var i = 0; i < list.Length; i++)
            {
                var t = list[i];
                if (t.gameObject.name.IndexOf(name, StringComparison.Ordinal) >= 0)
                {
                    return t;
                }
            }

            return null;
        }

        public static Transform FindInAllChild(this Transform transform, string name, bool includeInactive = false)
        {
            var list = transform.GetComponentsInChildren<Transform>(includeInactive);
            for (var i = 0; i < list.Length; i++)
            {
                var t = list[i];
                if (t.gameObject.name == name)
                {
                    return t;
                }
            }

            return null;
        }

        public static Transform ForeachChild(this Transform transform, Action<Transform> action)
        {
            if (transform == null || transform.childCount == 0) return transform;
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                action?.Invoke(transform.GetChild(i));
            }

            return transform;
        }

        public static Transform UpdateChild(this Transform transform, int count, Action<int, Transform> updater)
        {
            if (transform.childCount == 0) return transform;
            var prefab = transform.GetChild(0).gameObject;

            var i = 0;
            for (; i < transform.childCount && i < count; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(true);
                updater(i, child);
            }

            if (count > transform.childCount)
            {
                for (; i < count; i++)
                {
                    var obj = Object.Instantiate(prefab, transform);
                    obj.gameObject.SetActive(true);
                    updater(i, obj.transform);
                }
            }
            else if (transform.childCount > count)
            {
                for (; i < transform.childCount; i++)
                {
                    var obj = transform.GetChild(i);
                    obj.gameObject.SetActive(false);
                }
            }

            return transform;
        }

        public static Transform DestroyAllChild(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var go = transform.GetChild(i).gameObject;
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    Object.Destroy(go);
                }
                else
                {
                    Object.DestroyImmediate(go);
                }
#else
                Object.Destroy(go);
#endif
            }

            return transform;
        }

        #endregion

        #region Parent

        public static T FindComponentInParents<T>(this Transform transform) where T : Component
        {
            var component = transform.GetComponent<T>();
            if (component != null)
            {
                return component;
            }

            return transform.parent != null ? FindComponentInParents<T>(transform.parent) : null;
        }

        #endregion

        #region Component

        public static T GetOrAddComponent<T>(this Transform transform) where T : Component
        {
            var component = transform.GetComponent<T>();
            if (component == null)
            {
                component = transform.gameObject.AddComponent<T>();
            }

            return component;
        }

        public static Component GetOrAddComponent(this Transform transform, Type type)
        {
            var component = transform.GetComponent(type);
            if (component == null)
            {
                component = transform.gameObject.AddComponent(type);
            }

            return component;
        }

        #endregion

        #region Reset

        public static Transform ResetPosition(this Transform transform)
        {
            transform.position = Vector3.zero;
            return transform;
        }

        public static Transform ResetLocalPosition(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            return transform;
        }

        public static Transform ResetRotation(this Transform transform)
        {
            transform.rotation = Quaternion.identity;
            return transform;
        }

        public static Transform ResetLocalRotation(this Transform transform)
        {
            transform.localRotation = Quaternion.identity;
            return transform;
        }

        public static Transform ResetLocalScale(this Transform transform)
        {
            transform.localScale = Vector3.one;
            return transform;
        }

        public static Transform Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        public static Transform ResetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        public static Transform SetParentAndResetLocal(this Transform transform, Transform parent)
        {
            transform.SetParent(parent);
            transform.ResetLocal();
            return transform;
        }

        #endregion

        #region CounteractLocalScale

        public static Vector3 CounteractLocalScale(this Transform transform)
        {
            transform.localScale = CounteractLocalScaleRecursion(transform, Vector3.one);
            return transform.localScale;
        }

        public static Vector3 CounteractLocalScale(this Transform transform, Vector3 scaleTo)
        {
            transform.localScale = CounteractLocalScaleRecursion(transform, scaleTo);
            return transform.localScale;
        }

        private static Vector3 CounteractLocalScaleRecursion(Transform transform, Vector3 scale)
        {
            while (true)
            {
                if (transform.parent == null) return scale;
                var scaleParent = transform.parent.localScale;
                var result = new Vector3(scale.x / scaleParent.x, scale.y / scaleParent.y, scale.z / scaleParent.z);
                transform = transform.parent;
                scale = result;
            }
        }

        #endregion

        #region ScreenPos

        public static Vector2 ScreenPos(this Transform transform)
        {
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            return (new Vector2(screenPos.x, screenPos.y));
        }

        public static Vector2 ScreenPosRatio(this Transform transform)
        {
            var screenPos = transform.ScreenPos();
            var ratio = new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);
            return ratio;
        }

        #endregion

        #region Copy

        public static Transform CopyTrans(this Transform transform, Transform src, bool isWordSpace)
        {
            if (isWordSpace)
            {
                transform.position = src.position;
                transform.rotation = src.rotation;
            }
            else
            {
                transform.localPosition = src.localPosition;
                transform.localRotation = src.localRotation;
            }

            transform.localScale = src.localScale;
            return transform;
        }

        #endregion

        #region Path

        public static string Path(this Transform transform)
        {
            var go = transform.gameObject;
            var path = "/" + go.name;
            while (go.transform.parent != null)
            {
                go = go.transform.parent.gameObject;
                path = "/" + go.name + path;
            }

            return path;
        }

        public static Transform Root(this Transform go)
        {
            var current = go;
            Transform result = null;
            do
            {
                var trans = current.parent;
                result = trans != null ? trans : current;
                current = trans;
            } while (current != null);

            return result;
        }

        public static int Depth(this Transform transform)
        {
            var depth = 0;
            var current = transform;
            do
            {
                current = current.parent;
                if (current != null)
                {
                    depth++;
                }
            } while (current != null);

            return depth;
        }

        #endregion

        #region Is InView

        public static bool IsInView(this Transform transform, Camera camera)
        {
            var worldPos = transform.position;
            var camTransform = camera.transform;
            var viewPos = camera.WorldToViewportPoint(worldPos);
            var dir = (worldPos - camTransform.position).normalized;
            var dot = Vector3.Dot(camTransform.forward, dir);
            if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}