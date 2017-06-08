using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// Time Complexity
    /// ======================
    /// Best Case   : O(n log n)
    /// Average Case: O(n log n)
    /// Worst Case  : O(n ^ 2)
    /// 
    /// Space Complexity
    /// ======================
    /// Worst Case  : O(log n)
    /// at each recursive call a new stack frame of constant size must be allocated. Hence the O(log(n)) space complexity.
    /// </summary>
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
            if (right <= left)
            {
                return;
            }
            else
            {
                int pivotIndex = Partition(arr, left, right);
                Sort(arr, left, pivotIndex - 1);
                Sort(arr, pivotIndex + 1, right);
            }
        }

        public void Sort(int[] numbers)
        {
            Sort(numbers, 0, numbers.Length - 1);
        }
    }
}