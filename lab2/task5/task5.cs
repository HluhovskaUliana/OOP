using System;

class task5
{
     static void Main()
     {
        Console.Write("Enter first character array: ");
        char[] array1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        
        Console.Write("Enter second character array: ");
        char[] array2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        
        int result = CompareCharArrays(array1, array2);

        if (result < 0)
        {
            Console.WriteLine("First array is lexicographically smaller.");
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i]);
            }
        } else if (result > 0)
        {
            Console.WriteLine("Second array is lexicographically smaller.");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i]);
            }
        }
        else
        {
            Console.WriteLine("Array are equal.");
        }

        Console.ReadKey();
     }

     static int CompareCharArrays(char[] array1, char[] array2)
     {
         int minLength = Math.Min(array1.Length, array2.Length);
         
         for (int i = 0; i < minLength; i++)
         {
             if (array1[i] < array2[i])
             {
                 return -1;
             } else if (array1[i] > array2[i])
             {
                 return 1;
             }
         }

         if (array1.Length > array2.Length)
         {
             return -1;
         } else if (array2.Length > array1.Length)
         {
             return 1;
         }
         else
         {
             return 0;
         }
     }
}