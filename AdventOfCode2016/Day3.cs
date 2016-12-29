using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day3
    {
        public static void Excercise1()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent3.txt";
            string[] triangles = File.ReadAllLines(path);
            int count = 0;
            foreach(string triangle in triangles)
            {
                if (IsTriangle(triangle))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static void Excercise2()
        {
            string path = "C:\\Users\\annas\\Downloads\\advent3.txt";
            string[] lines = File.ReadAllLines(path);
            List<string> triangles = new List<string>();
            for(int i =0; i<lines.Length-2; i+=3)
            {
                string[] line1 = lines[i].Split(' ').Where((x) => (x.Length > 0)).ToArray();
                string[] line2 = lines[i+1].Split(' ').Where((x) => (x.Length > 0)).ToArray();
                string[] line3 = lines[i+2].Split(' ').Where((x) => (x.Length > 0)).ToArray();
                triangles.Add(line1[0] + " " + line2[0] + " " + line3[0]);
                triangles.Add(line1[1] + " " + line2[1] + " " + line3[1]);
                triangles.Add(line1[2] + " " + line2[2] + " " + line3[2]);
            }
            int count = 0;
            foreach (string triangle in triangles)
            {
                if (IsTriangle(triangle))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static bool IsTriangle(string triangle)
        {
            bool result = true;
            //prepare the edges
            int[] edges = triangle.Split(' ').Where((x)=>(x.Length>0)).Select((x) => (Int32.Parse(x.Trim()))).ToArray();
            if (edges[0] + edges[1] <= edges[2])
            {
                result = false;
            }
            if (edges[2] + edges[1] <= edges[0])
            {
                result = false;
            }
            if (edges[0] + edges[2] <= edges[1])
            {
                result = false;
            }
            return result;
        }
    }
}
