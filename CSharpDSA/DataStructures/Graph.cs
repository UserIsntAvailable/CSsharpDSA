using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpDSA.DataStructures
{
    public class Graph<T> : IGraph<T>
    {
        private Dictionary<T, List<T>> _items;

        public Graph()
        {
            _items = new Dictionary<T, List<T>>();
        }
        
        #region NotImplementated
        public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item) => throw new NotImplementedException();

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item) => throw new NotImplementedException();

        public int Count { get; }

        public bool IsReadOnly { get; }

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
