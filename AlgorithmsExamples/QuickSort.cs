using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class QuickSort : ISort
    {
        //6  5  9  12  3
        //3  5  9  12  6
        //3  5  6  12  9 (pivot index is 2)
        //values on the left are always less than pivot value while values on the right are always greater than pivot value.

        public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public void Sort(int[] arr, int left, int right)
        {
            // For Recursion  
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);

                if (pivotIndex > 1)
                    Sort(arr, left, pivotIndex - 1);

                if (pivotIndex + 1 < right)
                    Sort(arr, pivotIndex + 1, right);
            }
        }

        public void Sort(int[] numbers)
        {
            Sort(numbers, 0, numbers.Length - 1);
        }
    }
}