using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class MergeSortWithLinkedList : ISort
    {

        private Node MergeList(Node a, Node b)
        {
            Node result = null;
            if (a == null)
                return b;
            if (b == null)
                return a;
            if (a.Data > b.Data)
            {
                result = b;
                result.Next = MergeList(a, b.Next);
            }
            else
            {
                result = a;
                result.Next = MergeList(a.Next, b);
            }
            return result;
        }

        private int GetLength(Node a)
        {
            int count = 0;
            Node h = a;
            while (h != null)
            {
                count++;
                h = h.Next;
            }
            return count;
        }

        private Node MergeSort(Node a)
        {
            Node oldHead = a;
            // find the length of the linkedlist
            int mid = GetLength(a) / 2;
            if (a.Next == null)
                return a;
            // set one pointer to the beginning of the list and another at the next
            // element after mid
            while (mid - 1 > 0)
            {
                oldHead = oldHead.Next;
                mid--;
            }
            Node newHead = oldHead.Next;// make newHead points to the beginning of
            // the second half of the list
            oldHead.Next = null;// break the list
            oldHead = a;// make one pointer points at the beginning of the first
            // half of the list
            Node t1 = MergeSort(oldHead);//make recursive calls 
            Node t2 = MergeSort(newHead);
            return MergeList(t1, t2); // merge the sorted lists
        }

        public void Sort(int[] numbers)
        {
            if(numbers.Length > 1) 
            {
                Node head = new Node(numbers[0]);
                Node tempNode = head;

                //Assign array to LinkedList
                for (int i = 1; i < numbers.Length; i++)
                {
                    var newNode = new Node(numbers[i]);
                    tempNode.Next = newNode;
                    tempNode = tempNode.Next;
                }
                Console.WriteLine("Before sorting:");
                DisplayNodes(head);
                Console.WriteLine();

                var sortedHead = MergeSort(head);

                Console.WriteLine("After sorting:");
                DisplayNodes(sortedHead);
                Console.WriteLine();

                //Assign LinkedList to array
                Node currentNode = sortedHead;
                int j = 0;
                while (currentNode != null)
                {
                    numbers[j++] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
            }

            
        }

        public void DisplayNodes(Node head)
        { 
            Node currentNode = head;
		    while (currentNode != null) {
			    Console.Write("->" + currentNode.Data);
			    currentNode = currentNode.Next;
		    }
        }
    }

    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
