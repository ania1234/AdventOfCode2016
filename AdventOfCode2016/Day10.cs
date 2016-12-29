using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day10
    {
        public List<Bot> bots = new List<Bot>();
        public List<Output> outputs = new List<Output>();
        public void Exercise1()
        {
            for(int i =0; i<300; i++)
            {
                bots.Add(new Bot{
                    botNumber = i,
                    checkCondition = (x) =>
                    {
                        if (Math.Max(x.slots.Item1, x.slots.Item2)==61 && Math.Min(x.slots.Item1, x.slots.Item2) ==17)
                        {
                            Console.WriteLine(x.botNumber);
                        }
                    }
                }
                );
                outputs.Add(new Output { outputNumber = i });
            }

            string path = "C:\\Users\\annas\\Downloads\\advent10.txt";
            List<string> lines = File.ReadAllLines(path).ToList();
            //lines = new List<string>()
            //{
            //    "value 5 goes to bot 2",
            //    "bot 2 gives low to bot 1 and high to bot 0",
            //    "value 3 goes to bot 1",
            //    "bot 1 gives low to output 1 and high to bot 0",
            //    "bot 0 gives low to output 2 and high to output 0",
            //    "value 2 goes to bot 2"
            //};
            lines.Sort();
            while (lines.Count > 0)
            {
                for (int i = lines.Count - 1; i >= 0; i--)
                {
                    if (TryPerformTask(lines[i]))
                    {
                        //Console.WriteLine("----{0}", lines[i]);
                        lines.RemoveAt(i);
                    }
                }
            }
            Console.WriteLine(outputs[0].outputValue * outputs[1].outputValue * outputs[2].outputValue);
            Console.ReadLine();
       }

        public bool TryPerformTask(string line)
        {
            bool result = false;
            if (line.StartsWith("value"))
            {
                int value = Int32.Parse(line.Split(' ')[1]);
                int goesTo = Int32.Parse(line.Split(' ')[5]);
                if (bots[goesTo].IsFull())
                {
                    return false;
                }
                bots[goesTo].RecieveValue(value);
                result = true;
            }

            if (line.StartsWith("bot"))
            {
                int botNumber = Int32.Parse(line.Split(' ')[1]);
                int high = Math.Max(bots[botNumber].slots.Item1, bots[botNumber].slots.Item2);
                int low = Math.Min(bots[botNumber].slots.Item1, bots[botNumber].slots.Item2);
                string lowRecieverType = line.Split(' ')[5];
                int lowRecieverNumber = Int32.Parse(line.Split(' ')[6]);
                string highRecieverType = line.Split(' ')[10];
                int highRecieverNumber = Int32.Parse(line.Split(' ')[11]);
                if (!bots[botNumber].IsFull())
                {
                    return false;
                }
                if (lowRecieverType == "bot")
                {
                    if (bots[lowRecieverNumber].IsFull())
                    {
                        return false;
                    }
                }
                if(highRecieverType == "bot")
                {
                    if (bots[highRecieverNumber].IsFull())
                    {
                        return false;
                    }
                }
                if (lowRecieverType == "bot")
                {
                    bots[lowRecieverNumber].RecieveValue(low);
                }
                else
                {
                    outputs[lowRecieverNumber].outputValue = low;
                }
                if (highRecieverType == "bot")
                {
                    bots[highRecieverNumber].RecieveValue(high);
                }
                else
                {
                    outputs[highRecieverNumber].outputValue = high;
                }
                bots[botNumber].ClearSlots();
                //Console.WriteLine("bot {0} gives {1} to {2} {3} and {4} to {5} {6}", botNumber, low, lowRecieverType, lowRecieverNumber, high, highRecieverType, highRecieverNumber);
                result = true;
            }

            return result;
        }

        public class Output
        {
            public int outputNumber;
            private int _outputValue = -1;
            public int outputValue
            {
                get
                {
                    return _outputValue;
                }
                set
                {
                    _outputValue = value;
                    Console.WriteLine("value {0} has been put in bin {1}", value, outputNumber);
                }
            }
        }

        public class Bot
        {
            public int botNumber;
            private Tuple<int, int> _slots = new Tuple<int, int>(-1, -1);
            public Action<Bot> checkCondition;
            public bool IsFull()
            {
                return (slots.Item1 != -1 && slots.Item2 != -1);
            }
            public void ClearSlots()
            {
                _slots = new Tuple<int, int>(-1, -1);
            }
            public void RecieveValue(int value)
            {
               // Console.WriteLine("bot {0} recieved {1}", botNumber, value);
                _slots = (_slots.Item1 == -1) ? new Tuple<int, int>(value, _slots.Item2) : new Tuple<int, int>(_slots.Item1, value);
                checkCondition(this);
            }
            public Tuple<int, int> slots
            {
                get
                {
                    return _slots;
                }
            }
        }
    }
}
