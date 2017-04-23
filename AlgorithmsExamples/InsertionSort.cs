using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /*
    https://www.tutorialspoint.com/data_structures_algorithms/insertion_sort_algorithm.htm
    Step 1 − If it is the first element, it is already sorted. return 1;
    Step 2 − Pick next element
    Step 3 − Compare with all elements in the sorted sub-list
    Step 4 − Shift all the elements in the sorted sub-list that is greater than the 
             value to be sorted
    Step 5 − Insert the value
    Step 6 − Repeat until list is sorted 
    */
    /// <summary>
    /// Worst Case: O(n^2)
    /// Best Case: O(n)
    /// Space Requirement: O(n)
    /// </summary>
    public class InsertionSort : ISort
    {
        public void Sort(int[] numbers)
        {
            //4  3  2  1
            //3  4  2  1
            //3  3  4  1
            //2  3  4  1
            //2  3  4  4  
            //2  3  3  4
            //2  2  3  4
            //1  2  3  4
            int holePosition;
            int valueToInsert;

            if(numbers.Length > 1)
            {
                for(int i = 1; i < numbers.Length; i++)
                {
                    /* select value to be inserted */
                    valueToInsert = numbers[i];
                    holePosition = i;
      
                    /*locate hole position for the element to be inserted */
		
                    while(holePosition > 0 && numbers[holePosition-1] > valueToInsert)
                    {
                        numbers[holePosition] = numbers[holePosition - 1];
                        holePosition = holePosition -1;
                    }
                       
                    /* insert the number at hole position */
                    numbers[holePosition] = valueToInsert;

                }
            }
        }
    }
}
