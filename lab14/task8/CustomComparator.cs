using System;
using System.Linq;
using System.Collections.Generic;

public class CustomComparator
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        
        Comparison<int> customComparator = (x, y) =>
        {
            bool xIsEven = x % 2 == 0;
            bool yIsEven = y % 2 == 0;

            if (xIsEven && !yIsEven)
            {
                return -1;
            }
            else if (!xIsEven && yIsEven)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        };
        
        numbers.Sort(customComparator); 

        Console.WriteLine(string.Join(" ", numbers));
        Console.ReadKey();
    }
}