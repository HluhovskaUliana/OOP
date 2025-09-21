using System;

class task7
{
    static void Main()
    {
        Console.Write("Enter a sequence of numbers: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int bestLen = 1;
        int bestStart = 0;
        
        int currentLen = 1;
        int currentStart = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1] + 1)
            {
                currentLen++;
            }
            else
            {
                currentStart = i;
                currentLen = 1;
            }

            if (currentLen > bestLen)
            {
                bestLen = currentLen;
                bestStart = currentStart;
            }
        }
        
        Console.WriteLine("longest sequence: ");
        for (int i = bestStart; i < bestStart + bestLen; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.ReadKey();
    }
}