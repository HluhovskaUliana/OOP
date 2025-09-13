using System;

class Program
{
    static void Main()
    {
        double a, b, c;
        Console.Write("Enter A: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Enter B: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Enter C: ");
        c = double.Parse(Console.ReadLine());

        string product;
        int negativeCount = 0;
        if (a < 0) { negativeCount++; }
        if (b < 0) { negativeCount++; }
        if (c < 0) { negativeCount++; }

        if (negativeCount == 0 || negativeCount == 2)
        {
            product = "Positive";
            Console.WriteLine(product);
        } else
        {
            product = "Negative";
            Console.WriteLine(product);
        }
        Console.ReadKey();
    }
}