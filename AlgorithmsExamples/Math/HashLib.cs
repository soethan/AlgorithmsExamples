using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public static class HashLib
    {
        private const int BUCKETS_SIZE = 8;

        public static int GetHashedValue(string s)
        {
            return (int)s[0] % BUCKETS_SIZE;
        }
    }
}
