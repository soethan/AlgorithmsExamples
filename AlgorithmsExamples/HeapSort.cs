using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// https://www.youtube.com/watch?v=MtQL_ll5KhQ
    /// </summary>
    public class HeapSort : ISort
    {
        public void Sort(int[] numbers)
        {
            BuildHeap(numbers);

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                //Max value is at the root(index=0)
                SwapValues(numbers, 0, i);
                //The next Heapify will only need arrayLength - 1
                Heapify(numbers, i, 0);
            }
        }

        private void BuildHeap(int[] numbers)
        {
            int size = numbers.Length;

            for (int i = size / 2; i >= 0; i--)
            {
                Heapify(numbers, size, i);
            }
        }

        private void Heapify(int[] numbers, int size, int index)
        {
            int value = numbers[index];

            while (index < size)
            {
                int childPos = index * 2 + 1;

                if (childPos < size)
                {
                    if (childPos + 1 < size && numbers[childPos + 1] > numbers[childPos])
                    {
                        childPos++;
                    }

                    if (value > numbers[childPos])
                    {
                        numbers[index] = value;
                        return;
                    }
                    else
                    {
                        numbers[index] = numbers[childPos];
                        index = childPos;
                    }
                }
                else
                {
                    numbers[index] = value;
                    return;
                }
            }
        }

        private void SwapValues(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
