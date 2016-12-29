using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day17
    {
        const string passcode = "veumntbg";

        private class State
        {
            public int x;
            public int y;
            public string pass;
            public string openClosedDoors;
            public int iteration;
        }

        public static void Exercise1()
        {
            List<State> usedStates = new List<State>();
            List<State> foundStates = new List<State>();
            Queue<State> consideredStates = new Queue<State>();
            State rootState = new State { x = 0, y = 0, openClosedDoors = GenerateOpenClosed(passcode), pass = passcode, iteration = 0 };
            consideredStates.Enqueue(rootState);
            usedStates.Add(rootState);

            bool found = false;
            var root = rootState;
            State prevRoot;
            while (consideredStates.Count>0)
            {
                prevRoot = root;
                root = consideredStates.Dequeue();
                if (root.iteration > prevRoot.iteration)
                {
                    //Console.WriteLine("In at most {0} steps we reached {1} locations", root.iteration, usedStates.Count);
                }
                List<State> newStates = FindNewStates(root, usedStates);
                foreach (var state in newStates)
                {
                    if (state.x == 3 && state.y == 3)
                    {
                        Console.WriteLine("Found solution in {0} steps {1}", state.iteration, state.pass);
                        foundStates.Add(state);
                    }
                    else
                    {
                        //Console.WriteLine("Enqueueing {0}, {1}", state.Item1, state.Item2);
                        consideredStates.Enqueue(state);
                        usedStates.Add(state);
                    }
                }
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static List<State> FindNewStates(State root, List<State> usedStates)
        {
            List<State> results = new List<State>();

            //we go up
            if(root.y-1>=0 && root.openClosedDoors[0] == 'o')
            {
                results.Add(new State { x = root.x, y = root.y-1, openClosedDoors = GenerateOpenClosed(root.pass + 'U'), pass = root.pass + 'U', iteration = root.iteration + 1 });
            }

            //we go down
            if (root.y + 1 < 4 && root.openClosedDoors[1] == 'o')
            {
                results.Add(new State { x = root.x, y = root.y + 1, openClosedDoors = GenerateOpenClosed(root.pass + 'D'), pass = root.pass + 'D', iteration = root.iteration + 1 });
            }

            //we go left
            if (root.x - 1 >= 0 && root.openClosedDoors[2] == 'o')
            {
                results.Add(new State { x = root.x-1, y = root.y, openClosedDoors = GenerateOpenClosed(root.pass + 'L'), pass = root.pass + 'L', iteration = root.iteration + 1 });
            }
            //we go right
            if (root.x + 1 < 4 && root.openClosedDoors[3] == 'o')
            {
                results.Add(new State { x = root.x + 1, y = root.y, openClosedDoors = GenerateOpenClosed(root.pass + 'R'), pass = root.pass + 'R', iteration = root.iteration + 1 });
            }

            //we clean
            //for (int i = results.Count-1; i >= 0; i--)
            //{
            //    var result = results[i];
            //        foreach (var usedState in usedStates)
            //        {
            //            if (usedState.x == result.x && usedState.y == result.y && usedState.openClosedDoors == result.openClosedDoors)
            //            {
            //                results.Remove(result);
            //            }
            //        }
            //}
            return results;
        }

        public static string GenerateOpenClosed(string s)
        {
            string md5 = Day5.MD5Encrypt(s).ToLower();
            md5 = md5.Substring(0, 4);
            string result = "";
            for(int i = 0; i<md5.Length; i++)
            {
                if(Char.IsNumber(md5[i]) || md5[i] == 'a')
                {
                    result += "l";
                }
                else
                {
                    result += "o";
                }
            }
            return result;
        }

        public static bool IsBorder(int x, int y)
        {
            if (x == -1 || y == -1 || x==4 || y==4)
            {
                return true;
            }

            return false;
        }
    }
}
