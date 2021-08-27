using System;
using System.Collections.Generic;

namespace AutoGUI
{
    public interface IGraph<T> : ICollection<T>
    {
        public void Add(T item, T value);
        
        public void Traverse(T from, T to, Action<T> action);
    }
}
