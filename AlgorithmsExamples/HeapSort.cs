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
            //creates a heap
            BuildHeap(numbers);

            //sorts a heap
            //takes the largest element @ first position and moves to end
            //reuses the same heapify function, but in reverse, to sort the array
            int size = numbers.Length;
            for (int counter = size - 1; counter > 0; counter--)
            {
                Swap(numbers, 0, counter);
                HeapifyRecursive(numbers, 0, counter);
            }
        }

        //a heap, in this case, is a binary tree
        //the largest element is in the first position
        //the next two positions are the 2 subelements of this node, and so on
        //it looks at each element, then reporders them so it maintains the heap structure
        public int[] BuildHeap(int[] arrayToSort)
        {
            int size = arrayToSort.Length;
            int start = (arrayToSort.Length / 2) - 1;

            for (int counter = start; counter >= 0; counter--)
            {
                HeapifyRecursive(arrayToSort, counter, size);
            }
            return arrayToSort;
        }

        public void HeapifyRecursive(int[] arrayToSort, int idx, int max)
        {
            int left = 2 * idx + 1;
            int right = 2 * idx + 2;
            int largest;
            if (left < max && arrayToSort[left] > arrayToSort[idx])
            {
                largest = left;
            }
            else
            {
                largest = idx;
            }

            if (right < max && arrayToSort[right] > arrayToSort[largest])
            {
                largest = right;
            }

            if (largest != idx)
            {
                Swap(arrayToSort, idx, largest);
                HeapifyRecursive(arrayToSort, largest, max - 1);
            }
        }

        private int[] Swap(int[] arrayToUse, int itemOneIndex, int itemTwoIndex)
        {
            int tempValueHolder = arrayToUse[itemOneIndex];
            arrayToUse[itemOneIndex] = arrayToUse[itemTwoIndex];
            arrayToUse[itemTwoIndex] = tempValueHolder;
            return arrayToUse;
        }
    }
}
