using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public static class SortAlgorithmFactory
    {
        public static ISort GetSortingAlgorithm(AlgorithmType algorithmType)
        {
            switch (algorithmType)
            {
                case AlgorithmType.QuickSort:
                    return new QuickSort();
                case AlgorithmType.MergeSort:
                default:
                    return new MergeSort();
            }
        }
    }
}
