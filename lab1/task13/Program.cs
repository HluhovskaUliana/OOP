﻿using System;

class Program
{
    static void Main()
    {
        int n;
        bool result;
        
        Console.Write("Enter the number: ");
        n = int.Parse(Console.ReadLine());

        result = (n % 9 == 0 || n % 11 == 0 || n % 13 == 0);
        
        Console.WriteLine($"Result: {result}");
        Console.ReadKey();
    }
}