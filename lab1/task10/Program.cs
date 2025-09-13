using System;

class Program
{
    static void Main()
    {
        double num, lastDigit;
        
        Console.Write("Enter the number: ");
        num = double.Parse(Console.ReadLine());
        
        lastDigit = num % 10;
        
        Console.Write("The last digit is: " + lastDigit);
        Console.ReadKey();
    }
}
