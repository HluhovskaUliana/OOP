using System;
using System.Collections.Generic;
using System.Linq;

class Treasure
{
    public string Category { get; set; }
    public string Name { get; set; }
    public long Quantity { get; set; }
}

class task4
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var treasures = new List<Treasure>();

        for (int i = 0; i < input.Length; i += 2)
        {
            string name = input[i];
            long quantity = long.Parse(input[i + 1]);

            string category = GetCategory(name);
            if (category == null) continue;

            treasures.Add(new Treasure { Category = category, Name = name, Quantity = quantity });
        }

        var selected = new List<Treasure>();
        long totalGold = 0, totalGem = 0, totalCash = 0, currentBag = 0;

        foreach (var item in treasures.OrderByDescending(t => t.Quantity))
        {
            if (currentBag + item.Quantity > bagCapacity) continue;

            switch (item.Category)
            {
                case "Gold":
                    selected.Add(item);
                    totalGold += item.Quantity;
                    currentBag += item.Quantity;
                    break;

                case "Gem":
                    if (totalGem + item.Quantity <= totalGold)
                    {
                        selected.Add(item);
                        totalGem += item.Quantity;
                        currentBag += item.Quantity;
                    }
                    break;

                case "Cash":
                    if (totalCash + item.Quantity <= totalGem)
                    {
                        selected.Add(item);
                        totalCash += item.Quantity;
                        currentBag += item.Quantity;
                    }
                    break;
            }
        }

        PrintCategory("Gold", selected);
        PrintCategory("Gem", selected);
        PrintCategory("Cash", selected);
    }

    static string GetCategory(string name)
    {
        if (name.ToLower() == "gold") return "Gold";
        if (name.ToLower().Contains("gem")) return "Gem";
        if (name.ToLower() == "cash") return "Cash";
        return null;
    }

    static void PrintCategory(string category, List<Treasure> selected)
    {
        var items = selected.Where(t => t.Category == category).ToList();
        if (!items.Any()) return;

        long total = items.Sum(t => t.Quantity);
        Console.WriteLine($"{category} ${total}");

        foreach (var item in items
            .OrderByDescending(t => t.Quantity)
            .ThenBy(t => t.Name))
        {
            Console.WriteLine($"##{item.Name} - {item.Quantity}");
        }
    }
}
