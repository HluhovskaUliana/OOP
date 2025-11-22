using System;
using System.Collections.Generic;
using System.Linq;

public class ReverseAndExclude
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        
        int n = int.Parse(Console.ReadLine());
        
        Predicate<int> isDivisible = x => x % n == 0; 

        
        List<int> result = numbers
            .AsEnumerable()
            .Reverse() 
            .Where(x => !isDivisible(x)) 
            .ToList();
        
        Console.WriteLine(string.Join(" ", result));
        Console.ReadKey();
    }
}