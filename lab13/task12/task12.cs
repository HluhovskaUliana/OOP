using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number of orders:");
        int n = int.Parse(Console.ReadLine());

        var companyOrders = new Dictionary<string, Dictionary<string, int>>();
        var productOrderSequence = new Dictionary<string, List<string>>();
        

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()
                .Trim('|', ' ')
                .Replace(" |", "")
                .Replace("| ", "");

            var parts = input.Split(" - ");
            string company = parts[0];
            int quantity = int.Parse(parts[1]);
            string product = parts[2];

            if (!companyOrders.ContainsKey(company))
                companyOrders[company] = new Dictionary<string, int>();

            if (!companyOrders[company].ContainsKey(product))
                companyOrders[company][product] = 0;

            companyOrders[company][product] += quantity;

            if (!productOrderSequence.ContainsKey(company))
                productOrderSequence[company] = new List<string>();

            if (!productOrderSequence[company].Contains(product))
                productOrderSequence[company].Add(product);
        }

        Console.WriteLine("\nSummary:");
        foreach (var company in companyOrders.OrderBy(c => c.Key))
        {
            var products = productOrderSequence[company.Key]
                .Select(p => $"{p}-{company.Value[p]}");

            Console.WriteLine($"{company.Key}: {string.Join(", ", products)}");
        }
        Console.ReadKey();
    }
}
