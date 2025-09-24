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

    public Person()
    {
        name = "Unknown";
        age = 0;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person defaultPerson = new Person();
        defaultPerson.Name = "Pesho";
        defaultPerson.Age = 20;

        Person person1 = new Person("Gosho", 18);
        Person person2 = new Person("Stamat", 43);
        
        Console.WriteLine($"{defaultPerson.Name} {defaultPerson.Age}");
        Console.WriteLine($"{person1.Name} {person1.Age}");
        Console.WriteLine($"{person2.Name} {person2.Age}");
        Console.ReadKey();
    }
}