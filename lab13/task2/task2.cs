using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student { FirstName = "Sara", LastName = "Mills" },
            new Student { FirstName = "Andrew", LastName = "Gibson" },
            new Student { FirstName = "Craig", LastName = "Ellis" },
            new Student { FirstName = "Steven", LastName = "Cole" },
            new Student { FirstName = "Andrew", LastName = "Carter" }
        };

        var filtered = students
            .Where(s => string.Compare(s.FirstName, s.LastName, StringComparison.Ordinal) < 0);

        foreach (var student in filtered)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}