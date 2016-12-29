using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day16
    {
        public static void Exercise1()
        {
            string input = "11110010111001001";
            int discLength = 35651584;
            string fill = input;
            while (fill.Length < discLength)
            {
                fill = Dragon(fill);
                Console.WriteLine("Generated fill of length {0}", fill.Length);
            }
            fill = fill.Substring(0, discLength);
            Console.WriteLine(CheckSum(fill));
            Console.ReadLine();
        }

        public static string Dragon(string fill)
        {
            string invertedFill = fill.Replace('0', '2').Replace('1', '0').Replace('2', '1');
            invertedFill = String.Concat(invertedFill.Reverse().ToArray());
            return fill + "0" + invertedFill;
            //int fillLength = fill.Length;
            //fill = fill + "0";
            //for(int i = fillLength -1; i>=0; i--)
            //{
            //    if (fill[i] == '1')
            //    {
            //        fill += "0";
            //    }
            //    else
            //    {
            //        fill += "1";
            //    }
            //}
            //return fill;
        }

        public static string CheckSum(string fill)
        {
            if(fill.Length%2 == 1)
            {
                return fill;
            }

            StringBuilder result = new StringBuilder();
            for(int i =0; i<fill.Length-1; i += 2)
            {
                if(fill.Substring(i, 2) == "11" || fill.Substring(i, 2) == "00")
                {
                    result.Append('1');
                }
                else
                {
                    result.Append('0');
                }
            }
            string r = result.ToString();
            Console.WriteLine("Finishing the halving for {0}", r.Length);
            return (CheckSum(r));
        }
    }
}
