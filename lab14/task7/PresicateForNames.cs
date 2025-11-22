using System;
using System.Linq;
using System.Collections.Generic;

public class PredicateForNames
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // [cite: 48]
        
        List<string> names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        
        Predicate<string> lengthFilter = name => name.Length <= n;
        
        List<string> filteredNames = names.FindAll(lengthFilter);

        Action<string> printName = name => Console.WriteLine(name);
        filteredNames.ForEach(printName);
        Console.ReadKey();
    }
}