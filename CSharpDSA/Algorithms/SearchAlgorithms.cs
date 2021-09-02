using System;
using System.Collections.Generic;

namespace CSharpDSA.Algorithms
{
    public class SearchAlgorithms : ISearchAlgorithms
    {
        private SearchAlgorithms()
        {
        }

        public static SearchAlgorithms Instance { get; } = new SearchAlgorithms();

        /// <summary>
        /// Searches a value on a sorted list using a binary search algorithm. 
        /// </summary>
        /// <param name="items">A sorted list of items</param>
        /// <param name="value">The value to search for.</param>
        /// <typeparam name="T">The type of elements in the list</typeparam>
        /// <returns>
        /// If it is a positive <see cref="int"/>, it returns the index of the first instance of the value.
        /// Else, it returns a negative value that if it is negated (~), shows the position where to insert the value to keep the list sorted. 
        /// </returns>
        public int BinarySearch<T>(IList<T> items, T value) where T : IComparable<T>
        {
            var lIndex = 0;
            var rIndex = items.Count - 1;

            while(lIndex <= rIndex)
            {
                var median = (lIndex + rIndex) / 2;
                var comparison = value.CompareTo(items[median]);

                if(comparison == 0) return median;

                if(comparison > 0)
                {
                    lIndex = median + 1;
                }
                else
                {
                    rIndex = median - 1;
                }
            }

            return~lIndex;
        }

        /// <summary>
        /// Searches the path between a start point and a end point point using BFS algorithm.
        /// </summary>
        /// <param name="items">An adjacency list</param>
        /// <param name="start">The start node</param>
        /// <param name="end">The end node</param>
        /// <typeparam name="T">The type of elements in the adjacency list</typeparam>
        /// <returns>
        /// If the path was found, it returns a <see cref="IEnumerable{T}"/> with each node ( not including start ) that connects start and end.
        /// Else, it returns an empty <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<T> BreadthFirstSearch<T>(IDictionary<T, IList<T>> items, T start, T end)
            where T : IComparable<T>
        {
            Dictionary<T, T> trace = new() {{start, default(T)!},};
            List<T> trackedNodes = new() {start,};

            for(var i = 0; i <= trackedNodes.Count - 1; i++)
            {
                var current = trackedNodes[i];

                var edges = items[current];

                foreach(var edge in edges)
                {
                    if(trackedNodes.Contains(edge)) continue;

                    trackedNodes.Add(edge);
                    trace.Add(edge, current);

                    if(edge.CompareTo(end) == 0) goto END_NODE_FOUND;
                }
            }

            // If node 'end' wasn't connected to 'start'
            return Array.Empty<T>();

            END_NODE_FOUND:
            List<T> path = new() {end,};

            var parent = end;

            while(true)
            {
                parent = trace[parent];

                if(parent.CompareTo(start) == 0) break;
                path.Add(parent);
            }

            path.Reverse();

            return path;
        }
    }
}
