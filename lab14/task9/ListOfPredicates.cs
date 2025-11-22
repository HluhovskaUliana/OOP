using System;
using System.Collections.Generic;
using System.Linq;

public class ListOfPredicates
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] divisors = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray(); 

        List<Predicate<int>> predicates = new List<Predicate<int>>(); 
        foreach (int divisor in divisors)
        {
            predicates.Add(num => num % divisor == 0);
        }

        List<int> result = new List<int>();

        for (int number = 1; number <= N; number++)
        {
            bool isDivisibleByAll = true;
            foreach (var predicate in predicates)
            {
                if (!predicate(number))
                {
                    isDivisibleByAll = false;
                    break;
                }
            }

            if (isDivisibleByAll)
            {
                result.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", result));
        Console.ReadKey();
    }
}