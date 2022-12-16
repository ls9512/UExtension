using System;
using System.Collections;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static partial class IDictionaryExtension
    {
        internal static Random Rand = new Random();

        #region Null / Empty

        public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var result = dictionary == null || dictionary.Count == 0;
            return result;
        }

        public static bool IsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new NullReferenceException();
            }

            var result = dictionary.Count == 0;
            return result;
        }

        public static bool IsNullOrEmpty(this IDictionary dictionary)
        {
            var result = dictionary == null || dictionary.Count == 0;
            return result;
        }

        public static bool IsEmpty(this IDictionary dictionary)
        {
            if (dictionary == null)
            {
                throw new NullReferenceException();
            }

            var result = dictionary.Count == 0;
            return result;
        }

        #endregion

        #region Add T

        public static IDictionary<TKey, TValue> Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
        {
            dictionary.Add(pair.Key, pair.Value);
            return dictionary;
        }

        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
        {
            if (dictionary.ContainsKey(pair.Key)) return false;
            dictionary.Add(pair.Key, pair.Value);
            return true;
        }

        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key)) return false;
            dictionary.Add(key, value);
            return true;
        }

        public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
            return dictionary;
        }

        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> values,
            bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (!dictionary.ContainsKey(item.Key) || replaceExisted)
                {
                    dictionary[item.Key] = item.Value;
                }
            }

            return dictionary;
        }

        #endregion

        #region Add

        public static bool TryAdd(this IDictionary dictionary, object key, object value)
        {
            if (dictionary.Contains(key)) return false;
            dictionary.Add(key, value);
            return true;
        }

        public static IDictionary AddOrReplace(this IDictionary dictionary, object key, object value)
        {
            dictionary[key] = value;
            return dictionary;
        }

        public static IDictionary AddRange(this IDictionary dictionary, IDictionary values, bool replaceExisted)
        {
            foreach (var key in values.Keys)
            {
                var value = values[key];
                if (!dictionary.Contains(key) || replaceExisted)
                {
                    dictionary[key] = value;
                }
            }

            return dictionary;
        }

        #endregion

        #region Merge T

        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params IDictionary<TKey, TValue>[] dictionaries)
        {
            foreach (var dic in dictionaries)
            {
                dictionary.AddRange(dic, true);
            }

            return dictionary;
        }

        #endregion

        #region Get T

        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (key == null) return defaultValue;
            return dictionary.TryGetValue(key, out var ret) ? ret : defaultValue;
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary.TryGetValue(key, out var ret))
            {
                return ret;
            }

            dictionary.Add(key, defaultValue);
            return defaultValue;
        }

        public static TValue Random<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary.Count < 1) return default(TValue);
            int i = 0, index = Rand.Next(0, dictionary.Count);
            var result = default(TValue);
            foreach (var value in dictionary.Values)
            {
                if (i >= index)
                {
                    result = value;
                    break;
                }

                i++;
            }

            return result;
        }

        #endregion

        #region Get

        public static object GetValue(this IDictionary dictionary, object key, object defaultValue = default(object))
        {
            if (key == null) return defaultValue;
            var ret = dictionary[key];
            return ret;
        }

        public static object GetOrAdd(this IDictionary dictionary, object key, object defaultValue = default(object))
        {
            var ret = dictionary[key];
            if (ret != null)
            {
                return ret;
            }

            dictionary.Add(key, defaultValue);
            return defaultValue;
        }

        public static object Random(this IDictionary dictionary)
        {
            if (dictionary.Count < 1) return default(object);
            int i = 0, index = Rand.Next(0, dictionary.Count);
            var result = default(object);
            foreach (var value in dictionary.Values)
            {
                if (i >= index)
                {
                    result = value;
                    break;
                }

                i++;
            }

            return result;
        }

        #endregion

        #region Foreach T

        public static IDictionary<TKey, TValue> ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            if (action == null) return dictionary;
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];
                action(key, value);
            }

            return dictionary;
        }

        public static IDictionary<TKey, TValue> ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TKey, TValue, bool> selector,
            Action<TKey, TValue> action)
        {
            if (selector == null || action == null) return dictionary;
            foreach (var item in dictionary)
            {
                if (!selector(item.Key, item.Value)) continue;
                action(item.Key, item.Value);
            }

            return dictionary;
        }

        #endregion

        #region Foreach

        public static IDictionary ForEach(this IDictionary dictionary, Action<object> action)
        {
            if (action == null) return dictionary;
            foreach (var item in dictionary)
            {
                action(item);
            }

            return dictionary;
        }

        public static IDictionary ForEach(this IDictionary dictionary, Func<object, bool> selector, Action<object> action)
        {
            if (selector == null || action == null) return dictionary;
            foreach (var item in dictionary)
            {
                if (!selector(item)) continue;
                action(item);
            }

            return dictionary;
        }

        #endregion

        #region Find T

        public static KeyValuePair<TKey, TValue>? Find<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TKey, TValue, bool> selector)
        {
            if (selector == null) return null;
            foreach (var pair in dictionary)
            {
                if (selector(pair.Key, pair.Value))
                {
                    return pair;
                }
            }

            return null;
        }

        public static IDictionary<TKey, TValue> FindAll<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TKey, TValue, bool> selector)
        {
            if (selector == null) return null;
            var ret = new Dictionary<TKey, TValue>();
            foreach (var pair in dictionary)
            {
                if (selector(pair.Key, pair.Value))
                {
                    ret.Add(pair);
                }
            }

            return ret;
        }

        #endregion

        #region Find

        public static object Find(this IDictionary dictionary, Func<object, bool> selector)
        {
            if (selector == null) return null;
            foreach (var value in dictionary)
            {
                if (selector(value))
                {
                    return value;
                }
            }

            return null;
        }

        public static IDictionary FindAll(this IDictionary dictionary, Func<object, object, bool> selector)
        {
            if (selector == null) return null;
            var ret = new Hashtable();
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];
                if (selector(key, value))
                {
                    ret.Add(key, value);
                }
            }

            return ret;
        }

        #endregion

        #region Remove T

        public static bool RemoveValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
        {
            var match = false;
            var key = default(TKey);
            foreach (var kv in dictionary)
            {
                if (!kv.Value.Equals(value)) continue;
                key = kv.Key;
                match = true;
                break;
            }

            if (match)
            {
                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        #endregion

        #region Remove

        public static bool RemoveValue<TValue>(this IDictionary dictionary, TValue value)
        {
            var match = false;
            object key = null;
            foreach (var k in dictionary.Keys)
            {
                var v = dictionary[k];
                if (!v.Equals(value)) continue;
                key = k;
                match = true;
                break;
            }

            if (match)
            {
                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        #endregion
    }
}