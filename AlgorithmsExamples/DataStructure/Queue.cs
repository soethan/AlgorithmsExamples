using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class Queue
    {
        private int _front = 0;
        private int _rear = 0;
        private int occupancyCount = 0;
        private const int MAX_SIZE = 5;
        private string[] _queue = new string[MAX_SIZE];

        public void Enqueue(string item)
        {
            if (occupancyCount == MAX_SIZE)
                throw new Exception("Queue is full");
            _queue[_rear] = item;
            occupancyCount++;
            if (_rear == MAX_SIZE - 1)
                _rear = 0;
            else
                _rear++;
        }

        public void Dequeue()
        {
            if(occupancyCount == 0)
                throw new Exception("Queue is empty");

            _queue[_front] = null;
            occupancyCount--;

            if (_front == MAX_SIZE - 1)
                _front = 0;
            else
                _front++;
        }

        public void Display()
        {
            Console.WriteLine("*** Print Queue Begins ***");
            int f = _front;
            int r = _rear;

            for(int i = 0; i < occupancyCount; i++)
            {
                Console.WriteLine(_queue[f]);
                if (f == MAX_SIZE - 1)
                    f = 0;
                else
                    f++;
            }
            Console.WriteLine("*** Print Queue Ends ***");
        }
    }
}
