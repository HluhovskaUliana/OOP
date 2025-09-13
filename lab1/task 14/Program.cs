using System;

class Program
{
    static void Main()
    {
        int numberA, numberB, numberC;
        
        Console.Write("Enter numberA: ");
        numberA = int.Parse(Console.ReadLine());
        Console.Write("Enter numberB: ");
        numberB = int.Parse(Console.ReadLine());
        Console.Write("Enter numberC: ");
        numberC = int.Parse(Console.ReadLine());

        int max;
        if (numberA > numberB && numberA > numberC)
        {
            max = numberA;
        } else if (numberB > numberA && numberB > numberC)
        {
            max = numberB;
        }
        else
        {
            max = numberC;
        }
        
        Console.WriteLine($"Max: {max}");
        Console.ReadKey();
    }
}

