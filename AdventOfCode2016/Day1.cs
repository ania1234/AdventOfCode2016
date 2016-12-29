using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day1
    {
        public static void Excercise1()
        {
            string input = "L1, L3, L5, L3, R1, L4, L5, R1, R3, L5, R1, L3, L2, L3, R2, R2, L3, L3, R1, L2, R1, L3, L2, R4, R2, L5, R4, L5, R4, L2, R3, L2, R4, R1, L5, L4, R1, L2, R3, R1, R2, L4, R1, L2, R3, L2, L3, R5, L192, R4, L5, R4, L1, R4, L4, R2, L5, R45, L2, L5, R4, R5, L3, R5, R77, R2, R5, L5, R1, R4, L4, L4, R2, L4, L1, R191, R1, L1, L2, L2, L4, L3, R1, L3, R1, R5, R3, L1, L4, L2, L3, L1, L1, R5, L4, R1, L3, R1, L2, R1, R4, R5, L4, L2, R4, R5, L1, L2, R3, L4, R2, R2, R3, L2, L3, L5, R3, R1, L4, L3, R4, R2, R2, R2, R1, L4, R4, R1, R2, R1, L2, L2, R4, L1, L2, R3, L3, L5, L4, R4, L3, L1, L5, L3, L5, R5, L5, L4, L2, R1, L2, L4, L2, L4, L1, R4, R4, R5, R1, L4, R2, L4, L2, L4, R2, L4, L1, L2, R1, R4, R3, R2, R2, R5, L1, L2";
            //input = "R2, L3"; //2 east, 3 north
            //input = "R2, R2, R2"; //2 south
            //input = "R5, L5, R5, R3"; //12 blocks away
            //input = "R8, R4, R4, R8";//the first location is 4 blocks away
            List<string> inputDecimated = new List<string>();
            List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
            locations.Add(new Tuple<int, int>(0, 0));
            int moveUpDown = 0;
            int moveLeftRight = 0;


            //we reconstruct the decimated input
            inputDecimated = input.Split(',').Select((x) => (x.Trim())).ToList();
            int rightMultiplier = 1;
            for(int i = 0; i<inputDecimated.Count; i++)
            {
                Tuple<int, int> currentLocation = locations.Last();
                char where = inputDecimated[i][0];
                int howMuch = Int32.Parse(inputDecimated[i].Substring(1));
                if ((i % 2) == 0)
                {
                    int multiplier = (where == 'R') ? rightMultiplier : -1 * rightMultiplier;
                    for(int j = 1; j < howMuch+1; j++)
                    {
                        moveLeftRight += multiplier;
                        Tuple<int, int> newLocation = new Tuple<int, int>(currentLocation.Item1 + j*multiplier, currentLocation.Item2);
                        if (locations.Contains(newLocation))
                        {
                            Console.WriteLine("{0}, {1}, sum is {2}", newLocation.Item1, newLocation.Item2, Math.Abs(newLocation.Item1) + Math.Abs(newLocation.Item2));
                        }
                        locations.Add(newLocation);
                    }
                }
                else
                {
                    int multiplier = (where == 'R') ? rightMultiplier : -1 * rightMultiplier;
                    for (int j = 1; j < howMuch+1; j++)
                    {
                        moveUpDown += multiplier;
                        Tuple<int, int> newLocation = new Tuple<int, int>(currentLocation.Item1, currentLocation.Item2 + j*multiplier);
                        if (locations.Contains(newLocation))
                        {
                            Console.WriteLine("{0}, {1}, sum is {2}", newLocation.Item1, newLocation.Item2, Math.Abs(newLocation.Item1) + Math.Abs(newLocation.Item2));
                        }
                        locations.Add(newLocation);
                    }
                }
                rightMultiplier = GetNewRightMultiplier(rightMultiplier, where, i);
            }
            Console.ReadLine();
        }

        static int GetNewRightMultiplier(int prevRightMultiplier, char where, int iteration)
        {
            bool northSouth = (iteration % 2 == 0);
            if (northSouth)
            {
                if (prevRightMultiplier == 1)
                {
                    //if we go right, and we previously faced north, then now we face east, and the rightMultiplier is -1
                    //if we go left, and we previously faced north, then now we face west, and the rightMultiplier is 1
                    return (where == 'R') ? -1 : 1;
                }
                else
                {
                    //if we go right, and we previously faced south, then now we face west, and the rightMultiplier is 1
                    //if we go left, and we previously faced south, then now we face east, and the rightMultiplier is -1
                    return (where == 'R') ? 1 : -1;
                }
            }
            else
            {
                if (prevRightMultiplier == -1)
                {
                    //if we go right, and we previously faced east, then now we face south, and the rightMultiplier is -1
                    //if we go left, and we previously faced east, then now we face north, and the rightMultiplier is 1
                    return (where == 'R') ? -1 : 1;
                }
                else
                {
                    //if we go right, and we previously faced west, then now we face north, and the rightMultiplier is 1
                    //if we go left, and we previously faced west, then now we face south, and the rightMultiplier is -1
                    return (where == 'R') ? 1 : -1;
                }
            }
        }
    }
}
