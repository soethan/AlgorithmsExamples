using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsExamples
{
    public class BinarySearch : ISearch
    {
        public int Search(int[] sortedNumbers, int searchNumber)
        {
            int returnIndex = -1;
            int lowerIndex = 0;
            int upperIndex = sortedNumbers.Length - 1;

            while (true)
            {
                if (upperIndex < lowerIndex)
                {
                    break;
                }

                int midIndex = lowerIndex + (upperIndex - lowerIndex) / 2;

                if (searchNumber > sortedNumbers[midIndex])
                {
                    lowerIndex = midIndex + 1;
                }

                if (searchNumber < sortedNumbers[midIndex])
                {
                    upperIndex = midIndex - 1;
                }

                if (searchNumber == sortedNumbers[midIndex])
                {
                    returnIndex = midIndex;
                    break;
                }
            }

            return returnIndex;
        }
    }
}
