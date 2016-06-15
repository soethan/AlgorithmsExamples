using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class HeapSort : ISort
    {
        public void Sort(int[] numbers)
        {
            int heapSize = numbers.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(ref numbers, heapSize, p);

            for (int i = numbers.Length - 1; i > 0; --i)
            {
                int temp = numbers[i];
                numbers[i] = numbers[0];
                numbers[0] = temp;

                --heapSize;
                MaxHeapify(ref numbers, heapSize, 0);
            }
        }

        private void MaxHeapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(ref data, heapSize, largest);
            }
        }
    }
}
