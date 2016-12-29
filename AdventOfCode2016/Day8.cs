using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day8
    {
        const int displayWidth = 50;
        const int displayHeight = 6;
        public static void Exercise1()
        {
            bool[,] screen = new bool[displayWidth, displayHeight];

            string path = "C:\\Users\\annas\\Downloads\\advent8.txt";
            string[] commands = File.ReadAllLines(path);
            //List<string> commands = new List<string>()
            //{
            //    "rect 3x2",
            //    "rotate column x=1 by 1",
            //    "rotate row y=0 by 4",
            //    "rotate column x=1 by 1"
            //};

            foreach(string command in commands)
            {
                ParseLine(command, screen);
            }

            PrintTable(screen);

            int result = 0;
            for(int i = 0; i<displayWidth; i++)
            {
                for(int j = 0; j<displayHeight; j++)
                {
                    result += screen[i, j] ? 1 : 0;
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void ParseLine(string line, bool[,] screen)
        {
            if (line.StartsWith("rect"))
            {
                int width = Int32.Parse(line.Split(' ')[1].Split('x')[0]);
                int height = Int32.Parse(line.Split(' ')[1].Split('x')[1]);
                Rect(width, height, screen);
            }
            if (line.StartsWith("rotate row y="))
            {
                int rowNumber = Int32.Parse(line.Replace("rotate row y=", "").Split(' ')[0]);
                int by = Int32.Parse(line.Replace("rotate row y=", "").Split(' ')[2]);
                RotateRow(rowNumber, by, screen);
            }
            if(line.StartsWith("rotate column x="))
            {
                int columnNumber = Int32.Parse(line.Replace("rotate column x=", "").Split(' ')[0]);
                int by = Int32.Parse(line.Replace("rotate column x=", "").Split(' ')[2]);
                RotateColumn(columnNumber, by, screen);
            }
        }

        public static void RotateRow(int rowNumber, int by, bool[,] screen)
        {
            bool[] newRow = new bool[displayWidth];
            for (int i = 0; i < displayWidth; i++)
            {
                newRow[(i + by) % displayWidth] = screen[i, rowNumber];
            }
            for (int i = 0; i < displayWidth; i++)
            {
                screen[i, rowNumber] = newRow[i];
            }
        }

        public static void RotateColumn(int columnNumber, int by, bool[,] screen)
        {
            bool[] newColumn = new bool[displayHeight];
            for (int i = 0; i < displayHeight; i++)
            {
                newColumn[(i + by) % displayHeight] = screen[columnNumber, i];
            }
            for (int i = 0; i < displayHeight; i++)
            {
                screen[columnNumber, i] = newColumn[i];
            }
        }
        public static void Rect(int width, int height, bool[,] screen)
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    screen[i, j] = true;
                }
            }
        }

        public static void PrintTable(bool[,] screen)
        {
            for(int j=0; j<displayHeight; j++)
            {
                for (int i = 0; i < displayWidth; i++)
                {
                    char symbol = screen[i, j] ? '#' : ' ';
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}
