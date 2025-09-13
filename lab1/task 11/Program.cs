using System;

class Program
{
    static void Main()
    {
        int number, n, nDigit;
        
        Console.Write("Enter the number: ");
        number = int.Parse(Console.ReadLine());
        
        Console.Write("Enter the n: ");
        n = int.Parse(Console.ReadLine());
        
        if (n > number.ToString().Length) 
        {
            Console.WriteLine("-");
        }
        else
        {
            nDigit = (number / (int)Math.Pow(10, n - 1)) % 10;
            Console.WriteLine("Digit number " + n + " is: " + nDigit);
        }
        Console.ReadKey();
    }
}