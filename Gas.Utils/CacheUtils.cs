using System;
using System.Collections.Generic;

public class CacheUtils<T>
{
    private readonly Dictionary<string, T> _cache;

    public CacheUtils()
    {
        _cache = new Dictionary<string, T>();
    }

    public void Add(string key, T value)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache.Add(key, value);
            Console.WriteLine($"Added item with key '{key}' to cache.");
        }
        else
        {
            Console.WriteLine($"Item with key '{key}' already exists in cache. Use Update method to update the existing item.");
        }
    }

    public bool TryGet(string key, out T value)
    {
        if (_cache.TryGetValue(key, out T cachedValue))
        {
            value = cachedValue;
            Console.WriteLine($"Retrieved item with key '{key}' from cache.");
            return true;
        }
        else
        {
            value = default(T);
            Console.WriteLine($"Item with key '{key}' not found in cache.");
            return false;
        }
    }

    public void Update(string key, T value)
    {
        if (_cache.ContainsKey(key))
        {
            _cache[key] = value;
            Console.WriteLine($"Updated item with key '{key}' in cache.");
        }
        else
        {
            Console.WriteLine($"Item with key '{key}' does not exist in cache. Use Add method to add a new item.");
        }
    }

    public void Remove(string key)
    {
        if (_cache.ContainsKey(key))
        {
            _cache.Remove(key);
            Console.WriteLine($"Removed item with key '{key}' from cache.");
        }
        else
        {
            Console.WriteLine($"Item with key '{key}' does not exist in cache.");
        }
    }
}
