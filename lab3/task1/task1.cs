using System;

class Person
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

    public Person() //task2
    {
        name = "no name";
        age = 1;
    }
    public Person(int age)
    {
        name = "no name"; //task2
        this.age = age;
    }

    public Person(string name, int age) //task2
    {
        this.name = name;
        this.age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person defaultTask1 = new Person();
        defaultTask1.Name = "Pesho";
        defaultTask1.Age = 20;

        Person person1 = new Person("Gosho", 18);
        Person person2 = new Person("Stamat", 43);
        
        Console.WriteLine($"{defaultTask1.Name} {defaultTask1.Age}");
        Console.WriteLine($"{person1.Name} {person1.Age}");
        Console.WriteLine($"{person2.Name} {person2.Age}");
        Console.ReadKey();
    }
}