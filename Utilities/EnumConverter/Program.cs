using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnumConverter
{
    internal class Program
    {
        private static Encoding encoding = Encoding.GetEncoding(1251);

        static void Main(string[] args)
        {
            string input = File.ReadAllText("Enum.txt");

            input = input.Replace("0x", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
            var inputArray = input.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var lines =inputArray.Select(item => item.Split('=')).ToDictionary(s => s[0], s => int.Parse(s[1], System.Globalization.NumberStyles.HexNumber));

            string result = "";

            int counter = 0;
            foreach (var item in lines)
            {
                result += item.Key + " = " + item.Value;
                if (lines.Count - 1 > counter)
                {
                    result += ",\r\n";
                }

                counter++;
            }

            //byte[] resultBytes = GetBytesByString(result);
            File.WriteAllText("EnumNew.txt", result);


            Console.WriteLine("Done!");
        }

        private static byte[] GetBytesByString(string text)
        {
            byte[] bytesString = encoding.GetBytes(text);
            byte[] resultArray = new byte[2 + bytesString.Length];

            resultArray[0] = 0xFF;
            resultArray[1] = 0xFE;

            bytesString.CopyTo(resultArray, 2);

            return resultArray;
        }
    }
}
