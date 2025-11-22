using System;
using System.Linq;

public class CustomMinFunction
{
    public static void Main()
    {
        
        int[] numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Func<int[], int> minFunction = arr => arr.Min();
        
        
        int minNumber = minFunction(numbers);
        Console.WriteLine(minNumber);
        Console.ReadKey();
    }
}