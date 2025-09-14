using System;

class task2
{
    static void Main()
    {
        Console.WriteLine("Enter an array of numbers: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        Console.Write("Enter the numbers of revolutions: ");
        int k = int.Parse(Console.ReadLine());
        
        int[] sum = new int[numbers.Length];
        for (int i = 0; i < k; i++)
        {
            int last = numbers[numbers.Length - 1];
            for (int j = numbers.Length - 1; j > 0; j--)
            {
                numbers[j] = numbers[j - 1];
            }
            numbers[0] = last;
            
            for (int j = 0; j < numbers.Length; j++)
            {
                Console.Write(numbers[j] + " ");
            }
            Console.WriteLine();

            for (int j = 0; j < numbers.Length; j++)
            {
                sum[j] +=  numbers[j];
            }
        }
        
        Console.WriteLine("Result after rotation: ");
        for (int i = 0; i < sum.Length; i++)
        {
            Console.Write(sum[i] + " ");
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
