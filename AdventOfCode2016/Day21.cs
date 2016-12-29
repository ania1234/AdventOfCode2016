using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day21
    {
        public static void Exercise1()
        {
            List<char> word = "abcde".ToList();
            string path = "C:\\Users\\annas\\Downloads\\advent21_example.txt";
            //Console.WriteLine("swap position 4 with position 0");
            //SwapPosition(4, 0, word);
            //PrintWord(word);
            //Console.WriteLine("swap letter d with letter b");
            //SwapLetters('d', 'b', word);
            //PrintWord(word);
            //Console.WriteLine("reverse positions 0 through 4");
            //ReversePositions(0, 4, word);
            //PrintWord(word);
            //Console.WriteLine("rotate left 1 step");
            //RotateBy(1, word);
            //PrintWord(word);
            //Console.WriteLine("move position 1 to position 4");
            //MovePosition(1, 4, word);
            //PrintWord(word);
            //Console.WriteLine("move position 3 to position 0");
            //MovePosition(3, 0, word);
            //PrintWord(word);
            //Console.WriteLine("rotate based on position of letter b");
            //RotateBasedOnPosition('b', word);
            //PrintWord(word);
            //Console.WriteLine("rotate based on position of letter d");
            //RotateBasedOnPosition('d', word);
            //PrintWord(word);

            word = "abcdefgh".ToList();
            path = "C:\\Users\\annas\\Downloads\\advent21.txt";
            PrintWord(word);
            string[] input = File.ReadAllLines(path);
            foreach(string line in input)
            {
                Console.WriteLine(line);
                if (line.StartsWith("rotate right"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    Console.WriteLine("rotate right {0} steps", x);
                    RotateBy(x*-1, word);
                }
                if (line.StartsWith("rotate left"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    Console.WriteLine("rotate left {0} steps", x);
                    RotateBy(x, word);
                }
                if (line.StartsWith("rotate based on position of letter"))
                {
                    char letterA = line.Split(' ')[6][0];
                    Console.WriteLine("rotate based on position of letter {0}", letterA);
                    RotateBasedOnPosition(letterA, word);
                }
                if (line.StartsWith("swap position"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[5]);
                    Console.WriteLine("swap position {0} with position {1}", x, y);
                    SwapPosition(x, y, word);
                }
                if (line.StartsWith("move position"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[5]);
                    Console.WriteLine("move position {0} to position {1}", x, y);
                    MovePosition(x, y, word);
                }
                if (line.StartsWith("reverse positions"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[4]);
                    Console.WriteLine("reverse positions {0} through {1}", x, y);
                    ReversePositions(x, y, word);
                }
                if (line.StartsWith("swap letter"))
                {
                    char letterA = line.Split(' ')[2][0];
                    char letterB = line.Split(' ')[5][0];
                    Console.WriteLine("swap letter {0} with letter {1}", letterA, letterB);
                    SwapLetters(letterA, letterB, word);
                }
                PrintWord(word);
            }
            PrintWord(word);
            Console.ReadLine();

        }

        public static void Exercise2()
        {

            List<char> word = "ghfacdbe".ToList();
            word = "fbgdceah".ToList();
            string path = "C:\\Users\\annas\\Downloads\\advent21.txt";
            string[] input = File.ReadAllLines(path);
            for(int i =input.Length-1; i>=0; i--)
            {
                string line = input[i];
                Console.WriteLine(line);
                if (line.StartsWith("rotate right"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    Console.WriteLine("rotate right {0} steps", x);
                    RotateBy(x , word);
                }
                if (line.StartsWith("rotate left"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    Console.WriteLine("rotate left {0} steps", x);
                    RotateBy(x * -1, word);
                }
                if (line.StartsWith("rotate based on position of letter"))
                {
                    char letterA = line.Split(' ')[6][0];
                    Console.WriteLine("rotate based on position of letter {0}", letterA);
                    RotateBasedOnPositionREVERSE(letterA, word);
                }
                if (line.StartsWith("swap position"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[5]);
                    Console.WriteLine("swap position {0} with position {1}", x, y);
                    SwapPosition(x, y, word);
                }
                if (line.StartsWith("move position"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[5]);
                    Console.WriteLine("move position {0} to position {1}", x, y);
                    MovePosition(y, x, word);
                }
                if (line.StartsWith("reverse positions"))
                {
                    int x = Convert.ToInt32(line.Split(' ')[2]);
                    int y = Convert.ToInt32(line.Split(' ')[4]);
                    Console.WriteLine("reverse positions {0} through {1}", x, y);
                    ReversePositions(x, y, word);
                }
                if (line.StartsWith("swap letter"))
                {
                    char letterA = line.Split(' ')[2][0];
                    char letterB = line.Split(' ')[5][0];
                    Console.WriteLine("swap letter {0} with letter {1}", letterA, letterB);
                    SwapLetters(letterA, letterB, word);
                }
                PrintWord(word);
            }
            PrintWord(word);
            Console.ReadLine();

        }

        public static void ReversePositions(int start, int end, List<char>word)
        {
            int len = end - start;
            for(int i =0; i<=len/2; i++)
            {
                SwapPosition(start + i, end - i, word);
            }
        }

        public static void SwapPosition(int x, int y, List<char> word)
        {
            char pom = word[x];
            word[x] = word[y];
            word[y] = pom;
        }

        public static void RotateBy(int x, List<char> word)
        {
            char[] temporaryWord = new char[word.Count];
            word.CopyTo(temporaryWord, 0);;
            while (x < 0)
            {
                x = x + word.Count;
            }
            for(int i =0; i<word.Count; i++)
            {
                word[i] = temporaryWord[(i + x) % word.Count];
            }
        }

        public static void SwapLetters(char letterA, char letterB, List<char> word)
        {
            var index1 = word.IndexOf(letterA);
            var index2 = word.IndexOf(letterB);
            SwapPosition(index1, index2, word);
        }

        public static void RotateBasedOnPosition(char letter, List<char> word)
        {
            var index = word.IndexOf(letter);
            int numberOfTimesToRotate = index > 3 ? 2 : 1;
            numberOfTimesToRotate += index;
            numberOfTimesToRotate = numberOfTimesToRotate * -1;
            RotateBy(numberOfTimesToRotate, word);
            //Console.WriteLine("Position {0} changest to {1} after {2} steps", index, word.IndexOf(letter), numberOfTimesToRotate);
        }


        public static void Helper()
        {
            List<char> word = "abcdefgh".ToList();
            for(int i = 0; i<word.Count; i++)
            {
                List<char> tempWord = new List<char>();
                tempWord.AddRange(word);
                char c = tempWord[i];
                RotateBasedOnPosition(c, tempWord);
            }
        }

        public static void RotateBasedOnPositionREVERSE(char letter, List<char> word)
        {
            var index = word.IndexOf(letter);
            if (index == 0)
            {
                RotateBy(9, word);
            }
            if (index == 1)
            {
                RotateBy(1, word);
            }
            if (index == 2)
            {
                RotateBy(6, word);
            }
            if (index == 3)
            {
                RotateBy(2, word);
            }
            if (index == 4)
            {
                RotateBy(7, word);
            }
            if (index == 5)
            {
                RotateBy(3, word);
            }
            if (index == 6)
            {
                RotateBy(8, word);
            }
            if (index == 7)
            {
                RotateBy(4, word);
            }
        }

        public static void MovePosition(int x, int y, List<char> word)
        {
            char pom = word[x];
            word.RemoveAt(x);
            word.Insert(y, pom);
        }

        public static void PrintWord(List<char> word)
        {
            for(int i =0; i<word.Count; i++)
            {
                Console.Write(word[i]);
            }
            Console.WriteLine();
        }
    }
}
