using System;
using System.Linq;

public class KnightsOfHonor
{
    public static void Main()
    {
        string[] names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        Action<string> printSirName = name => Console.WriteLine($"Sir {name}"); 
        
        names.ToList().ForEach(printSirName);
        Console.ReadKey();
    }
}