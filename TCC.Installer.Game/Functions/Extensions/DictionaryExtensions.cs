﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Functions.Extensions
{
    /// <summary>Provides extensions for dictionaries.</summary>
    public static class DictionaryExtensions
    {
        /// <summary>Clones the dictionary and returns a shallow copy of it.</summary>
        /// <param name="d">The dictionary to clone.</param>
        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> d)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var kvp in d)
                result.Add(kvp.Key, kvp.Value);
            return result;
        }
        /// <summary>Gets the value of a specified key in the dictionary if it exists, otherwise the default value of the value type.</summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="d">The dictionary whose value to get at the specified key.</param>
        /// <param name="key">The key to get the value of, if it exists in the dictionary.</param>
        public static TValue ValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> d, TKey key) => d.ContainsKey(key) ? d[key] : default;
        /// <summary>Sets the value of a key if it exists, otherwise creates a new key with the specified value.</summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="d">The dictionary whose value to set for the specified key.</param>
        /// <param name="key">The key in the dictionary whose value to set.</param>
        /// <param name="value">The value to set to the specified key in the dictionary.</param>
        public static void SetOrAddKeyValue<TKey, TValue>(this Dictionary<TKey, TValue> d, TKey key, TValue value)
        {
            if (d.ContainsKey(key))
                d[key] = value;
            else
                d.Add(key, value);
        }
        /// <summary>Increments the value of a key if it exists, otherwise creates a new key with the default value 1.</summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <param name="d">The dictionary whose value to increment for the specified key.</param>
        /// <param name="key">The key in the dictionary whose value to increment.</param>
        public static void IncrementOrAddKeyValue<TKey>(this Dictionary<TKey, int> d, TKey key)
        {
            if (d.ContainsKey(key))
                d[key]++;
            else
                d.Add(key, 1);
        }
        /// <summary>Calculates the sum of all the values in the dictionary, excluding specific keys.</summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <param name="d">The dictionary whose value sum to calculate.</param>
        /// <param name="exclusions">The keys that will be excluded from the sum.</param>
        public static int Sum<TKey>(this Dictionary<TKey, int> d, params TKey[] exclusions)
        {
            int sum = 0;
            foreach (var v in d.Values)
                sum += v;
            foreach (var e in exclusions)
                if (d.ContainsKey(e))
                    sum -= d[e];
            return sum;
        }
    }
}
