using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsExamples
{
    /// <summary>
    /// Precondition: array is sorted
    /// </summary>
    public class BinarySearch : ISearch
    {
        public int Search(int[] sortedNumbers, int searchNumber)
        {
            int foundAt = -1;
            int lower = 0;
            int upper = sortedNumbers.Length - 1;

            while (true)
            {
                if (upper < lower)
                {
                    break;
                }

                int mid = lower + (upper - lower) / 2;

                if (searchNumber > sortedNumbers[mid])
                {
                    lower = mid + 1;
                }

                if (searchNumber < sortedNumbers[mid])
                {
                    upper = mid - 1;
                }

                if (searchNumber == sortedNumbers[mid])
                {
                    foundAt = mid;
                    break;
                }
            }

            return foundAt;
        }
    }
}
