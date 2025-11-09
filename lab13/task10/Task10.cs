using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Group { get; set; }
}

class Task10
{
    static void Main()
    {
        var people = new List<Person>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Trim().ToUpper() == "END") break;

            var parts = input.Split(' ');
            if (parts.Length >= 3 && int.TryParse(parts[2], out int group))
            {
                string name = $"{parts[0]} {parts[1]}";
                people.Add(new Person { Name = name, Group = group });
            }
            else
            {
                Console.WriteLine("Invalid input. Please use: FirstName LastName GroupNumber");
            }
        }

        Console.WriteLine("\nGrouped students:");
        var grouped = people
            .GroupBy(p => p.Group)
            .OrderBy(g => g.Key);

        foreach (var group in grouped)
        {
            string names = string.Join(", ", group.Select(p => p.Name));
            Console.WriteLine($"{group.Key} - {names}");
        }
        Console.ReadKey();
    }
}