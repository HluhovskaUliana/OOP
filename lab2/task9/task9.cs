using System;

class task9
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('a' + i);
        }
        
        Console.WriteLine("Enter a word: ");
        string word = Console.ReadLine();

        foreach (char latter in word)
        {
            int index = Array.IndexOf(alphabet, latter);
            Console.WriteLine($"{latter} -> {index} ");
        }
        Console.ReadKey();
    }
}