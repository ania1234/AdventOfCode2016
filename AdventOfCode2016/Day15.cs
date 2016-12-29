using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day15
    {
        public static void Exercise1()
        {
            //List<Tuple<int, int>> discs = new List<Tuple<int, int>>()
            //{
            //    new Tuple<int, int>(5, 4),
            //    new Tuple<int, int>(2, 1)
            //};

            List<Tuple<int, int>> discs = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(13, 11),
                new Tuple<int, int>(5, 0),
                new Tuple<int, int>(17, 11),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(7, 2),
                new Tuple<int, int>(19, 17),
                new Tuple<int, int>(11, 0)
            };

            bool ready = false;
            int t = 0;
            while (!ready)
            {
                ready = true;
                int i = 1;
                foreach(var disc in discs)
                {
                    if (((disc.Item2 + t + i) % disc.Item1) != 0)
                    {
                        ready = false;
                    }
                    i++;
                }
                t++;
            }
            Console.WriteLine(t-1);
            Console.ReadLine();
        }
    }
}
