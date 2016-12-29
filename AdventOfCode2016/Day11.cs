using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Day11
{
    public static string[] map;
    public static State initialMap;
    public static State endState;

    public static void ReadMap()
    {
        string path = "C:\\Users\\annas\\Downloads\\advent11_part2.txt";
        map = File.ReadAllLines(path);
        initialMap = new State(map);
        endState = new State(map[0].Length);
    }
    public class State
    {
        public int iteration = 0;
        public int playerPosition =0;
        public List<int[]> pairs = new List<int[]>();

        public void PrintState()
        {
            Console.Write("player: {0} ,", this.playerPosition);
            for(int i =0; i<this.pairs.Count; i++)
            {
                Console.Write(", ({0}, {1})", this.pairs[i][0], this.pairs[i][1]);
            }
            Console.WriteLine();
        }
        public State() { }
        public State(int length)
        {
            for (int j = 2; j < length; j += 2)
            {
                pairs.Add(new int[2]);
            }
        }
        public State(string[] map)
        {
            for (int j = 2; j < map[0].Length; j+=2)
            {
                pairs.Add(new int[2]);
            }
            for (int i = 0; i<map.Length; i++)
            {
                if (map[i].Contains("E"))
                {
                    playerPosition = i;
                }
                for(int j = 2; j<map[i].Length; j+=2)
                {
                    if(map[i].Substring(j, 1)!=".")
                    {
                        pairs[(j - 2)/2][0] = i;
                    }
                    if (map[i].Substring(j+1, 1) != ".")
                    {
                        pairs[(j - 2)/2][1] = i;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            State s = obj as State;
            if (s == null)
            {
                return false;
            }
            if (s.playerPosition != this.playerPosition)
            {
                return false;
            }

            var theirs = s.pairs.OrderBy((x) => (x[0])).ToList();
            var ours = this.pairs.OrderBy((x) => (x[0])).ToList();
            theirs = theirs.OrderBy((x) => x[1]).ToList();
            ours = ours.OrderBy((x) => x[1]).ToList();
            for(int i =0; i<this.pairs.Count; i++)
            {
                if(ours[i][0]!= theirs[i][0] || ours[i][1] != theirs[i][1])
                {
                    return false;
                }
            }

            return true;
        }
    }
    public static void Exercise1()
    {
        ReadMap();
        Console.WriteLine(IsValid(initialMap));
        initialMap.PrintState();
        List<State> usedStates = new List<State>();
        List<State> foundStates = new List<State>();
        Queue<State> consideredStates = new Queue<State>();
        State rootState = initialMap;
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
            if (prevRoot.iteration != root.iteration)
            {
                Console.WriteLine("Iteration {0}", prevRoot.iteration);
            }
            List<State> newStates = FindNewStates(root, usedStates);
            foreach (var state in newStates)
            {
                //state.PrintState();
                if (state.Equals(endState))
                {
                    Console.WriteLine("FOUND");
                    found = true;
                    result = state.iteration;
                }
                else
                {
                    usedStates.Add(state);
                    consideredStates.Enqueue(state);
                }
            }
        }
        Console.WriteLine(result);
        Console.ReadLine();
    }

    public static List<State> FindNewStates(State root, List<State> usedStates)
    {
        List<State> result = new List<State>();
        for(int i =0; i<root.pairs.Count*2; i++)
        {
            if (root.pairs[i/2][i%2] == root.playerPosition)
            {
                for(int add = -1; add<=1; add += 2)
                {
                    var newState = new State() { playerPosition = root.playerPosition + add, iteration = root.iteration + 1, pairs = root.pairs.Select(item => (int[])item.Clone()).ToList() };
                    newState.pairs[i / 2][i % 2] += add;
                    result.Add(newState);
                    //Console.WriteLine("NEW STATE");
                    //newState.PrintState();
                    for(int j = i+1; j< root.pairs.Count * 2; j++)
                    {
                        if (root.pairs[j / 2][j % 2] == root.playerPosition)
                        {
                            var newNewState = new State() { playerPosition = newState.playerPosition, iteration = newState.iteration, pairs = newState.pairs.Select(item => (int[])item.Clone()).ToList() };
                            newNewState.pairs[j / 2][j % 2] += add;
                            result.Add(newNewState);
                        }
                    }
                }
            }
        }

        for (int i = result.Count-1; i>=0; i--)
        {
            State r = result[i];
            if (!IsValid(r))
            {
                //Console.WriteLine("rmoving state because invalid");
                result.Remove(r);
            }
            else
            {
                for(int j = usedStates.Count-1; j>=0; j--)
                {
                    var s  = usedStates[j];
                    if (r.Equals(s))
                    {
                        result.Remove(r);
                        break;
                    }
                }
            }
        }
        return result;

    }

    public static bool IsValid(State state)
    {
        if(state.playerPosition==map.Length || state.playerPosition == -1)
        {
            return false;
        }
        for(int i =0; i<state.pairs.Count; i++)
        {
            if(state.pairs[i][0]!=state.pairs[i][1] && state.pairs.Where((x) => (x[0] == state.pairs[i][1])).Count() > 0)
            {
                return false;
            }
        }

        return true;
    }
}