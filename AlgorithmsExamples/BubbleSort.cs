using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// On Each Pass
    ///     Compare each array item to it’s right neighbor
    ///     If the right neighbor is smaller then Swap right and left
    ///     Repeat for the remaining array items
    /// Perform subsequent passes until no swaps are performed
    /// Worst Case: O(n^2)
    /// Best Case: O(n)
    /// Space Requirement: O(n)
    /// </summary>
    public class BubbleSort: ISort
    {
        // 5  4  3  2  1
        public void Sort(int[] numbers)
        {
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < numbers.Length; i++)
                {
                    //left > right ==> swap
                    if (numbers[i - 1] > numbers[i])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i - 1];
                        numbers[i - 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped != false);
        }
    }
}
