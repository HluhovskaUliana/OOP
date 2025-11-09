using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName;
    public string LastName;
    public int Group;
    public int Age; //для 3
    public string Email;//для 5
    public string Phone; //для 6
    public List<int> Marks; //для 7,8,9
    public string FacultyNumber;//9
}

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student { FirstName = "Sara", LastName = "Mills", Group = 1, Age = 24, Email = "smills@gmail.com", Phone = "02435521", Marks = new List<int>{6,6,6,5}, FacultyNumber = "554214" },
            new Student { FirstName = "Andrew", LastName = "Gibson", Group = 2, Age = 21, Email = "agibson@abv.bg", Phone = "0895223344", Marks = new List<int>{3,4,5,6}, FacultyNumber = "653215" },
            new Student { FirstName = "Craig", LastName = "Ellis", Group = 1, Age = 19, Email = "cellis@cs.edu.gov", Phone = "+3592667710", Marks = new List<int>{4,2,3,4}, FacultyNumber = "156212" },
            new Student { FirstName = "Steven", LastName = "Cole", Group = 2, Age = 35, Email = "themachine@abv.bg", Phone = "3242133312", Marks = new List<int>{5,6,5,5}, FacultyNumber = "324413" },
            new Student { FirstName = "Andrew", LastName = "Carter", Group = 2, Age = 15, Email = "ac147@gmail.com", Phone = "+001234532", Marks = new List<int>{5,3,4,2}, FacultyNumber = "134014" }
        };

        while (true)
        {
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "end") break;

            if (!int.TryParse(input, out int task) || task < 1 || task > 9)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                continue;
            }

            switch (task)
            {
                case 1:
                    var group2 = students
                        .Where(s => s.Group == 2)
                        .OrderBy(s => s.FirstName);
                    foreach (var s in group2)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 2:
                    var nameBeforeSurname = students
                        .Where(s => string.Compare(s.FirstName, s.LastName, StringComparison.Ordinal) < 0);
                    foreach (var s in nameBeforeSurname)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 3:
                    var ageRange = students
                        .Where(s => s.Age >= 18 && s.Age <= 24);
                    foreach (var s in ageRange)
                        Console.WriteLine($"{s.FirstName} {s.LastName} {s.Age}");
                    break;

                case 4:
                    var sorted = students
                        .OrderBy(s => s.LastName)
                        .ThenByDescending(s => s.FirstName);
                    foreach (var s in sorted)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 5:
                    var gmail = students
                        .Where(s => s.Email.EndsWith("@gmail.com"));
                    foreach (var s in gmail)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 6:
                    var sofiaPhones = students
                        .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"));
                    foreach (var s in sofiaPhones)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 7:
                    var excellent = students
                        .Where(s => s.Marks.Contains(6));
                    foreach (var s in excellent)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 8:
                    var weak = students
                        .Where(s => s.Marks.Count(m => m <= 3) >= 2);
                    foreach (var s in weak)
                        Console.WriteLine($"{s.FirstName} {s.LastName}");
                    break;

                case 9:
                    var enrolled = students
                        .Where(s => s.FacultyNumber.Length >= 6 &&
                                    (s.FacultyNumber.Substring(4, 2) == "14" || s.FacultyNumber.Substring(4, 2) == "15"));
                    foreach (var s in enrolled)
                        Console.WriteLine(string.Join("", s.Marks));
                    break;
            }
        }

        Console.ReadKey();
    }
}
