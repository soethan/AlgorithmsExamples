using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class InsertionSort : ISort
    {
        public void Sort(int[] numbers)
        {
            //4  3  2  1
            //3  4  2  1
            //3  3  4  1
            //2  3  4  1
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
