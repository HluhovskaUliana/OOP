using System;
using System.Collections.Generic;
using System.Linq;

class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }
}

class Student
{
    public string FacultyNumber { get; set; }
    public string FullName { get; set; }
}

class task11
{
    static void Main()
    {
        var specialties = new List<StudentSpecialty>();
        var students = new List<Student>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Trim() == "Students:") break;

            var parts = input.Split(' ');
            if (parts.Length >= 2)
            {
                string specialty = string.Join(" ", parts.Take(parts.Length - 1));
                string facNum = parts.Last();
                specialties.Add(new StudentSpecialty { SpecialtyName = specialty, FacultyNumber = facNum });
            }
        }

        Console.WriteLine("Enter students in format: <FacultyNumber> <FirstName> <LastName>");
        Console.WriteLine("Type 'END' to finish input.\n");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Trim().ToUpper() == "END") break;

            var parts = input.Split(' ');
            if (parts.Length == 3)
            {
                students.Add(new Student
                {
                    FacultyNumber = parts[0],
                    FullName = $"{parts[1]} {parts[2]}"
                });
            }
        }

        var joined = students
            .Join(specialties,
                  student => student.FacultyNumber,
                  specialty => specialty.FacultyNumber,
                  (student, specialty) => new
                  {
                      student.FullName,
                      student.FacultyNumber,
                      specialty.SpecialtyName
                  })
            .OrderBy(s => s.FullName);

        Console.WriteLine("\nJoined students with specialties:");
        foreach (var item in joined)
        {
            Console.WriteLine($"{item.FullName} {item.FacultyNumber} {item.SpecialtyName}");
        }

        Console.ReadKey();
    }
}