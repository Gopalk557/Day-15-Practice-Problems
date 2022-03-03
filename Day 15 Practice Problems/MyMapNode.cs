using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15_Practice_Problems
{
    public class MyMapNode<K, V>
    {
        private int size;
        private LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V GetElement(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> items in linkedList)
            {
                if (items.Key.Equals(key))
                {
                    return items.Value;
                }

            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> items = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(items);
        }


        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemsFound = false;
            KeyValue<K, V> foundItems = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> items in linkedList)
            {
                if (items.Key.Equals(key))
                {
                    itemsFound = true;
                    foundItems = items;
                }
            }
            if (itemsFound)
            {
                linkedList.Remove(foundItems);
            }

        }

        public struct KeyValue<k, v>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }

    }
}
