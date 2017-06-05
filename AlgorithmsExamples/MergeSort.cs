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
    /// Worst Case  : O(n log n)
    /// 
    /// Space Complexity
    /// ======================
    /// Worst Case  : O(n)
    /// </summary>
    public class MergeSort : ISort
    {
        private int[] temp;
         
        public void Merge(int[] array, int left, int mid, int right)
        {
            int tempArrayIndex = left;
            int i = left;
            int j = mid;

            while (i < mid && j <= right)
            {
                if (array[i] <= array[j])
                {
                    temp[tempArrayIndex++] = array[i++];
                }
                else
                {
                    temp[tempArrayIndex++] = array[j++];
                }
            }

            while (i < mid)
            {
                temp[tempArrayIndex++] = array[i++];
            }

            while (j <= right)
            {
                temp[tempArrayIndex++] = array[j++];
            }

            for (int k = left; k <= right; k++)
            {
                array[k] = temp[k];
            }   
        }

        public void Sort(int[] numbers, int left, int right)
        {
            if (right > left)
            {
                int mid = (right + left) / 2;
                Sort(numbers, left, mid);
                Sort(numbers, mid + 1, right);
                Merge(numbers, left, mid + 1, right);
            }
        }

        public void Sort(int[] numbers)
        {
            temp = numbers.Length > 0 ? new int[numbers.Length] : null;
            Sort(numbers, 0, numbers.Length - 1);
        }
    }
}
