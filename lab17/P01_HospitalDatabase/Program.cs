using System;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;

class Program
{
    static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<HospitalContext>();
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HospitalDb;Trusted_Connection=True;TrustServerCertificate=True;");

        using var context = new HospitalContext(optionsBuilder.Options);
        //context.Database.Migrate(); 

        while (true)
        {
            Console.WriteLine("=== Hospital System ===");
            Console.WriteLine("1. Add patient");
            Console.WriteLine("2. View all patients");
            Console.WriteLine("3. Add visitation");
            Console.WriteLine("4. Add diagnose");
            Console.WriteLine("5. Add doctor");
            Console.WriteLine("0. Exit");
            Console.Write("Select: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddPatient(context);
                    break;
                case "2":
                    ViewPatients(context);
                    break;
                case "3":
                    AddVisitation(context);
                    break;
                case "4":
                    AddDiagnose(context);
                    break;
                case "5":
                    AddDoctor(context);
                    break;
                case "0":
                    return;
            }

            Console.WriteLine();
        }
    }

    static void AddPatient(HospitalContext context)
    {
        Console.Write("First name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        Console.Write("Address: "); 
        string address = Console.ReadLine();

        var patient = new Patient
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Address = address
        };

        context.Patients.Add(patient);
        context.SaveChanges();

        Console.WriteLine("Patient added!");
    }

    static void ViewPatients(HospitalContext context)
    {
        foreach (var p in context.Patients
                     .Include(p => p.Visitations)
                     .Include(p => p.Diagnoses))
        {
            Console.WriteLine($"{p.PatientId}: {p.FirstName} {p.LastName} - {p.Email}");

            if (p.Visitations.Count > 0)
            {
                Console.WriteLine("  Visitations:");
                foreach (var v in p.Visitations)
                {
                    Console.WriteLine($"    {v.Date}: {v.Comments}");
                }
            }

            if (p.Diagnoses.Count > 0)
            {
                Console.WriteLine("  Diagnoses:");
                foreach (var d in p.Diagnoses)
                {
                    Console.WriteLine($"    {d.Name}: {d.Comments}");
                }
            }
        }
    }

    static void AddVisitation(HospitalContext context)
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Doctor ID (optional, press Enter to skip): ");
        string docInput = Console.ReadLine();
        int? doctorId = null;
        if(!string.IsNullOrEmpty(docInput)) 
        {
            doctorId = int.Parse(docInput);
        }
        
        Console.Write("Comments: ");
        string comments = Console.ReadLine();

        var visitation = new Visitation
        {
            PatientId = patientId,
            Date = DateTime.Now,
            Comments = comments
        };

        context.Visitations.Add(visitation);
        context.SaveChanges();

        Console.WriteLine("Visitation added!");
    }

    static void AddDiagnose(HospitalContext context)
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Diagnose name: ");
        string name = Console.ReadLine();

        Console.Write("Comments: ");
        string comments = Console.ReadLine();

        var diagnose = new Diagnose
        {
            PatientId = patientId,
            Name = name,
            Comments = comments
        };

        context.Diagnoses.Add(diagnose);
        context.SaveChanges();

        Console.WriteLine("Diagnose added!");
    }
    
    //task2
    static void AddDoctor(HospitalContext context)
    {
        Console.Write("Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Specialty: ");
        string specialty = Console.ReadLine();

        var doctor = new Doctor
        {
            Name = name,
            Specialty = specialty
        };

        context.Doctors.Add(doctor);
        context.SaveChanges();
        Console.WriteLine("Doctor added!");
    }
}