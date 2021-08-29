using System;
using System.Collections.Generic;

namespace CSharpDSA.Algorithms
{
    public class SearchAlgorithms : ISearchAlgorithms
    {
        private SearchAlgorithms()
        {
        }

        public static ISearchAlgorithms Instance { get; } = new SearchAlgorithms();

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
    }
}
