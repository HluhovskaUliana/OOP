using System;
using System.Collections.Generic;

public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }

    public int CompareTo(Box<T> other)
    {
        return Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

class Program
{
    public static int CountGreaterThan<T>(List<Box<T>> list,  Box<T> element) where T :IComparable<T>
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public static void Main()
    {
        Console.Write("Task 6:");
        int n = int.Parse(Console.ReadLine());
        var list = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            list.Add(new Box<string>(input));
        }
        
        Console.Write($"Enter value: ");
        string comparisonValue = Console.ReadLine();
        var comparisonBox = new Box<string>(comparisonValue);
        
        int result = CountGreaterThan(list, comparisonBox);
        Console.WriteLine(result);
        
        Console.Write("task 7:");
        int num = int.Parse(Console.ReadLine());
        var NumList = new List<Box<double>>();

        for (int i = 0; i < n; i++)
        {
            double input = double.Parse(Console.ReadLine());
            NumList.Add(new Box<double>(input));
        }

        double numComparisonValue = double.Parse(Console.ReadLine());
        var numComparisonBox = new Box<double>(numComparisonValue);

        int numResult = CountGreaterThan(NumList, numComparisonBox);
        Console.WriteLine(numResult);
        Console.ReadKey();

        Console.ReadKey();
    }
}