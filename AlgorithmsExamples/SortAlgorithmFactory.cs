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
                    return new MergeSort();
                case AlgorithmType.InsertionSort:
                    return new InsertionSort();
                case AlgorithmType.BubbleSort:
                    return new BubbleSort();
                case AlgorithmType.HeapSort:
                    return new HeapSort();
                default:
                    throw new Exception("Invalid AlgorithmType");
            }
        }
    }
}
