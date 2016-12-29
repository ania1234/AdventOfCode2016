using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day14
    {
        public static void Exercise1()
        {
            string salt = "jlmsuwbz";
            long index = 0;
            long numberOfGeneratedHashes = 0;
            List<PotentialHash> potentials = new List<PotentialHash>();
            List<PotentialHash> valid = new List<PotentialHash>();
            Regex threeCharHash = new Regex(@"(.)\1{2,}");
            Regex fiveCharHash = new Regex(@"(.)\1{4,}");
            int i;
            for(i = 0; i< 1000; i++)
            {
                string line = salt + i.ToString();
                PotentialHash pot = new PotentialHash(line, i, threeCharHash, fiveCharHash);
                if (pot.threeLetterHash != 'x')
                {
                    potentials.Add(pot);
                }
            }

            while (valid.Count < 64)
            {
                string line = salt + i.ToString();
                PotentialHash pot = new PotentialHash(line, i, threeCharHash, fiveCharHash);
                if (pot.threeLetterHash != 'x')
                {
                    potentials.Add(pot);
                }
                if ((i - potentials[0].place) == 1000)
                {
                    PotentialHash potentialWinner = potentials[0];
                    potentials.RemoveAt(0);
                    foreach (var complimentaryHash in potentials)
                    {
                        if (complimentaryHash.fiveLetterHashes.Contains(potentialWinner.threeLetterHash) && !valid.Contains(potentialWinner))
                        {
                            valid.Add(potentialWinner);
                            Console.WriteLine("Added winner at position {0}, because the char  {1} in string {2} was also found at position {3}", potentialWinner.place, potentialWinner.threeLetterHash, potentialWinner.hash, complimentaryHash.place);
                        }
                    }
                }
                i++;
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }

    class PotentialHash
    {
        public int place;
        public string hash;
        public char threeLetterHash = 'x';
        public List<char> fiveLetterHashes = new List<char>();
        public PotentialHash(string line, int position, Regex threeCharHash, Regex fiveCharHash)
        {
            for (int i = 0; i < 2017; i++)
            {
                line = Day5.MD5Encrypt(line).ToLower();
            }
            hash = line;
            place = position;
            if (threeCharHash.IsMatch(hash))
            {
                threeLetterHash = threeCharHash.Match(hash).Value[0];
            }
            foreach (Match match in fiveCharHash.Matches(hash))
            {
                if (!fiveLetterHashes.Contains(match.Value[0]))
                {
                    fiveLetterHashes.Add(match.Value[0]);
                }
            }
        }
    }
}
