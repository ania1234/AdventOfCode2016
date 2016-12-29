using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day13
    {
        public static void Exercise1()
        {
            for(int y =0; y<6;y++)
            {
                for(int x = 0; x<10; x++)
                {
                    if(IsWall(x, y))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            List<Tuple<int, int, int>> usedStates = new List<Tuple<int, int, int>>();
            Queue<Tuple<int, int, int>> consideredStates = new Queue<Tuple<int, int, int>>();
            Tuple<int, int, int> rootState = new Tuple<int, int, int>(1, 1, 0);
            consideredStates.Enqueue(rootState);
            usedStates.Add(rootState);
            
            bool found = false;
            int i = 0;
            Tuple<int, int, int> root = rootState;
            Tuple<int, int, int> prevRoot;
            while (!found)
            {
                prevRoot = root;
                root = consideredStates.Dequeue();
                if (root.Item3 > prevRoot.Item3)
                {
                    Console.WriteLine("In at most {0} steps we reached {1} locations", root.Item3, usedStates.Count);
                }
                List<Tuple<int, int, int>> newStates = FindNewStates(root, usedStates);
                foreach(var state in newStates)
                {
                    if(state.Item1==31 && state.Item2 == 39)
                    {
                        Console.WriteLine("Found solution in {0} steps", state.Item3);
                        found = true;
                    }
                    else
                    {
                        Console.WriteLine("Enqueueing {0}, {1}", state.Item1, state.Item2);
                        consideredStates.Enqueue(state);
                        usedStates.Add(state);
                    }
                }
            }
            Console.ReadLine();
        }

        private static List<Tuple<int, int, int>> FindNewStates(Tuple<int, int, int> root, List<Tuple<int, int, int>> usedStates)
        {
            List<Tuple<int, int, int>> results = new List<Tuple<int, int, int>>() {
            new Tuple<int, int, int>(root.Item1 + 1, root.Item2, root.Item3 + 1),
            new Tuple<int, int, int>(root.Item1 - 1, root.Item2, root.Item3 + 1),
            new Tuple<int, int, int>(root.Item1, root.Item2 +1, root.Item3 + 1),
            new Tuple<int, int, int>(root.Item1, root.Item2 -1, root.Item3 + 1)};
            
            for(int i = 3; i>=0; i--)
            {
                var result = results[i];
                if (IsWall(result.Item1, result.Item2))
                {
                    results.Remove(result);
                }
                else
                {
                    foreach (var usedState in usedStates)
                    {
                        if (usedState.Item1 == result.Item1 && usedState.Item2 == result.Item2)
                        {
                            results.Remove(result);
                        }
                    }
                }
            }
            return results;
        }

        public static bool IsWall(int x, int y)
        {
            if(x==-1 || y == -1)
            {
                return true;
            }
            int designersFavourite = 1362;
            int number = x * x + 3 * x + 2 * x * y + y + y * y + designersFavourite;
            string binary = Convert.ToString(number, 2);
            int numberOfOnes = binary.Where((c) => (c == '1')).Count() % 2;
            if (numberOfOnes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
