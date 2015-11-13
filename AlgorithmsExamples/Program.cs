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
            #region QuickSort

            Console.Write("\n************ QuickSort ************");
            Console.Write("\n\nEnter number of elements: ");

            int totalElements = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[totalElements];

            for (int i = 0; i < totalElements; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Input int array  : ");
            Console.Write("\n");

            for (int k = 0; k < totalElements; k++)
            {
                Console.Write(numbers[k] + " ");
                Console.Write("\n");
            }

            Console.WriteLine("QuickSort By Recursive Method");

            var quickSort = new QuickSort();
            quickSort.Sort(numbers, 0, totalElements - 1);

            for (int i = 0; i < totalElements; i++)
                Console.WriteLine(numbers[i]);

            #endregion
            
            Console.ReadLine();
        }
    }
}
