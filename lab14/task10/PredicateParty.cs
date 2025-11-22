using System;
using System.Collections.Generic;
using System.Linq;

public class PredicateParty
{
    public static void Main()
    {
        List<string> guests = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string commandLine;
       while ((commandLine = Console.ReadLine()) != "Party!")
        {
            string[] parts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            string filterType = parts[1];
            string filterParam = parts[2];

           
            Predicate<string> CreatePredicate(string type, string param)
            {
                if (type == "StartsWith")
                {
                    return name => name.StartsWith(param);
                }
                else if (type == "EndsWith")
                {
                    return name => name.EndsWith(param);
                }
                else if (type == "Length")
                {
                    int length = int.Parse(param);
                    return name => name.Length == length;
                }
                return name => false;
            }

            Predicate<string> predicate = CreatePredicate(filterType, filterParam);
            
            if (command == "Remove")
            {
                guests.RemoveAll(predicate); 
            }
            else if (command == "Double")
            {
                List<string> peopleToDouble = guests.FindAll(predicate);

                foreach (string person in peopleToDouble)
                {
                    int index = guests.IndexOf(person);
                    if (index != -1)
                    {
                        guests.Insert(index, person);
                    }
                }
            }
        }
       
        if (guests.Any())
        {
            Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!"); 
        }
        Console.ReadKey();
    }
}