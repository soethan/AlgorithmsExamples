using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public static class NumberDisplay
    {
        //9 876 543 210
        //1,123,456,789
        //1,234
        public static string GetNumberText(string strNumber)
        {
            var dict = new Dictionary<int, string>();
            dict[0] = "";
            dict[1] = "thousand";
            dict[2] = "million";
            dict[3] = "billion";

            var numList = new List<string>();

            int counter = 0;
            int i = strNumber.Length - 1;
            string temp = string.Empty;

            while (i >= 0)
            { 
                
                temp = strNumber[i] + temp;
                counter++;
                if (counter % 3 == 0)
                {
                    numList.Add(temp);
                    counter = 0;//reset
                    temp = "";
                }
                else
                {
                    if (i == 0)
                    {
                        numList.Add(temp);    
                    }
                }
                i--;
            }

            return "";
        }
    }
}
