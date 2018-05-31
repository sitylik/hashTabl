using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public class HashTable
        {
            static void Main(string[] args)
            {
            }
            class Pair
            {
                public object Key { get; set; }
                public object Value { get; set; }
            }
            List<List<Pair>> list;
            public HashTable(int size)
            {
                list = new List<List<Pair>>();
                for (int i = 0; i < size; i++)
                {
                    list.Add(new List<Pair>());
                }
            }
            public void PutPair(object key, object value)
            {
                var bucketNumber = GetBucketNumber(key);
                foreach (var el in list[bucketNumber])
                {
                    if (Equals(el.Key, key))
                    {
                        el.Value = value;
                        return;
                    }
                }
                list[bucketNumber].Add(new Pair { Key = key, Value = value });
            }
            public object GetValueByKey(object key)
            {
                var bucketNumber = GetBucketNumber(key);
                foreach (var el in list[bucketNumber])
                {
                    if (Equals(el.Key, key))
                    {
                        return el.Value;
                    }
                }
                return null;
            }
            int GetBucketNumber(object key)
            {
                return Math.Abs(key.GetHashCode()) % list.Count;
            }
        }
    }
}
