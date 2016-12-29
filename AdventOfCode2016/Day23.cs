using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day23
    {
        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent23.txt";
            string[] input = File.ReadAllLines(path);
            Dictionary<string, long> registry = new Dictionary<string, long>();
            registry.Add("a", 12);
            registry.Add("b", 0);
            registry.Add("c", 0);
            registry.Add("d", 0);
            long i = 0;
            while (i < input.Length)
            {
                string line = input[i];
                //Console.WriteLine(line);
                string[] command = line.Split(' ');
                if (command[0] == "cpy")
                {
                    if (registry.ContainsKey(command[2]))
                    {
                        if (registry.ContainsKey(command[1]))
                        {
                            registry[command[2]] = registry[command[1]];
                        }
                        else
                        {
                            registry[command[2]] = Int32.Parse(command[1]);
                        }
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
                    long numberOfRepetitions;
                    if (registry.ContainsKey(command[1]))
                    {
                        numberOfRepetitions = registry[command[1]];
                    }
                    else
                    {
                        numberOfRepetitions = Int64.Parse(command[1]);
                    }
                    if(numberOfRepetitions == 0)
                    {
                        i++;
                    }
                    else
                    {
                        long numberOfSteps;
                        if (!registry.ContainsKey(command[2])) {
                            numberOfSteps= Int32.Parse(command[2]);
                        }
                        else
                        {
                            numberOfSteps = registry[command[2]];
                        }
                        if (numberOfSteps < 0)
                        {
                            if(CanChunkBeMultiplied(i, numberOfSteps, input))
                            {
                                MultiplyChunk(i, numberOfSteps, Math.Abs(numberOfRepetitions), input, registry);
                                i++;
                            }
                            else
                            {
                                i += numberOfSteps;
                            }
                        }
                        else
                        {
                            i += numberOfSteps;
                        }
                    }
                }
                if (command[0] == "tgl")
                {
                    long numberOfSteps;
                    if (!registry.ContainsKey(command[1])) {
                        numberOfSteps = Int32.Parse(command[1]);
                    }
                    else
                    {
                        numberOfSteps = registry[command[1]];
                    }
                    if (i + numberOfSteps < input.Length)
                    {
                        string commandToToggle = input[i + numberOfSteps].Substring(0, 3);
                        //cpy
                        if (commandToToggle == "cpy")
                        {
                            input[i + numberOfSteps] = input[i + numberOfSteps].Replace("cpy", "jnz");
                        }
                        //inc
                        if (commandToToggle == "inc")
                        {
                            input[i + numberOfSteps] = input[i + numberOfSteps].Replace("inc", "dec");
                        }
                        //dec
                        if (commandToToggle == "dec")
                        {
                            input[i + numberOfSteps] = input[i + numberOfSteps].Replace("dec", "inc");
                        }
                        //tgl
                        if (commandToToggle == "tgl")
                        {
                            input[i + numberOfSteps] = input[i + numberOfSteps].Replace("tgl", "inc");
                        }
                        //jnz
                        if (commandToToggle == "jnz")
                        {
                            input[i + numberOfSteps] = input[i + numberOfSteps].Replace("jnz", "cpy");
                        }
                    }
                    i++;
                }
                //Console.WriteLine(line);
                //Console.WriteLine(i);
                //Console.WriteLine(registry["a"]);
            }
            Console.WriteLine(registry["a"]);
            Console.ReadLine();
        }

        public static bool CanChunkBeMultiplied(long startIndex, long goBack, string[] input)
        {
            for(long i =startIndex + goBack; i<startIndex; i++)
            {
                if(!input[i].StartsWith("inc") && !input[i].StartsWith("dec"))
                {
                    return false;
                }
            }
            return true;
        }

        public static void MultiplyChunk(long startIndex, long goBack, long howManyTimes, string[] input, Dictionary<string, long> registry)
        {
            for (long i = startIndex + goBack; i < startIndex; i++)
            {
                string[] command = input[i].Split(' ');
                if (command[0].StartsWith("inc"))
                {
                    registry[command[1]] += howManyTimes;
                }
                if (command[0].StartsWith("dec"))
                {
                    registry[command[1]] -= howManyTimes;
                }
            }
        }
    }
}
