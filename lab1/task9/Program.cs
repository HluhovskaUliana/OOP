using System;

class Program
{
    static void Main()
    {
        int a, b, h, area;
       
        Console.Write("Enter a: ");
        a = int.Parse(Console.ReadLine());
        
        Console.Write("Enter b: ");
        b = int.Parse(Console.ReadLine());
        
        Console.Write("Enter h: ");
        h = int.Parse(Console.ReadLine());

        area = ((a + b) / 2)* h;
        Console.WriteLine(area);
        Console.ReadKey();
    }
}
