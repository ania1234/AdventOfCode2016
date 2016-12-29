using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day18
    {
        public static void Exercise1()
        {
            string input = "......^.^^.....^^^^^^^^^...^.^..^^.^^^..^.^..^.^^^.^^^^..^^.^.^.....^^^^^..^..^^^..^^.^.^..^^..^^^..";
            input = "." + input + ".";
            List<string> output = new List<string>();
            output.Add(input);
            //400000
            for (int i = 0; i<399999; i++)
            {
                output.Add(GenerateRow(output.Last()));
            }
            int countSafe = 0;
            for(int i =0; i<output.Count; i++)
            {
                countSafe += (output[i].Where((x) => (x == '.')).Count()-2);
            }
            Console.WriteLine(countSafe);
            Console.ReadLine();
        }

        public static string GenerateRow(string prev)
        {
            string output = "";
            for(int i = 1; i<prev.Length-1; i++)
            {
                char toAdd = '.';
                //Its left and center tiles are traps, but its right tile is not.
                if (prev[i-1]=='^' && prev[i]=='^' && prev[i+1]=='.')
                {
                    toAdd = '^';
                }
                //Its center and right tiles are traps, but its left tile is not.
                if (prev[i - 1] == '.' && prev[i] == '^' && prev[i + 1] == '^')
                {
                    toAdd = '^';
                }
                //Only its left tile is a trap.
                if (prev[i - 1] == '^' && prev[i] == '.' && prev[i + 1] == '.')
                {
                    toAdd = '^';
                }
                //Only its right tile is a trap.
                if (prev[i - 1] == '.' && prev[i] == '.' && prev[i + 1] == '^')
                {
                    toAdd = '^';
                }
                output += toAdd;
            }
            output = "." + output + ".";
            return output;
        }
    }
}
