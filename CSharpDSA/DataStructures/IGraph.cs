using System;
using System.Collections.Generic;

namespace CSharpDSA.DataStructures
{
    public interface IGraph<T> : ICollection<T>
    {
        public IList<T> this[T item] { get; }

        public void Add(T item, T value);

        public void Traverse(T from, T to, Action<T> action);
    }
}
