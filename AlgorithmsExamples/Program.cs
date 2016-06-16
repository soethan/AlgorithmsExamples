using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sorting

            Console.Write("\n************ Sorting ************");
            Console.Write("\n\nEnter number of elements: ");

            int totalElements = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[totalElements];

            for (int i = 0; i < totalElements; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Before Sorting: ");
            Console.Write("\n");

            for (int k = 0; k < totalElements; k++)
            {
                Console.Write(numbers[k] + " ");
                Console.Write("\n");
            }

            Console.WriteLine("After Sorting:");

            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.QuickSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.BubbleSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.InsertionSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.MergeSort);
            var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.HeapSort);
            sortAlgorithm.Sort(numbers);

            for (int i = 0; i < totalElements; i++)
                Console.WriteLine(numbers[i]);

            #endregion

            #region Graph

            var graph = new EdgeWeightedDirectedGraph(5);
            graph.AddEdge(new DirectedEdge(0, 1, 10));
            graph.AddEdge(new DirectedEdge(0, 3, 15));
            graph.AddEdge(new DirectedEdge(1, 2, 5));
            graph.AddEdge(new DirectedEdge(1, 4, 25));

            var allEdges = graph.GetAllEdges();
            foreach (var edge in allEdges)
            {
                Console.WriteLine(edge.ToString());
            }

            #endregion

            Console.ReadLine();
        }
    }
}
