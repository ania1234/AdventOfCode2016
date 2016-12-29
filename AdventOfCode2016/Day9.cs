using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day9
    {
        public static void Exercise2()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent9.txt";
            string initialString = File.ReadAllText(path);
            //string initialString = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";
            Console.WriteLine(GetLength(initialString));
            Console.ReadLine();
        }

        public static long GetLength(string initialString)
        {
            long resultLength = 0;
            int i = 0;
            while (i != initialString.Length)
            {
                char currentChar = initialString[i];
                if (currentChar == '(')
                {
                    i++;
                    string multiplicationString = "";
                    while (initialString[i] != ')')
                    {
                        multiplicationString += initialString[i];
                        i++;
                    }
                    i++;
                    int howLong = Int32.Parse(multiplicationString.Split('x')[0]);
                    int howManyTimes = Int32.Parse(multiplicationString.Split('x')[1]);
                    string what = initialString.Substring(i, howLong);
                    resultLength += (howManyTimes*GetLength(what));
                    i += howLong;
                }
                else
                {
                    resultLength++;
                    i++;
                }
            }

            return resultLength;
        }
        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent9.txt";
            string initialString = File.ReadAllText(path);
            int i = 0;
            string resultString = "";
            while(i!=initialString.Length)
            {
                char currentChar = initialString[i];
                if (currentChar == '(')
                {
                    i++;
                    string multiplicationString = "";
                    while (initialString[i] != ')')
                    {
                        multiplicationString += initialString[i];
                        i++;
                    }
                    i++;
                    int howLong = Int32.Parse(multiplicationString.Split('x')[0]);
                    int howManyTimes = Int32.Parse(multiplicationString.Split('x')[1]);
                    string what = initialString.Substring(i, howLong);
                    for(int j = 0; j<howManyTimes; j++)
                    {
                        resultString += what;
                    }
                    i += howLong;
                }
                else
                {
                    resultString += currentChar;
                    i++;
                }
            }
            Console.WriteLine(resultString);
            Console.WriteLine(resultString.Length);
            Console.ReadLine();
        }
    }
}
