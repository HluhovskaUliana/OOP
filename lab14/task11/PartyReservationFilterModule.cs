using System;
using System.Collections.Generic;
using System.Linq;

public class PartyReservationFilterModule
{
    public static void Main()
    {
        List<string> guests = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Print")
        {
            string[] parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            string filterType = parts[1];
            string filterParam = parts[2];

            string filterKey = filterType + filterParam;

            Predicate<string> predicate = CreatePredicate(filterType, filterParam);

            if (command == "Add filter")
            {
                filters[filterKey] = predicate;
            }
            else if (command == "Remove filter")
            {
                filters.Remove(filterKey);
            }
        }

        foreach (var filter in filters.Values)
        {
            guests = guests.Where(g => !filter(g)).ToList();
        }

        Console.WriteLine(string.Join(" ", guests));
        Console.ReadKey();
    }

    private static Predicate<string> CreatePredicate(string type, string param)
    {
        switch (type)
        {
            case "Starts with":
                return name => name.StartsWith(param);
            case "Ends with":
                return name => name.EndsWith(param);
            case "Length":
                int length = int.Parse(param);
                return name => name.Length == length;
            case "Contains":
                return name => name.Contains(param);
            default:
                return name => false;
        }
    }
}