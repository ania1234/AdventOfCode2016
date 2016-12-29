using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day5
    {
        public static void Exercise2()
        {
            string start = "uqwqemis";
            char[] pass = new char[8] { '_', '_', '_', '_', '_', '_', '_', '_' };
            int usedNumbers = 0;
            long i = 3231929;
            while (usedNumbers < 8)
            {
                string passAmended = start + i.ToString();
                string passEncrypted = MD5Encrypt(passAmended);
                if ((passEncrypted).StartsWith("00000"))
                {
                    if (char.IsNumber(passEncrypted[5]))
                    {
                        if (Int32.Parse(passEncrypted[5].ToString()) < 8 && pass[Int32.Parse(passEncrypted[5].ToString())] == '_')
                        {
                            pass[Int32.Parse(passEncrypted[5].ToString())] = passEncrypted[6];
                            for (int l = 0; l < 8; l++)
                            {
                                Console.Write(pass[l]);
                            }
                            usedNumbers++;
                            Console.WriteLine();
                        }
                    }
                }
                i++;
            }
            Console.WriteLine(pass);
            Console.ReadLine();
        }
        public static void Exercise1()
        {
            string start = "uqwqemis";
            string pass = "";
            long i = 3231929;
            while (pass.Length < 8)
            {
                string passAmended = start + i.ToString();
                string passEncrypted = MD5Encrypt(passAmended);
                if ((passEncrypted).StartsWith("00000"))
                {
                    pass += passEncrypted[5];
                    Console.WriteLine(pass);
                }
                i++;
            }
            Console.WriteLine(pass);
            Console.ReadLine();
        }

        static string HexEncode(string plainText)
        {
            byte[] ba = Encoding.Default.GetBytes(plainText);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;
        }

        public static string MD5Encrypt(string line)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(line);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
