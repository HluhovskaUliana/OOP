using System;

class task1
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public task1()
    {
        name = "Unknown";
        age = 0;
    }

    public task1(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        task1 defaultTask1 = new task1();
        defaultTask1.Name = "Pesho";
        defaultTask1.Age = 20;

        task1 person1 = new task1("Gosho", 18);
        task1 person2 = new task1("Stamat", 43);
        
        Console.WriteLine($"{defaultTask1.Name} {defaultTask1.Age}");
        Console.WriteLine($"{person1.Name} {person1.Age}");
        Console.WriteLine($"{person2.Name} {person2.Age}");
        Console.ReadKey();
    }
}