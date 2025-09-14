using System;

class task1
{
    static void Main()
    {
        Console.WriteLine("Enter the firs sentence: ");
        string[] words1 =  Console.ReadLine().Split(' ');
        
        Console.WriteLine("Enter the seconds sentence: ");
        string[] words2 = Console.ReadLine().Split(' ');
        
        int minLength = Math.Min(words1.Length, words2.Length);
        int leftCount = 0;
        int rightCount = 0;

        for (int i = 0; i < minLength; i++)
        {
            if (words1[i] == words2[i])
                leftCount++;
            else
                break;
        }

        for (int i = 1; i <= minLength; i++)
        {
            if (words1[words1.Length - i] == words2[words2.Length - i])
                rightCount++;
            else
                break;
        }

        if (leftCount > rightCount)
        {
            Console.Write($"The largest common end on the left: ");
            for (int i = 0; i < leftCount; i++)
            {
                Console.Write(words1[i] + " ");
            }
            Console.WriteLine();
        }
        else if (rightCount > leftCount)
        {
            Console.Write($"The largest common end on the right: ");
            for (int i = minLength - rightCount; i < minLength; i++)
            {
                Console.Write(words2[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"There are no common words on the left and right");
        }
        Console.ReadLine();
    }
}