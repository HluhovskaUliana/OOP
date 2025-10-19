using System;
using System.Collections;

public static class Sorter //task9
{
    public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
    {
        list.SortInternal();
    }
}
public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();
    
    public void Add(T element) => items.Add(element);

    public T Remove(int index)
    {
        T element = items[index];
        items.RemoveAt(index);
        return element;
    }
    
    public bool Contains(T element) => items.Contains(element);

    public void Swap(int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
       int count = 0;
       foreach (var item in items)
       {
           if (item.CompareTo(element) > 0)
               count++;
       }
       return count;
    }
    
    public T Max() => items.Max();
    public T Min() => items.Min();

    public void Print()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void SortInternal() //task9
    {
        items.Sort();
    }
    
    // public IEnumerator<T> GetEnumerator() //task10
    // {
    //     foreach (var item in  items)
    //     {
    //         yield return item;
    //     }
    // }
    //
    // IEnumerator IEnumerable.GetEnumerator()
    // {
    //     return GetEnumerator();
    // }

}

public class Program
{
    public static void Main()
    {
        var list = new CustomList<string>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var parts = command.Split();
            string action = parts[0];

            switch (action)
            {
                case "Add":
                    list.Add(parts[1]);
                    break;
                case "Remove":
                    int index = int.Parse(parts[1]);
                    list.Remove(index);
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(parts[1]));
                    break;
                case "Swap":
                    int i1 = int.Parse(parts[1]);
                    int i2 = int.Parse(parts[2]);
                    list.Swap(i1, i2);
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(parts[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    list.Print();
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
            }
        }
    }
}