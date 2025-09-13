using System;

class Program
{
    static void Main()
    {
        int a, b, c;
        double average;

        Console.Write("Enter a number: ");
        a = int.Parse(Console.ReadLine());

        Console.Write("Enter b number: ");
        b = int.Parse(Console.ReadLine());

        Console.Write("Enter c number: ");
        c = int.Parse(Console.ReadLine());

        average = (a + b + c) / 3.0;

        Console.Write("Average: " + average);
        Console.ReadKey();
    }
}
