using System;

class Program
{
    static void Main()
    {
        int n;
        bool result;
        
        Console.Write("Enter the number: ");
        n = int.Parse(Console.ReadLine());

        result = (n > 20 && n % 2 != 0);
        
        Console.WriteLine($"Result: {result}");
        Console.ReadKey();
    }
}