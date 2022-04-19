using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace TranslateLangPack
{
    internal class Program
    {
        private static Encoding encoding = Encoding.GetEncoding(1200);

        private static void Main(string[] args)
        {
            Dictionary<string, LangPack> ruList = Download("LangPackRU.tsv", 5);
            Dictionary<string, LangPack> krList = Download("LangPackKR.tsv", 0);

            Console.WriteLine("Lang Pack RU: " + ruList.Count);
            Console.WriteLine("Lang Pack KR: " + krList.Count);
            Console.WriteLine("Успешно загружено");

            foreach (KeyValuePair<string, LangPack> item in krList)
            {
                if (ruList.TryGetValue(item.Key, out LangPack langPack))
                {
                    item.Value.Text = langPack.Text;
                }
            }

            Console.WriteLine("Успешно переведено");

            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, LangPack> item in krList)
            {
                stringBuilder.Append("\"" + item.Value.NumberOne + "\"\t\"" + item.Value.NumberTwo + "\"\t\"" + item.Value.NumberThree + "\"\t\"" + item.Value.Code + "\"\t\"" + item.Value.Text + "\"" + Environment.NewLine);
            }

            byte[] resultBytes = GetBytesByString(stringBuilder.ToString());

            File.WriteAllBytes("LangPackRU_new.tsv", resultBytes);

            Console.WriteLine("Успешно записано в файл: LangPackRU_new.tsv");

            for (int number = 3; number > 0; number--)
            {
                Console.WriteLine("Завершение программы " + number);
                Thread.Sleep(1000);
            }

            Environment.Exit(0);
        }

        private static Dictionary<string, LangPack> Download(string nameFile, int nation)
        {
            byte[] bytes = File.ReadAllBytes(nameFile);
            string file = encoding.GetString(bytes);

            List<string> lines = new List<string>();

            int index = 0;
            while (true)
            {
                int nextLine = file.IndexOf("\r\n\"" + nation + "\"", index);

                if (nextLine == -1)
                {
                    lines.Add(file.Substring(index, file.Length - index));
                    break;
                }

                lines.Add(file.Substring(index, nextLine + 2 - index));

                index = nextLine + 2;
            }

            Dictionary<string, LangPack> langPacks = new Dictionary<string, LangPack>();

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];

                LangPack langPack = new LangPack
                {
                    NumberOne = GetTextFromQuotationMark(ref line),
                    NumberTwo = GetTextFromQuotationMark(ref line),
                    NumberThree = GetTextFromQuotationMark(ref line),
                    Code = GetTextFromQuotationMark(ref line),
                    Text = GetTextFromQuotationMark(ref line, true)
                };

                string key = langPack.NumberTwo + "-" + langPack.NumberThree + "-" + langPack.Code;

                langPacks.Add(key, langPack);
            }

            return langPacks;
        }

        private static string GetTextFromQuotationMark(ref string input, bool last = false)
        {
            int firstMark = input.IndexOf('"');
            int twoMark;

            if (!last)
            {
                twoMark = input.IndexOf('"', firstMark + 1);
            }
            else
            {
                twoMark = input.LastIndexOf('"');
            }

            string text = input.Substring(firstMark + 1, twoMark - firstMark - 1);

            input = input.Substring(twoMark + 1);
            return text;
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