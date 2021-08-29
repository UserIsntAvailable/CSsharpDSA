using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharpDSA.Algorithms;

namespace CSharpDSA.DataStructures
{
    public class Graph<T> : IGraph<T> where T : IComparable<T>
    {
        private readonly Dictionary<T, List<T>> _items;

        public Graph()
        {
            _items = new Dictionary<T, List<T>>();
        }

        public void Add(T item, T value)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if(!_items.ContainsKey(item))
            {
                this.Add(item);
            }

            if(!_items.ContainsKey(value))
            {
                throw new KeyNotFoundException(
                    "You can't add a value to a node when that value is yet added as a node"
                );
            }

            var nodeList = _items[item];

            var index = SearchAlgorithms.Instance.BinarySearch(nodeList, value);

            nodeList.Insert(index, value);
        }

        public void Traverse(T from, T to, Action<T> action)
        {
            throw new NotImplementedException();
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items[item] = new List<T>();
        }

        public void Clear() => _items.Clear();

        public bool Contains(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return _items.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(
            _items.Keys.ToArray(),
            0,
            array,
            arrayIndex,
            this.Count
        );

        public bool Remove(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator() => _items.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
