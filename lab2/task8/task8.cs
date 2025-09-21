using System;

class task8
{
    static void Main()
    {
        Console.Write("Enter a sequence of numbers: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxCount = 0;
        int result = array[0];

        foreach (int num in array.Distinct())
        {
            int count = array.Count(x => x == num);
            if (count > maxCount || count == maxCount && Array.IndexOf(array, num) < Array.IndexOf(array, result))
            {
                maxCount = count;
                result = num;
            } 
        }
        Console.WriteLine($"Most frequent number: {result} ({maxCount})");
        Console.ReadKey();
    }
}