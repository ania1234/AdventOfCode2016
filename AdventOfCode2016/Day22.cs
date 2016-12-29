using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day22
    {
        public static void Exercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent22.txt";
            string[] lines = File.ReadAllLines(path);
            List<Partition> partitions = new List<Partition>();
            for (int i = 2; i < lines.Length; i++)
            {
                var line = lines[i];
                var p = new Partition(line);
                partitions.Add(p);
            }

            long viable = 0;
            for (int i = 0; i < partitions.Count; i++)
            {
                for (int j = 0; j < partitions.Count; j++)
                {
                    var p1 = partitions[i];
                    var p2 = partitions[j];
                    if (p1.CanBeCopiedTo(p2))
                    {
                        viable++;
                    }
                }
            }
            Console.WriteLine("VIABLE PAIRS {0}", viable);
            Console.ReadLine();
        }

        public class Partition
        {
            public int x;
            public int y;
            public int avail;
            public int used;
            public Partition(string s)
            {
                string[] partitionName = s.Substring(9, 13).Trim().Split('-');
                x = Convert.ToInt32(partitionName[1].Trim('x'));
                y = Convert.ToInt32(partitionName[2].Trim('y'));
                string usedStr = s.Substring(28, 5).Trim();
                used = Convert.ToInt32(usedStr);
                string availStr = s.Substring(34, 6).Trim();
                avail = Convert.ToInt32(availStr);
                //Console.WriteLine("X: {0}, Y: {1}, used: {1}, avail: {2}", x, y, used, avail);
            }

            public bool CanBeCopiedTo(Partition p)
            {
                if(this == p || this.used==0)
                {
                    return false;
                }
                if (this.used <= p.avail)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
