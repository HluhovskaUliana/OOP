using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\actualResults.txt";
            
            ProcessWordCount(wordsFilePath, textFilePath, outputFilePath);
            Console.WriteLine("Word count completed.");
            Console.ReadKey();
        }

        public static void ProcessWordCount(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] wordsToCount = File.ReadAllLines(wordsFilePath);
            string text = File.ReadAllText(textFilePath).ToLower();
            
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in wordsToCount)
            {
                string trimmedWord = word.Trim().ToLower();
                int count = text.Split(new[] { ' ', '-', ',', '.', '!', '?', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Count(w => w == trimmedWord);
                wordCounts[trimmedWord] = count;
            }
            
            var sortedResults = wordCounts.OrderByDescending(kvp => kvp.Value);

            List<string> outputLines = sortedResults
                .Select(kvp => $"{kvp.Key} - {kvp.Value}")
                .ToList();

            File.WriteAllLines(outputFilePath, outputLines);

        }
    }
}
