using System;

public class Chicken
{
    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Name cannot be null or whitespace.");
            name = value;
        }
    }

    public int Age
    {
        get => age;
        private set
        {
            if (value < 0 || value > 15)
                throw new Exception("Age must be between 0 and 15.");
            age = value;
        }
    }

    private double ProductPerDay()
    {
        if (age >= 0 && age <= 3) return 1.5;
        if (age >= 4 && age <= 7) return 2.0;
        if (age >= 8 && age <= 11) return 1.0;
        return 0.75;
    }

    public override string ToString()
    {
        return $"Chicken {Name} (age {Age}) can produce {ProductPerDay()} eggs per day.";
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(chicken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}