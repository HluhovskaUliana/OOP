using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> detainedIds = new List<string>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ');
            string id = parts[parts.Length - 1];
            
            detainedIds.Add(id);
        }
        
        string fakeSuffix = Console.ReadLine();

        foreach (string id in detainedIds)
        {
            if (id.EndsWith(fakeSuffix))
            {
                Console.WriteLine(id);
            }
        }

        Console.ReadKey();
    }
}