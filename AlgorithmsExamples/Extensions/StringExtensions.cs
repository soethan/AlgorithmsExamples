using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples.Extensions
{
    public static class StringExtensions
    {
        public static string GetFirst3Letters(this string str)
        {
            if(str.Length > 3)
                return str.Substring(0, 3);
            return str;
        }
    }
}
