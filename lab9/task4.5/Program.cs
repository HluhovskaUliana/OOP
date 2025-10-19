using System;
using System.Collections.Generic;

class Program
{
    public static void SwapElemnts<T>(List<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }

    static void Main()
    {
        Console.Write("Test task 4: ");
        int n = int.Parse(Console.ReadLine());
        
        List<string> items = new List<string>();
        for (int i = 0; i < n; i++)
        {
            items.Add(Console.ReadLine());
        }
        
        string[] indices = Console.ReadLine().Split(' ');
        int index1 = int.Parse(indices[0]);
        int index2 = int.Parse(indices[1]);
        
        SwapElemnts(items, index1, index2);

        foreach (string item in items)
        {
            Console.WriteLine($"System.String: {item}");
        }
        
        Console.Write("Test task 5: ");
        int num = int.Parse(Console.ReadLine());
        
        List<int> numItems = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numItems.Add(int.Parse(Console.ReadLine()));
        }
        
        string[] numIndices = Console.ReadLine().Split(' ');
        int i1 = int.Parse(numIndices[0]);
        int i2 = int.Parse(numIndices[1]);
        
        SwapElemnts(numItems, index1, index2);

        foreach (int numItem in numItems)
        {
            Console.WriteLine($"System.String: {numItem}");
        }
        
        Console.ReadKey();
        
        
        
    }
}