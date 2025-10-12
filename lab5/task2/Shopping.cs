using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Name cannot be empty.");
        if (price <= 0)
            throw new Exception("Price must be greater than zero.");
        Name = name;
        Price = price;
    }
}

public class Person
{
    public string Name { get; }
    public decimal Money { get; private set; }
    public List<Product> Bag { get; }

    public Person(string name, decimal money)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Name cannot be empty.");
        if (money <= 0)
            throw new Exception("Money cannot be negative");
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public bool TryBuyProduct(Product product)
    {
        if (Money >= product.Price)
        {
            Money -= product.Price;
            Bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
            return true;
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
            return false;
        }
    }

    public override string ToString()
    {
        string products = Bag.Any()
            ? string.Join(", ", Bag.Select(p => p.Name))
            : "Nothing bought";
        return $"{Name} - {products}";
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var people = new Dictionary<string, Person>();
            foreach (var entry in peopleInput)
            {
                var parts = entry.Split('=');
                string name = parts[0];
                decimal money = decimal.Parse(parts[1]);
                people[name] = new Person(name, money);
            }

            var productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var products = new Dictionary<string, Product>();
            foreach (var entry in productsInput)
            {
                var parts = entry.Split("=");
                string name = parts[0];
                decimal price = decimal.Parse(parts[1]);
                products[name] = new Product(name, price);
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                var parts = command.Split();
                string personName = parts[0];
                string productName = parts[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    people[personName].TryBuyProduct(products[productName]);
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}