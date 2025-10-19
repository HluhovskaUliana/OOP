using System;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {value}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Box<int> intBox = new Box<int>(123123);//перевірка 1 завд.
        Console.WriteLine(intBox.ToString());

        Box<string> stringBox = new Box<string>("life in a box");
        Console.WriteLine(stringBox.ToString());

        int n = int.Parse(Console.ReadLine());//перевірка 2 завд.

        List<Box<string>> boxes = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            boxes.Add(new Box<string>(input));
        }

        foreach (Box<string> box in boxes)
        {
            Console.WriteLine(box.ToString());
        }
        
        int num = int.Parse(Console.ReadLine());//перевірка 2 завд.

        List<Box<int>> numBoxes = new List<Box<int>>();

        for (int i = 0; i < num; i++)
        {
            int input = int.Parse(Console.ReadLine());
            numBoxes.Add(new Box<int>(input));
        }

        foreach (Box<int> numBox in numBoxes)
        {
            Console.WriteLine(numBox.ToString());
        }

        Console.ReadKey();
    }
}