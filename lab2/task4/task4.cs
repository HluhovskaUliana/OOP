using System;

class task4 {
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        
        bool[] primes = new bool[number + 1];
        for (int i = 0; i <= number; i++)
        {
            primes[i] = true;
        }
        
        primes[0] = false;
        primes[1] = false;

        for (int p = 2; p * p <= number; p++)
        {
            if (primes[p])
            {
                for (int multiple = p * 2; multiple <= number; multiple += p)
                {
                    primes[multiple] = false;
                }
            }
        }
        
        Console.WriteLine($"Prime numbers up to {number}");
        for (int i = 2; i <= number; i++)
        {
            if (primes[i])
            {
                Console.Write(i + " ");
            }
        }

        Console.ReadKey();
    }
}