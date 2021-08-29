using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpDSA.DataStructures
{
    public class Graph<T> : IGraph<T>
    {
        private readonly Dictionary<T, List<T>> _items;

        public Graph()
        {
            _items = new Dictionary<T, List<T>>();
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

        #region NotImplemented
        public void Add(T item, T value)
        {
            throw new NotImplementedException();
        }

        public void Traverse(T from, T to, Action<T> action)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
