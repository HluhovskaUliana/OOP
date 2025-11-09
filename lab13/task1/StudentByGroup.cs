using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Group  { get; set; }
}

class StudentByGroup
{
    static void Main()
    {
        var students = new List<Student>();
        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            var parts = input.Split(' ');
            students.Add(new Student()
            {
                FirstName = parts[0], LastName = parts[1], Group = int.Parse(parts[2])
            });
        }
        
        var groupStudents = students.Where(s => s.Group == 2).OrderByDescending(s => s.FirstName);

        foreach (var student in groupStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        Console.ReadKey();
    }
}