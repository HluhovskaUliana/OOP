using System;
using System.Linq;

public class ActionPoint
{
    public static void Main()
    {
        string[] names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

       
        Action<string> printName = name => Console.WriteLine(name); 
        names.ToList().ForEach(printName);
        Console.ReadKey();
    }
}