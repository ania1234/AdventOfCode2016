using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day2
    {
        public static void Excercise1()
        {
            //int[,] array2Da = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6}, {7, 8, 9 } };
            char[,] array2Da = new char[7, 7] {
                { ' ',' ', ' ', ' ', ' ', ' ',' ' },
                { ' ',' ', ' ', '1', ' ', ' ',' ' },
                { ' ',' ', '2', '3', '4', ' ',' ' },
                { ' ','5', '6', '7', '8', '9',' ' },
                { ' ',' ', 'A', 'B', 'C', ' ',' ' },
                { ' ',' ', ' ', 'D', ' ', ' ',' ' },
                { ' ',' ', ' ', ' ', ' ', ' ',' ' },};
            Tuple<int, int> start = new Tuple<int, int>(1, 3);
            //List<string> instructions = new List<string>() { "ULL", "RRDDD", "LURDL", "UUUUD" };
            List<string> instructions = new List<string>();
            instructions.Add("UUURRRRULRDLRDRRDURDDDLLDLLLULDUDDLDLULUURULRLDLRRLLLRRDRRLDDLLULUDUDDLRDRDUURDLURUURLRULLDDURULRRURDUURLULUUUURDDDDUUDLULRULLLRLLRRRURDLLRLLRRRUURULRDRUUDDDDDLLLRURRURRUURDUURDDRDLULRRLLLDRRRLURRLLURLDRRDDLDLRRLLRDRLLLLDLULDLRRDRRLDDURLULLUDLUDRRDRRLRLULURDRLRLUUUDLRLDLLLURDUDULULDDRUUURLLLDLLDDUDDRURURUDDLUULRDRRRRLDRDDURLUDURDULLDLUDLULDRLRLLRLLLLRURDURLLDRRDRLRUUUUULLLRUDURUDLLLUDLLLLRDLDRDUDRURLUDDUDDURLUUUUDDLLUDLULLLLLDUDLLRLRRDDDULULRLDRLLULDLUDLLURULRDDUURULRDLDLDLRL");
            instructions.Add("URUUURDULUDLUUUUDDRRRDRRRLDUDLRDRRDRDDLRUULDLLDUDULLLRLDRDRRLDLDLUUDRUULDUDULDUDURURDDURULDLURULRLULDUDDUULDLLLDDURDDRDDURUULUUDRLDDULDRRRRDURRUDLLLURDDDLRULLRDDRDDDDLUUDRDUULRRRRURULDDDLDDRDRRUDRRURUDRDDLDRRRLLURURUULUUDRDULLDRLRDRRDDURDUDLDRLUDRURDURURULDUUURDUULRRRRRUDLLULDDDRLULDDULUDRRRDDRUDRRDLDLRUULLLLRRDRRLUDRUULRDUDRDRRRDDRLLRUUDRLLLUDUDLULUUDULDRRRRDDRURULDULLURDLLLDUUDLLUDRLDURRRLDDDURUDUDURRULDD");
            instructions.Add("LRUDDULLLULRLUDUDUDRLLUUUULLUDLUUUUDULLUURDLLRDUDLRUDRUDDURURRURUDLLLRLDLUDRRRRRRDLUURLRDDDULRRUDRULRDRDDUULRDDLDULDRRRDDLURRURLLLRURDULLRUUUDDUDUURLRLDDUURLRDRRLURLDRLLUUURDRUUDUUUDRLURUUUDLDRRLRLLRRUURULLLRLLDLLLDULDDLDULDLDDRUDURDDURDUDURDLLLRRDDLULLLUDURLUDDLDLUUDRDRUDUUDLLDDLLLLDRDULRDLDULLRUDDUULDUDLDDDRUURLDRRLURRDDRUUDRUDLLDLULLULUDUDURDDRLRDLRLDRLDDRULLLRUDULDRLRLRULLRLLRRRLLRRRDDRULRUURRLLLRULDLUDRRDDLLLUDDUDDDLURLUDRDLURUUDLLDLULURRLLDURUDDDDRLULRDDLRLDDLRLLDDRRLRDUDUUULRRLRULUDURDUDRLRLRUDUDLLRRRRLRRUDUL");
            instructions.Add("RULLLLUUUDLLDLLRULLRURRULDDRDLUULDRLLRUDLLRRLRDURLLDUUUUURUUURDLUURRLDDDLRRRRLRULDUDDLURDRRUUDLRRRDLDDUDUDDRUDURURLDULLDLULDLLUDLULRDRLLURRLLDURLDLRDLULUDDULDLDDDDDUURRDRURLDLDULLURDLLDDLLUDLDLDRLRLDLRDRLDLRRUUDRURLUUUDLURUULDUDRDULLDURUDLUUURRRLLDUDUDDUUULLLRUULDLURUDDRLUDRDDLDLLUDUDRRRDDUUULUULLLRLLUURDUUDRUUULULLDLDRUUDURLLUULRLDLUURLLUUDRURDDRLURULDUDUUDRRUUURDULRLDUUDDRURURDRRULDDDRLUDLLUUDURRRLDLRLRDRURLURLLLRLDDLRRLDLDDURDUUDRDRRLDRLULDRLURUUUDDRLLLDDLDURLLLLDRDLDRRUDULURRLULRDRLLUULLRLRDRLLULUURRUDRUDDDLLDURURLURRRDLLDRDLUDRULULULRLDLRRRUUDLULDURLRDRLULRUUURRDDLRUURUDRURUDURURDD");
            instructions.Add("DURRDLLLDDLLDLLRLULULLRDLDRRDDRDLRULURRDUUDDRLLDDLDRRLRDUDRULDLRURDUUDRDDLLDRRDRUDUDULLDDDDLDRRRLRLRDRDLURRDDLDDDUUDRDRLLLDLUDDDLUULRDRLLLRLLUULUDDDRLDUUUURULRDDURRDRLUURLUDRLRLLLDDLRDDUULRRRRURDLDDDRLDLDRRLLDRDDUDDUURDLDUUDRDLDLDDULULUDDLRDDRLRLDDLUDLLDRLUDUDDRULLRLDLLRULRUURDDRDRDRURDRRLRDLLUDDRRDRRLDDULLLDLUDRRUDLDULDRURRDURLURRLDLRDLRUDLULUDDRULRLLDUURULURULURRLURRUULRULRRRLRDLULRLRLUDURDDRUUURDRLLRRRDDLDRRRULLDLRDRULDRRLRRDLUDDRDDDUUURRLULLDRRUULULLRRRRLDDRDDLUURLLUDLLDUDLULUULUDLLUUURRRUDDDRLLLRDRUUDUUURDRULURRLRDLLUURLRDURULDRRUDURRDDLDRLDRUUDRLLUDLRRU");
            foreach (string instruction in instructions)
            {
                Tuple<int, int> newPosition = GoToPosition(start, array2Da, instruction);
                Console.Write(array2Da[newPosition.Item2, newPosition.Item1]);
                start = newPosition;
            }
            Console.ReadLine();
        }

        public static Tuple<int, int> GoToPosition(Tuple<int, int> startPosition, char[,] array, string instruction)
        {
            int leftRight = startPosition.Item1;
            int upDown = startPosition.Item2;

            int potLr;
            int potUd;
            for(int i =0; i<instruction.Length; i++)
            {
                switch (instruction[i])
                {
                    case 'D':
                        potUd = Math.Min(6, upDown + 1);
                        if (array[potUd, leftRight] != ' ')
                        {
                            upDown = potUd;
                        }
                        break;
                    case 'U':
                        potUd = Math.Max(0, upDown - 1);
                        if (array[potUd, leftRight] != ' ')
                        {
                            upDown = potUd;
                        }
                        break;
                    case 'L':
                        potLr = Math.Max(0, leftRight - 1);
                        if (array[upDown, potLr] != ' ')
                        {
                            leftRight = potLr;
                        }
                        break;
                    case 'R':
                        potLr = Math.Min(6, leftRight + 1);
                        if (array[upDown, potLr] != ' ')
                        {
                            leftRight = potLr;
                        }
                        break;
                    default:
                        break;
                }
            }
            Tuple<int, int> result = new Tuple<int, int>(leftRight, upDown);
            return result;
        }
    }
}
