using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day19
    {
        public static void Exercise1()
        {
            int numberOfElves = 3018458;
            int[] presents = new int[numberOfElves];
            for (int k =0; k<numberOfElves; k++)
            {
                presents[k] = 1;
            }

            int i = 0;
            bool oneElfHasAll = false;
            while (!oneElfHasAll)
            {
                if (presents[i] != 0)
                {
                    int nextElf = (i + 1) % numberOfElves;
                    while (presents[nextElf] == 0)
                    {
                        nextElf = (nextElf + 1) % numberOfElves;
                    }
                   
                    int numberStolen = presents[nextElf];
                    presents[i] += numberStolen;
                    presents[nextElf] = 0;
                    if (presents[i] == numberOfElves)
                    {
                        oneElfHasAll = true;
                        Console.WriteLine("Elf {0} has all the presents", i +1);
                    }
                }
                i = (i+1) % numberOfElves;
            }

            Console.ReadLine();
        }

        public static void Exercise2()
        {
            int numberOfElves = 3018458;
            LinkedList<int> elves = new LinkedList<int>();
            for (int k = 0; k < numberOfElves; k++)
            {
                LinkedListNode<int> elf = new LinkedListNode<int>(k);
                elves.AddLast(elf);
            }

            LinkedListNode<int> toStealFrom= elves.Find(elves.Count / 2);
            int iterationCount = 0;
            while (elves.Count>1)
            {
                var newElfToStealFrom = toStealFrom.Next != null ? toStealFrom.Next : elves.First;
                if(elves.Count%2 == 1)
                {
                    newElfToStealFrom = newElfToStealFrom.Next != null ? newElfToStealFrom.Next : elves.First;
                }
                elves.Remove(toStealFrom);
                toStealFrom = newElfToStealFrom;
            }
            Console.WriteLine("last elf standing: {0}", elves.First.Value +1);
            Console.WriteLine(iterationCount);
            Console.ReadLine();
        }
    }
}
