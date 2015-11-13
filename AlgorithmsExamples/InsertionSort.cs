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
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                        j--;
                    }
                    else
                        break;
                }
            }
        }
    }
}
