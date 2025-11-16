namespace EvenLines
{
    using System;
    using System.IO;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
            Console.ReadKey();
        }

        public static string ProcessLines(string inputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };
            string result = "";

            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 0) // парні рядки (0, 2, 4…)
                {
                    string line = lines[i];

                    foreach (char symbol in symbolsToReplace)
                    {
                        line = line.Replace(symbol, '@');
                    }

                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(words);
                    result += string.Join(' ', words) + " ";
                }
            }

            return result.Trim();
        }
    }
}