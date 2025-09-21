using System;

class task10
{
    static void Main()
    {
        Console.WriteLine("Enter a sequence of numbers: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        Console.WriteLine("Enter the difference: ");
        int diff = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (Math.Abs(array[i] - array[j]) == diff)
                {
                    count++;
                }
            }
        }
        
        Console.WriteLine($"Count of pairs: {count}");
        Console.ReadKey();
    }
}