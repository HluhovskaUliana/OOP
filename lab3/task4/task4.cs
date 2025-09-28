using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }

    public Employee(string name, decimal salary, string position, string department) 
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a";
        Age = null;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department)
    {
        Email = email;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
        : this(name, salary, position, department, email)
    {
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter number of employees: ");
        int num = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Enter information about the employee {i+1}: ");
            string[]  tokens = Console.ReadLine().Split(' ');
            
            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];

            Employee employee;
            if (tokens.Length == 4)
            {
                employee = new Employee(name, salary, position, department);
            } 
            else if (tokens.Length == 5)
            {
                if (tokens[4].Contains("@"))
                    employee = new Employee(name, salary, position, department, tokens[4]);
                else
                    employee = new Employee(name, salary, position, department, "n/a", int.Parse(tokens[4]));
            }
            else
            {
                employee = new Employee(name, salary, position, department, tokens[4], int.Parse(tokens[5]));
            }
            employees.Add(employee);
        }
        
        var bestDepartment = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(g => g.Average(e => e.Salary))
            .First();
        
        Console.WriteLine($"Highest Average Salary: {bestDepartment.Key}");
        foreach (var employee in bestDepartment.OrderByDescending(e => e.Salary))
        {
            string emailOutput = string.IsNullOrEmpty(employee.Email) ? "n/a" : employee.Email;
            string ageOutput = employee.Age.HasValue ? employee.Age.Value.ToString() : "-1";
            
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {emailOutput} {ageOutput}");
        }
        Console.ReadKey();
    }
}