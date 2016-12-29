using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day6
    {
        public static List<char> alphabet = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static void Exercise2()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent6.txt";
            string[] lines = File.ReadAllLines(path);
            int wordLength = lines[0].Length;
            string[] columns = new string[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    columns[i] += lines[j][i];
                }
            }
            string result = "";
            for (int i = 0; i < wordLength; i++)
            {
                result += FindLeastCommonChar(columns[i]);
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent6.txt";
            string[] lines = File.ReadAllLines(path);
            int wordLength = lines[0].Length;
            string[] columns = new string[wordLength];
            for(int i =0; i<wordLength; i++)
            {
                for(int j =0; j<lines.Length; j++)
                {
                    columns[i] += lines[j][i];
                }
            }
            string result = "";
            for (int i = 0; i < wordLength; i++)
            {
                result += FindMostCommonChar(columns[i]);
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static char FindMostCommonChar(string line)
        {
            List<Tuple<int, char>> counts = new List<Tuple<int, char>>();
            for (int i = 0; i < alphabet.Count; i++)
            {
                counts.Add(new Tuple<int, char>(line.Where((x) => (x == alphabet[i])).Count(), alphabet[i]));
            }

            counts.Sort();

            return counts[counts.Count - 1].Item2;
        }

        static char FindLeastCommonChar(string line)
        {
            List<Tuple<int, char>> counts = new List<Tuple<int, char>>();
            for (int i = 0; i < alphabet.Count; i++)
            {
                counts.Add(new Tuple<int, char>(line.Where((x) => (x == alphabet[i])).Count(), alphabet[i]));
            }

            counts.Sort();

            return counts.Where((x)=>(x.Item1>0)).FirstOrDefault().Item2;
        }
    }
}
