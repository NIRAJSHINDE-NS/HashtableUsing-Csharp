namespace Hashtable
{
    using System;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue>
    {
        private const int InitialCapacity = 16;
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        public HashTable()
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
        }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            var bucket = buckets[bucketIndex];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists in the hashtable.");
                }
            }

            bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            var bucket = buckets[bucketIndex];
            if (bucket != null)
            {
                foreach (var pair in bucket)
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            var bucket = buckets[bucketIndex];
            if (bucket != null)
            {
                foreach (var pair in bucket)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default(TValue);
            return false;
        }

        public bool Remove(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            var bucket = buckets[bucketIndex];
            if (bucket != null)
            {
                var node = bucket.First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        bucket.Remove(node);
                        return true;
                    }

                    node = node.Next;
                }
            }

            return false;
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode % buckets.Length;
            return Math.Abs(bucketIndex);
        }
    }

}