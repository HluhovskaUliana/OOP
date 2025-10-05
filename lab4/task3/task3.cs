using System;
using System.Collections.Generic;
using System.Linq;

class PatientEntry
{
    public string Department { get; set; }
    public string Doctor { get; set; }
    public string Patient { get; set; }
    public string Room { get; set; }
}

class PatientRegistry
{
    private List<PatientEntry> entries = new();

    public void AddEntry(string department, string doctorFullName, string patientName, string room)
    {
        entries.Add(new PatientEntry
        {
            Department = department,
            Doctor = doctorFullName,
            Patient = patientName,
            Room = room
        });
    }

    public void QueryDepartment(string department)
    {
        foreach (var entry in entries.Where(entry => entry.Department == department))
        {
            Console.WriteLine(entry.Patient);
        }
    }

    public void QueryRoom(string department, string room)
    {
        var patients = entries
            .Where(entry => entry.Department == department && entry.Room == room)
            .Select(entry => entry.Patient)
            .OrderBy(name => name);

        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }
    }

    public void QueryDoctor(string doctorFullName)
    {
        var patients = entries
            .Where(entry => entry.Doctor == doctorFullName)
            .Select(entry => entry.Patient)
            .OrderBy(name => name);

        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }
    }
}

class Program
{
    static void Main()
    {
        var registry = new PatientRegistry();

        Console.WriteLine("Enter patient data. Type ‘output’ to finish entering data.");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "output") break;

            var parts = input.Split();
            if (parts.Length == 5)
            {
                string department = parts[0];
                string doctorFullName = parts[1] + " " + parts[2];
                string patientName = parts[3];
                string room = parts[4];

                registry.AddEntry(department, doctorFullName, patientName, room);
            }
            else
            {
                Console.WriteLine("Incorrect format. Should be: <Department> <Doctor's first name> <Doctor's last name> <Patient's first name> <Room>");
            }
        }

        Console.WriteLine("Enter your query:");

        while (true)
        {
            string query = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(query)) break;

            var parts = query.Split();

            if (parts.Length == 1)
            {
                registry.QueryDepartment(parts[0]);
            }
            else if (parts.Length == 2)
            {
                registry.QueryRoom(parts[0], parts[1]);
            }
            else if (parts.Length == 2 || parts.Length == 3)
            {
                string doctorName = parts[0] + " " + parts[1];
                registry.QueryDoctor(doctorName);
            }
            else
            {
                Console.WriteLine("Incorrect request.");
            }
        }
    }
}
