using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day20
    {
        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent20.txt";
            string[] input = File.ReadAllLines(path);
            List<Tuple<long, long>> ranges = new List<Tuple<long, long>>();
            for(int j =0; j < input.Length; j++)
            {
                string[] split = input[j].Split('-');
                ranges.Add(new Tuple<long, long>(Convert.ToInt64(split[0]), Convert.ToInt64(split[1])));
            }
            ranges.Sort();
            long minNumberCurrentRange = ranges[0].Item1;
            long maxNumberCurrentRange = ranges[0].Item2;
            bool loopFound = false;
            int i = 0;
            while (!loopFound)
            {
                i++;
                if (ranges[i].Item1 > maxNumberCurrentRange+1)
                {
                    loopFound = true;
                    Console.WriteLine("Found ip: {0}", maxNumberCurrentRange + 1);
                }
                else
                {
                    maxNumberCurrentRange = Math.Max(maxNumberCurrentRange, ranges[i].Item2);
                }
            }
            Console.ReadLine();

        }

        public static void Exercise2()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent20.txt";
            string[] input = File.ReadAllLines(path);
            List<Tuple<long, long>> ranges = new List<Tuple<long, long>>();
            for (int j = 0; j < input.Length; j++)
            {
                string[] split = input[j].Split('-');
                ranges.Add(new Tuple<long, long>(Convert.ToInt64(split[0]), Convert.ToInt64(split[1])));
            }
            ranges.Sort();
            long minNumberCurrentRange = ranges[0].Item1;
            long maxNumberCurrentRange = ranges[0].Item2;
            long numberOfIPs = 0;
            int i = 0;
            while (i<ranges.Count-1)
            {
                i++;
                if (ranges[i].Item1 > maxNumberCurrentRange + 1)
                {
                    numberOfIPs += (ranges[i].Item1 - maxNumberCurrentRange - 1);
                    minNumberCurrentRange = ranges[i].Item1;
                    maxNumberCurrentRange = ranges[i].Item2;
                }
                else
                {
                    maxNumberCurrentRange = Math.Max(maxNumberCurrentRange, ranges[i].Item2);
                }
            }
            Console.WriteLine("numberOfIPs {0}", numberOfIPs);
            Console.ReadLine();
        }
    }
}
