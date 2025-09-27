using System;
using System.Collections.Generic; // для використання List<T> (черг стеків і тп.)
using System.Linq; // підключення LINQ - мови запитів (фільтрація, сортування і тп.)

public class Person
{
    public string Name { get; set; } 
    public int Age {get; set;} 

    public Person() : this("no name", 1) { }
    public Person(string name) : this(name, 1) { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person member)
    {
        members.Add(member);
    }
    public Person GetOldestMember()
    {
        return members.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number of members");
        int num = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            int age = int.Parse(input[1]);
            
            Person person = new Person(name, age);
            family.AddMember(person);
        }
        Person oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        Console.ReadKey();
        
    }
}