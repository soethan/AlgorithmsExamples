using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public class Stack
    {
        private int _top = -1;
        private const int MAX_SIZE = 5;
        private string[] _stack = new string[MAX_SIZE];

        public void Push(string item)
        {
            if (_top + 1 < MAX_SIZE)
            {
                _stack[++_top] = item;
            }
            else
            {
                throw new Exception("Stack Overflowed...");
            }
        }

        public void Pop()
        {
            if(_top < 0)
                throw new Exception("Stack is empty...");
            _stack[_top--] = null;
        }

        public void Display()
        {
            Console.WriteLine("*** Print Stack Begins ***");
            int t = _top;
            while (t >= 0)
            {
                Console.WriteLine(_stack[t--]);
            }
            Console.WriteLine("*** Print Stack Ends ***");
        }
    }
}
