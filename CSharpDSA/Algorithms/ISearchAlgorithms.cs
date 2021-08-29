using System;
using System.Collections.Generic;

namespace CSharpDSA.Algorithms
{
    public interface ISearchAlgorithms
    {
        public int BinarySearch<T>(IList<T> items, T value) where T : IComparable<T>;
    }
}
