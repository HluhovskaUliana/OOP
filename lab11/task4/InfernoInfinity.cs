using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
public enum WeaponType { Axe, Sword, Knife }
public enum Rarity { Common = 1, Uncommon = 2, Rare = 3, Epic = 5 }

public enum GemType { Ruby, Emerald, Amethyst }
public enum Clarity { Chipped = 1, Regular = 2, Perfect = 5, Flawless = 10 }

public class Gem
{
    public int Strength { get; }
    public int Agility { get; }
    public int Vitality { get; }

    public Gem(GemType type, Clarity clarity)
    {
        (int baseStr, int baseAgi, int baseVit) = type switch
        {
            GemType.Ruby => (7, 2, 5),
            GemType.Emerald => (1, 4, 9),
            GemType.Amethyst => (2, 8, 4),
            _ => (0, 0, 0)
        };

        int modifier = (int)clarity;
        Strength = baseStr + modifier;
        Agility = baseAgi + modifier;
        Vitality = baseVit + modifier;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class WeaponAttribute : Attribute
{
    public string Author { get; }
    public int Revision { get; }
    public string Description { get; }
    public string[] Reviewers { get; }

    public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }
}

[Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Rewriting Classes", "Pesho", "Stefan")]
public class Weapon
{
    public string Name { get; }
    public int BaseMinDamage { get; }
    public int BaseMaxDamage { get; }
    public Gem[] Sockets { get; }

    public Weapon(string name, WeaponType type, Rarity rarity)
    {
        Name = name;
        (int min, int max, int socketCount) = type switch
        {
            WeaponType.Axe => (5, 10, 4),
            WeaponType.Sword => (4, 6, 3),
            WeaponType.Knife => (3, 4, 2),
            _ => (0, 0, 0)
        };

        BaseMinDamage = min * (int)rarity;
        BaseMaxDamage = max * (int)rarity;
        Sockets = new Gem[socketCount];
    }

    public void AddGem(int index, Gem gem)
    {
        if (index >= 0 && index < Sockets.Length)
            Sockets[index] = gem;
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < Sockets.Length)
            Sockets[index] = null;
    }

    public override string ToString()
    {
        int strength = Sockets.Where(g => g != null).Sum(g => g.Strength);
        int agility = Sockets.Where(g => g != null).Sum(g => g.Agility);
        int vitality = Sockets.Where(g => g != null).Sum(g => g.Vitality);

        int totalMin = BaseMinDamage + strength * 2 + agility * 1;
        int totalMax = BaseMaxDamage + strength * 3 + agility * 4;

        return $"{Name}: {totalMin}-{totalMax} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}

public class InfernoInfinity
{
    public static void Main()
    {
        Dictionary<string, Weapon> weapons = new();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(';');
            string command = parts[0];

            if (command == "Create")
            {
                string[] typeParts = parts[1].Split();
                Rarity rarity = Enum.Parse<Rarity>(typeParts[0]);
                WeaponType type = Enum.Parse<WeaponType>(typeParts[1]);
                string name = parts[2];

                weapons[name] = new Weapon(name, type, rarity);
            }
            else if (command == "Add")
            {
                string name = parts[1];
                int index = int.Parse(parts[2]);
                string[] gemParts = parts[3].Split();
                Clarity clarity = Enum.Parse<Clarity>(gemParts[0]);
                GemType gemType = Enum.Parse<GemType>(gemParts[1]);

                weapons[name].AddGem(index, new Gem(gemType, clarity));
            }
            else if (command == "Remove")
            {
                string name = parts[1];
                int index = int.Parse(parts[2]);
                weapons[name].RemoveGem(index);
            }
            else if (command == "Print")
            {
                string name = parts[1];
                Console.WriteLine(weapons[name]);
            } else if (command == "Author" || command == "Revision" || command == "Description" ||
                       command == "Reviewers")
            {
                Type weaponType = typeof(Weapon);
                var attribute = weaponType.GetCustomAttribute<WeaponAttribute>();

                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }
            }
        }
    }
}