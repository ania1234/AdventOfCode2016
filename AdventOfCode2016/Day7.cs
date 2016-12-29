using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day7
    {
        public static void Exercise2()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent7.txt";
            string[] lines = File.ReadAllLines(path);
            //List<string> lines = new List<string>()
            //{
            //    "aba[bab]xyz",
            //    "xyx[xyx]xyx",
            //    "aaa[kek]eke",
            //    "zazbz[bzb]cdb"
            //};
            int result = 0;
            foreach (string line in lines)
            {
                //Console.WriteLine("{0}, {1}", line, IsSSLIP(line));
                if (IsSSLIP(line))
                {
                    result++;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent7.txt";
            string[] lines = File.ReadAllLines(path);
            //List<string> lines = new List<string>()
            //{
            //    "abba[mnop]qrst",
            //    "abcd[bddb]xyyx",
            //    "aaaa[qwer]tyui",
            //    "ioxxoj[asdfgh]zxcvbn"
            //};
            int result = 0;
            foreach (string line in lines)
            {
                //Console.WriteLine("{0}, {1}", line, IsABBAIP(line));
                if (IsABBAIP(line))
                {
                    result++;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static bool IsSSLIP(string line)
        {
            bool result = false;
            string[] firstSplit = line.Split('[');
            List<string> secondSplit = new List<string>();
            List<Tuple<char, char>> sequencesABA = new List<Tuple<char, char>>();
            List<Tuple<char, char>> sequencesBAB = new List<Tuple<char, char>>();
            foreach (string partialSplit in firstSplit)
            {
                secondSplit.AddRange(partialSplit.Split(']'));
            }

            for (int i = 0; i < secondSplit.Count; i += 2)
            {
                sequencesABA.AddRange(SearchABA(secondSplit[i]));
            }

            for (int i = 1; i < secondSplit.Count; i += 2)
            {
                sequencesBAB.AddRange(SearchABA(secondSplit[i]));
            }

            foreach(var tuple in sequencesABA)
            {
                if(sequencesBAB.Contains(new Tuple<char, char>(tuple.Item2, tuple.Item1)))
                {
                    result = true;
                }
            }

            return result;
        }

        static List<Tuple<char, char>> SearchABA(string part)
        {
            List<Tuple<char, char>> result = new List<Tuple<char, char>>();
            for (int i = 0; i < part.Length - 2; i++)
            {
                if (part[i] == part[i + 2] && part[i + 1] != part[i])
                {
                    result.Add(new Tuple<char, char>(part[i], part[i + 1]));
                }
            }
            return result;
        }

        static bool IsABBAIP(string line)
        {
            bool result = false;

            string[] firstSplit = line.Split('[');
            List<string> secondSplit = new List<string>();
            foreach(string partialSplit in firstSplit)
            {
                secondSplit.AddRange(partialSplit.Split(']'));
            }

            for(int i =0; i<secondSplit.Count; i+=2)
            {
                if (HasAbbaSequence(secondSplit[i]))
                {
                    result = true;
                }
            }

            for (int i = 1; i < secondSplit.Count; i += 2)
            {
                if (HasAbbaSequence(secondSplit[i]))
                {
                    result = false;
                }
            }

            return result;
        }

        static bool HasAbbaSequence(string part)
        {
            if (part.Length < 4)
            {
                return false;
            }
            bool result = false;
            for(int i =0; i<part.Length - 3; i++)
            {
                if(part[i]==part[i+3] && part[i+1] == part[i+2] && part[i] != part[i + 1])
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
