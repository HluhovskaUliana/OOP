using System;

class Human
{
    public string firstName;
    public string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get => firstName;
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            if (value.Length < 4)
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            if (value.Length < 3) 
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            lastName = value;
        }
    }
}

class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }
    
    public string FacultyNumber
    {
        get => facultyNumber;
        set
        {
            if (value.Length < 5 || !value.All(char.IsLetterOrDigit))
                throw new ArgumentException("Invalid faculty number!");
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\nFaculty Number: {FacultyNumber}";
    }
}

class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get => weekSalary;
        set
        {
            if (value <= 10)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary!");
            weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay!");
            workHoursPerDay = value;
        }
    }
    
    public decimal SalaryPerHour => WeekSalary / (WorkHoursPerDay * 5);

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\nWeek Salary: {WeekSalary:F2}\nHours per day: {WorkHoursPerDay:F2}\nSalary per hour: {SalaryPerHour:F2}";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var studentInput = Console.ReadLine().Split(' ');
            var workerInput = Console.ReadLine().Split(' ');
            
            var student = new Student(studentInput[0], studentInput[1], studentInput[2]);
            var worker = new Worker(studentInput[0], studentInput[1], 
                decimal.Parse(workerInput[2]), decimal.Parse(workerInput[3]));
            
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}