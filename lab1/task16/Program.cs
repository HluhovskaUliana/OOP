using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number (1-7): ");
        int n = int.Parse(Console.ReadLine());

        string day;
        switch (n)
        {
            case 1:
                day = "Monday";
                break;
            case 2:
                day = "Tuesday";
                break;
            case 3:
                day = "Wednesday";
                break;
            case 4:
                day = "Thursday";
                break;
            case 5:
                day = "Friday";
                break;
            case 6:
                day = "Saturday";
                break;
            case 7:
                day = "Sunday";
                break;
            default:
                day = "not valid";
                break;
        }
        Console.WriteLine(day);
        Console.ReadKey();
    }
}