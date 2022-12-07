using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Aya.Extension
{
    public static class GameObjectExtension
    {
        #region Prefab

        public static bool IsPrefab(this GameObject gameObject)
        {
            var result = gameObject.scene.name == null;
            return result;
        }
        
        #endregion

        #region HasComponent?

        public static bool HasComponent<T>(this GameObject gameObject)
        {
            var result = gameObject.GetComponent<T>() != null;
            return result;
        }

        public static bool HasRigidbody(this GameObject gameObject)
        {
            var result = gameObject.GetComponent<Rigidbody>() != null;
            return result;
        }

        public static bool HasAnimation(this GameObject gameObject)
        {
            var result = gameObject.GetComponent<Animation>() != null;
            return result;
        }

        public static bool HasAnimator(this GameObject gameObject)
        {
            var result = gameObject.GetComponent<Animator>() != null;
            return result;
        }

        #endregion

        #region Component

        public static bool TryGetComponent<T>(this GameObject gameObject, out T outComponent)
        { 
            outComponent = gameObject.GetComponent<T>();
            var result = outComponent != null;
            return result;
        }

        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T outComponent)
        {
            outComponent = gameObject.GetComponentInParent<T>();
            var result = outComponent != null;
            return result;
        }

        public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T outComponent)
        {
            outComponent = gameObject.GetComponentInChildren<T>();
            var result = outComponent != null;
            return result;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            var component = gameObject.GetComponent(type);
            if (component == null)
            {
                component = gameObject.AddComponent(type);
            }

            return component;
        }

        public static bool DestroyComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) return false;
            Object.DestroyImmediate(component);
            return true;
        }


        public static bool DestroyComponent(this GameObject gameObject, Type type) 
        {
            var component = gameObject.GetComponent(type);
            if (component == null) return false;
            Object.DestroyImmediate(component);
            return true;
        }

        public static T SearchComponent<T>(this GameObject gameObject, string searchName) where T : Component
        {
            var gos = gameObject.GetComponentsInChildren<T>(true);
            var length = gos.Length;
            for (var i = 0; i < length; i++)
            {
                var local = gos[i];
                if (searchName == local.name)
                {
                    return local;
                }
            }

            return null;
        }

        public static T FindComponentInParents<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component != null)
            {
                return component;
            }

            return gameObject.transform.parent != null ? FindComponentInParents<T>(gameObject.transform.parent.gameObject) : null;
        }

        public static Component FindComponentInParents(this GameObject gameObject, Type type)
        {
            var component = gameObject.GetComponent(type);
            if (component != null)
            {
                return component;
            }

            return gameObject.transform.parent != null ? FindComponentInParents(gameObject.transform.parent.gameObject, type) : null;
        }

        #endregion

        #region Path

        public static GameObject[] CreateChild(this GameObject gameObject, string pathName, char splitChar = '/')
        {
            GameObject obj2 = null;
            var list = new List<GameObject>();
            var separator = new char[] {splitChar};
            for (var i = 0; i < pathName.Split(separator).Length; i++)
            {
                var str = pathName.Split(separator)[i];
                var item = new GameObject(str);
                list.Add(item);
                if (obj2 != null)
                {
                    item.transform.SetParent(obj2.transform);
                }

                obj2 = item;
            }

            list[0].transform.SetParent(gameObject.transform);
            return list.ToArray();
        }

        public static string Path(this GameObject gameObject)
        {
            var path = "/" + gameObject.name;
            while (gameObject.transform.parent != null)
            {
                gameObject = gameObject.transform.parent.gameObject;
                path = "/" + gameObject.name + path;
            }

            return path;
        }

        public static GameObject Root(this GameObject go)
        {
            var current = go;
            GameObject result;
            do
            {
                var trans = current.transform.parent;
                if (trans != null)
                {
                    result = trans.gameObject;
                    current = trans.gameObject;
                }
                else
                {
                    result = current;
                    current = null;
                }
            } while (current != null);

            return result;
        }

        public static int Depth(this GameObject go)
        {
            var depth = 0;
            var current = go.transform;
            do
            {
                current = current.transform.parent;
                if (current != null)
                {
                    depth++;
                }
            } while (current != null);

            return depth;
        }

        #endregion

        #region Layer

        public static bool ContainLayer(this GameObject gameObject, int otherLayerIndex)
        {
            var value = 1 << gameObject.layer;
            var result = (value & otherLayerIndex) > 0;
            return result;
        }

        public static bool ContainLayer(this GameObject gameObject, LayerMask otherLayerMask)
        {
            var value = 1 << gameObject.layer;
            var result = (value & otherLayerMask.value) > 0;
            return result;
        }

        public static bool ContainLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)
        {
            foreach (var layerMask in otherLayerMasks)
            {
                var result = gameObject.ContainLayer(layerMask);
                if (!result) return false;
            }
            return true;
        }

        public static bool ContainOneOfLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)
        {
            foreach (var layerMask in otherLayerMasks)
            {
                var result = gameObject.ContainLayer(layerMask);
                if (result) return true;
            }
            return false;
        }

        public static void SetLayer(this GameObject gameObject, LayerMask layerMask)
        {
            gameObject.layer = layerMask.GetLayerIndex();
        }

        public static void SetLayerRecursion(this GameObject gameObject, LayerMask layerMask)
        {
            gameObject.layer = layerMask.GetLayerIndex();
            foreach (Transform child in gameObject.transform)
            {
                SetLayerRecursion(child.gameObject, layerMask);
            }
        }

        public static void SetLayerRecursion(this GameObject gameObject, int layerIndex)
        {
            gameObject.layer = layerIndex;
            foreach (Transform child in gameObject.transform)
            {
                SetLayerRecursion(child.gameObject, layerIndex);
            }
        }

        #endregion

        #region Tag

        public static void SetTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
        }

        public static void SetTagRecursion(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            foreach (Transform child in gameObject.transform)
            {
                SetTagRecursion(child.gameObject, tag);
            }
        }

        #endregion

        #region Particle

        public static float GetParticleDuration(this GameObject gameObject, bool includeChildren = true, bool includeInactive = false, bool allowLoop = false)
        {
            if (includeChildren)
            {
                var particles = gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive);
                var duration = -1f;
                for (var i = 0; i < particles.Length; i++)
                {
                    var ps = particles[i];
                    var time = ps.GetDuration(allowLoop);
                    if (time > duration)
                    {
                        duration = time;
                    }
                }

                return duration;
            }
            else
            {
                var ps = gameObject.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    return ps.GetDuration(allowLoop);
                }
                else
                {
                    return -1f;
                }
            }
        }

        #endregion

        #region Trail Renderer

        public static float GetTrailRendererTime(this GameObject gameObject)
        {
            var trailRendererArray = gameObject.GetComponentsInChildren<TrailRenderer>();
            var duration = 0f;
            for (var i = 0; i < trailRendererArray.Length; i++)
            {
                var trailRenderer = trailRendererArray[i];
                var time = trailRenderer.time;
                if (time > duration)
                {
                    duration = time;
                }
            }

            return duration;
        }

        #endregion

        #region Bounds

        public static Bounds GetBounds(this GameObject gameObject, bool includeChildren = true)
        {
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.GetBounds(includeChildren);
            }

            var meshFilter = gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                return meshFilter.GetBounds(includeChildren);
            }

            var bounds = new Bounds(gameObject.transform.position, Vector3.zero);
            return bounds;
        }

        #endregion
    }
}