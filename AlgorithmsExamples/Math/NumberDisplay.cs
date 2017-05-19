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
            StringBuilder sb = new StringBuilder();
            var dict = new Dictionary<int, string>();
            dict[0] = "";
            dict[1] = "Thousand";
            dict[2] = "Million";
            dict[3] = "Billion";
            dict[4] = "Trillion";

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

            for (int j = numList.Count - 1; j >= 0; j--)
            {
                int num = int.Parse(numList[j]);
                int quotient = num / 100;
                int remainder = num % 100;

                if (quotient > 0)
                {
                    sb.Append(GetDigitString(quotient) + "Hundred");
                    
                }

                if (remainder > 20)
                {
                    int q = remainder / 10;
                    int r = remainder % 10;
                    sb.Append(Get2DigitString(q));
                    sb.Append(GetDigitString(r));
                }
                else
                {
                    if (remainder > 9 && remainder < 20)
                    {
                        sb.Append(GetSpecialString(remainder));
                    }
                    else
                    {
                        sb.Append(GetDigitString(remainder));
                    }

                }

                if(quotient != 0 || remainder != 0)
                    sb.Append(dict[j]);
            }

            return sb.ToString();
        }

        private static string GetDigitString(int num)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(0, "");
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            dict.Add(6, "Six");
            dict.Add(7, "Seven");
            dict.Add(8, "Eight");
            dict.Add(9, "Nine");
            return dict[num];
        }

        private static string Get2DigitString(int num)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(0, "");
            dict.Add(1, "Ten");
            dict.Add(2, "Twenty");
            dict.Add(3, "Thirty");
            dict.Add(4, "Fourty");
            dict.Add(5, "Fifty");
            dict.Add(6, "Sixty");
            dict.Add(7, "Seventy");
            dict.Add(8, "Eighty");
            dict.Add(9, "Ninety");
            return dict[num];
        }

        private static string GetSpecialString(int num)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(10, "Ten");
            dict.Add(11, "Eleven");
            dict.Add(12, "Twelve");
            dict.Add(13, "Thirteen");
            dict.Add(14, "Fourteen");
            dict.Add(15, "Fifteen");
            dict.Add(16, "Sixteen");
            dict.Add(17, "Seventeen");
            dict.Add(18, "Eighteen");
            dict.Add(19, "Nineteen");
            return dict[num];
        }
    }
}
