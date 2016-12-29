using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day12
    {
        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent12.txt";
            string[] input = File.ReadAllLines(path);
            Dictionary<string, int> registry = new Dictionary<string, int>();
            registry.Add("a", 0);
            registry.Add("b", 0);
            registry.Add("c", 1);
            registry.Add("d", 0);
            int i = 0;
            while(i<input.Length)
            {
                string line = input[i];
                string[] command = line.Split(' ');
                if (command[0] == "cpy")
                {
                    if (registry.ContainsKey(command[1]))
                    {
                        registry[command[2]] = registry[command[1]];
                    }
                    else
                    {
                        registry[command[2]] = Int32.Parse(command[1]);
                    }
                    i++;
                }
                if (command[0] == "dec")
                {
                    registry[command[1]]--;
                    i++;
                }
                if (command[0] == "inc")
                {
                    registry[command[1]]++;
                    i++;
                }
                if (command[0] == "jnz")
                {

                    if ((registry.ContainsKey(command[1]) && registry[command[1]] == 0) || (!registry.ContainsKey(command[1]) && Int32.Parse(command[1]) == 0))
                    {
                        i++;
                    }
                    else
                    {
                        int numberOfSteps = Int32.Parse(command[2]);
                        i += numberOfSteps;
                    }
                }
            }
            Console.WriteLine(registry["a"]);
            Console.ReadLine();
        }
    }
}
