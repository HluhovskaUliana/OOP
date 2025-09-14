using System;

class task3
{
    static void Main()
    {
        int[] numbers;  
        do
        {
            Console.WriteLine("Enter an array of numbers that are divisible by 4: ");
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (numbers.Length % 4 != 0)
            {
                Console.WriteLine("You entered an array of numbers that are not divisible by 4");
            }
        } while (numbers.Length % 4 != 0);
        Console.ReadLine();
        
        int k = numbers.Length / 4;
        
        int[] leftFold = new int[k];
        int[] rightFold = new int[k];
        
        for (int i = 0; i < k; i++)
        {
            leftFold[i] = numbers[k - 1 - i];
            rightFold[i] = numbers[numbers.Length - 1 - i];
        }
        
        int[] topRow = new int[2 * k];
        for (int i = 0; i < k; i++)
        {
            topRow[i] = leftFold[i];
            topRow[i + k] = rightFold[i];
        }
        
        
    }
}