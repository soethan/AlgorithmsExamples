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
         
        private void Merge(int[] numbers, int left, int mid, int right)
        {
            int tempIndex = left;
            int i = left;
            int j = mid;

            while (i < mid && j <= right)
            {
                if (numbers[i] <= numbers[j])
                {
                    temp[tempIndex++] = numbers[i++];
                }
                else
                {
                    temp[tempIndex++] = numbers[j++];
                }
            }

            while (i < mid)
            {
                temp[tempIndex++] = numbers[i++];
            }

            while (j <= right)
            {
                temp[tempIndex++] = numbers[j++];
            }

            for (int k = left; k <= right; k++)
            {
                numbers[k] = temp[k];
            }   
        }

        private void Sort(int[] numbers, int left, int right)
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
