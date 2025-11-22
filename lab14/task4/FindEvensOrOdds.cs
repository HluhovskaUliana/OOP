using System;
using System.Collections.Generic;
using System.Linq;

public class FindEvensOrOdds
{
    public static void Main()
    {
        int[] limits = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int lower = limits[0];
        int upper = limits[1];
        
        string command = Console.ReadLine();
        
        List<int> numbers = Enumerable.Range(lower, upper - lower + 1).ToList();
        
        Predicate<int> filterPredicate;

        if (command == "odd")
        {
            filterPredicate = x => x % 2 != 0;
        }
        else if (command == "even")
        {
            filterPredicate = x => x % 2 == 0;
        }
        else
        {
            return;
        }
        
        List<int> result = numbers.FindAll(filterPredicate);
        
        Console.WriteLine(string.Join(" ", result));
        Console.ReadKey();
    }
}