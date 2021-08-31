using System;
using System.Collections.Generic;

namespace CSharpDSA.Algorithms
{
    /// <summary>
    /// Declares 
    /// </summary>
    public interface ISearchAlgorithms
    {
        /// <summary>
        /// Searches a value on a sorted list using a binary search algorithm.
        /// </summary>
        /// <param name="items">A sorted list of items</param>
        /// <param name="value">The value to search for.</param>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        public int BinarySearch<T>(IList<T> items, T value) where T : IComparable<T>;

        /// <summary>
        /// Searches the path between a start point and a end point point using BFS algorithm.
        /// </summary>
        /// <param name="items">An adjacency list</param>
        /// <param name="start">The start node</param>
        /// <param name="end">The end node</param>
        /// <typeparam name="T">The type of elements in the adjacency list</typeparam>
        public IEnumerable<T> BreadthFirstSearch<T>(IDictionary<T, IList<T>> items, T start, T end)
            where T : IComparable<T>;
    }
}
