using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day4
    {
        public static List<char> alphabet = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static void Exercise2()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\annas\\Downloads\\advent4.txt");
            //List<string> lines = new List<string>()
            //{
            //    "qzmt-zixmtkozy-ivhz-343[abxyz]"
            //};
            foreach (string line in lines)
            {
                int sectorId = 0;
                if (IsRealRoom(line, out sectorId))
                {
                    Console.WriteLine("{0}, SECTOR {1}", DecryptName(line), sectorId);
                }
            }
            Console.ReadLine();
        }

        public static string DecryptName(string line)
        {
            string[] parts = line.Split('-');
            string lastPart = parts[parts.Length - 1];
            int sectorId = Int32.Parse(lastPart.Substring(0, lastPart.IndexOf('[')));
            string linePrettyfied = line.Replace(lastPart, "").Trim('-');
            string decrypted = "";
            for(int i = 0; i<linePrettyfied.Length; i++)
            {
                if (linePrettyfied[i] == '-')
                {
                    decrypted += ' ';
                }
                else
                {
                    decrypted += alphabet[(alphabet.IndexOf(linePrettyfied[i]) + sectorId) % alphabet.Count];
                }
            }
            return decrypted;
        }

        public static void Excercise1()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\annas\\Downloads\\advent4.txt");
            //List<string> lines = new List<string>()
            //{
            //    "aaaaa-bbb-z-y-x-123[abxyz]",
            //    "a-b-c-d-e-f-g-h-987[abcde]",
            //    "not-a-real-room-404[oarel]",
            //    "totally-real-room-200[decoy]"
            //};

            int result = 0;
            foreach (string line in lines)
            {
                int sectorId = 0;
                if (IsRealRoom(line, out sectorId))
                {
                    Console.WriteLine("{0} is a real room", line);
                    result += sectorId;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static bool IsRealRoom(string line, out int sectorId)
        {
            bool result = true;
            string[] parts = line.Split('-');
            string lastPart = parts[parts.Length - 1];
            sectorId = Int32.Parse(lastPart.Substring(0, lastPart.IndexOf('[')));
            string hash = lastPart.Substring(lastPart.IndexOf('[')).Trim('[').Trim(']');
            string linePrettyfied = line.Replace("-", "").Replace(lastPart, "");
            List<Tuple<int, char>> counts = new List<Tuple<int, char>>();
            for(int i =0; i<alphabet.Count; i++)
            {
                counts.Add(new Tuple<int, char>( linePrettyfied.Where((x) => (x == alphabet[i])).Count(), alphabet[i]));
            }

            counts.Sort(delegate (Tuple<int, char> x, Tuple<int, char> y)
            {
                if (x.Item1 == y.Item1) return y.Item2.CompareTo(x.Item2);
                return x.Item1.CompareTo(y.Item1);
            });
            string realHash = "";
            for (int i = 1; i<6; i++)
            {
                realHash += counts[counts.Count - i].Item2;
            }

            result = (hash == realHash);
            return result;
        }
    }
}
