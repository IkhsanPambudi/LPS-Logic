using System;
using System.Collections.Generic;

class Cache
{
    private static readonly int MaxSize = 1000;
    private static Dictionary<int, CacheItem> _cache = new Dictionary<int, CacheItem>();
    private static LinkedList<int> _lruOrder = new LinkedList<int>();
    private static TimeSpan _defaultTTL = TimeSpan.FromMinutes(5);
    public static void Add(int key, object value)
    {
        if (_cache.Count >= MaxSize)
        {
            RemoveLRU();
        }

        _cache[key] = new CacheItem(value, DateTime.UtcNow.Add(_defaultTTL));
        _lruOrder.AddLast(key);
    }

    public static object Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            var item = _cache[key];
            if (DateTime.UtcNow > item.ExpirationTime)
            {
                _cache.Remove(key);
                _lruOrder.Remove(key);
                return null;
            }

            _lruOrder.Remove(key);
            _lruOrder.AddLast(key);
            return item.Value;
        }

        return null;
    }

    private static void RemoveLRU()
    {
        if (_lruOrder.Count > 0)
        {
            int oldestKey = _lruOrder.First.Value;
            _lruOrder.RemoveFirst();
            _cache.Remove(oldestKey);
        }
    }

    private class CacheItem
    {
        public object Value { get; }
        public DateTime ExpirationTime { get; }

        public CacheItem(object value, DateTime expirationTime)
        {
            Value = value;
            ExpirationTime = expirationTime;
        }
    }
}

class Program
{
    static void Main(string[] args)
    { 
        for (int i = 0; i < 1000; i++)
        {
            Cache.Add(i, new object());
        }

        Console.WriteLine("Cache populated with TTL (Time to Live).");
        Console.ReadLine();
    }
}
alasan :
- pembatasan cache dan LRU untuk menghindari pemborosan memori 
dan memastikan hanya objek yang sering digunakan yang ada didalam cache