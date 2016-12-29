using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day25
    {
        public static void Exercise1()
        {
            //d = a + 365 * 7
            //while true {
            //  a = d
            //  while a != 0 {
            //     b = a % 2
            //    a /= 2
            //    output b
            //  }
            //}
            int a = 0;
            int magicNumber = 365*7;
            string d = Convert.ToString(a + magicNumber, 2);
            while (d.Replace("10", "").Length>0)
            {
                d = Convert.ToString(a + magicNumber, 2);
                Console.WriteLine("{0},  {1}", d, a);
                a++;
            }
            Console.WriteLine(a-1);
            Console.ReadLine();
        }

    }
}
