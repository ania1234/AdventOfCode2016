using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day24
    {
        public static string[] map;
        public static List<char> AllPOIs = new List<char>();

        public static void ReadMap()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent24.txt";
            map = File.ReadAllLines(path);
            Regex anyNumber = new Regex(@"[0-9]");
            for(int i =0; i<map.Length; i++)
            {
                var line = map[i];
                foreach(Match match in anyNumber.Matches(line))
                {
                    AllPOIs.Add(match.Value[0]);
                }
            }
            AllPOIs.Sort();
        }

        public static void SetXY(char c, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < map.Length; i++)
            {
                var line = map[i];
                if(line.Contains(c))
                {
                    y = i;
                    x = line.IndexOf(c);
                }
            }
        }


        public static int BFSFromAToB(char a, char b)
        {
            int startX, startY, endX, endY;
            SetXY(a, out startX, out startY);
            SetXY(b, out endX, out endY);
            List<State> usedStates = new List<State>();
            List<State> foundStates = new List<State>();
            Queue<State> consideredStates = new Queue<State>();
            State rootState = new State { x = startX, y = startY, iteration = 0 };
            consideredStates.Enqueue(rootState);
            usedStates.Add(rootState);

            bool found = false;
            var root = rootState;
            State prevRoot;
            int result = 0;
            while (!found)
            {
                prevRoot = root;
                root = consideredStates.Dequeue();
                List<State> newStates = FindNewStates(root, usedStates);
                foreach (var state in newStates)
                {
                    if (state.x == endX && state.y == endY)
                    {
                        found = true;
                        result = state.iteration;
                    }
                    else
                    {
                        consideredStates.Enqueue(state);
                        usedStates.Add(state);
                    }
                }
            }
            return result;
        }

        public static void Exercise1() {
            ReadMap();
            List<Tuple<char, char, int>> edges = new List<Tuple<char, char, int>>();
            for(int i =0; i<AllPOIs.Count; i++)
            {
                for (int j = i+1; j < AllPOIs.Count; j++)
                {
                    var t = new Tuple<char, char, int>(AllPOIs[i], AllPOIs[j], BFSFromAToB(AllPOIs[i], AllPOIs[j]));
                    Console.WriteLine("The distance between {0} and {1} is {2}", t.Item1, t.Item2, t.Item3);
                    edges.Add(t);
                }
            }

            AllPOIs.Remove('0');
            List<char[]> permutations = GetPer(AllPOIs.ToArray());
            List<int> distances = new List<int>();
            for(int i =0; i<permutations.Count; i++)
            {
                int distance = 0;
                char prev = '0';
                char next = '0';
                for(int j =0; j<AllPOIs.Count; j++)
                {
                    next = permutations[i][j];
                    distance += edges.Where((x) => ((x.Item1 == next && x.Item2 == prev) || (x.Item2 == next && x.Item1 == prev))).First().Item3;
                    prev = next;
                }
                //the next two lines are for Exercise 2
                next = '0';
                distance += edges.Where((x) => ((x.Item1 == next && x.Item2 == prev) || (x.Item2 == next && x.Item1 == prev))).First().Item3;
                distances.Add(distance);
            }
            Console.WriteLine("MinDistance {0}", distances.Min());
            Console.ReadLine();
        }
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static List<char[]> GetPer(char[] list)
        {
            List<char[]> result = new List<char[]>();
            int x = list.Length - 1;
            GetPer(list, 0, x, result);
            return result;
        }

        private static void GetPer(char[] list, int k, int m, List<char[]> result)
        {
            if (k == m)
            {
                char[] n = (char[])list.Clone();
                result.Add(n);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m, result);
                    Swap(ref list[k], ref list[i]);
                }
        }
        public static List<State> FindNewStates(State root, List<State> usedStates)
        {
            List<State> result = new List<State>();
            string[] visitedPois = new string[root.visitedPOI.Count];
            root.visitedPOI.CopyTo(visitedPois);
            result.Add(new State() { x = root.x - 1, y = root.y, iteration = root.iteration + 1});
            result.Add(new State() { x = root.x + 1, y = root.y, iteration = root.iteration + 1});
            result.Add(new State() { x = root.x, y = root.y - 1, iteration = root.iteration + 1});
            result.Add(new State() { x = root.x, y = root.y + 1, iteration = root.iteration + 1});
            for(int i = result.Count-1; i>=0; i--)
            {
                var r = result[i];
                if (IsStateInvalid(r))
                {
                    result.Remove(r);
                }
                else
                {
                    foreach(State s in usedStates)
                    {
                        if(s.x==r.x && s.y == r.y)
                        {
                            result.Remove(r);
                        }
                    }
                }
            }
            return result;
        }

        public static bool IsStateInvalid(State s)
        {
            if (map[s.y][s.x] == '#')
            {
                return true;
            }
            return false;
        }

        public class State
        {
            public int x;
            public int y;
            public int iteration;
            public List<string> visitedPOI = new List<string>();
        }
    }
}
