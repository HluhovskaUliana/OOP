using System;
using System.Collections.Generic;

public class Dough //клас тісто
{
    private static readonly Dictionary<string, double> FlourTypes = new()
    {
        { "White", 1.5 },
        { "Wholegrain", 1.0 }
    };

    private static readonly Dictionary<string, double> BakingTechniques = new()
    {
        { "Crispy", 0.9 },
        { "Chewy", 1.1 },
        { "Homemade", 1.0 }
    };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get => flourType;
        private set
        {
            if (!FlourTypes.ContainsKey(value))
                throw new ArgumentException("Invalid type of dough.");
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (!BakingTechniques.ContainsKey(value))
                throw new ArgumentException("Invalid baking technique.");
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get => weight;
        private set
        {
            if (value < 1 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            weight = value;
        }
    }

    public double Calories => 2 * weight * FlourTypes[flourType] *  BakingTechniques[bakingTechnique];
}

public class Topping //клас начинок
{
    private static readonly Dictionary<string, double> ToppingTypes = new()
    {   
        { "Meat", 1.2 },
        { "Veggies", 0.8},
        { "Cheese", 1.1},
        { "Sauce", 0.9}
    };

    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }
    
    public string Type
    {
        get => type;
        private set
        {
            if (!ToppingTypes.ContainsKey(value))
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            type = value;
        }
    }

    public double Weight
    {
        get => weight;
        private set
        {
            if (value < 1 || value > 50)
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            weight = value;
        }
    }

    public double Calories => 2 * weight * ToppingTypes[type];
}

public class Pizza // клас піца
{
    private string name;
    private Dough dough;
    private readonly List<Topping> toppings = new();

    public Pizza(string name)
    {
        Name = name;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            name = value;
        }
    }

    public Dough Dough
    {
        set => dough = value;
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count >= 10) 
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        toppings.Add(topping);
    }

    public double TotalCalories
    {
        get
        {
            double total = dough.Calories;
            foreach (var topping in toppings)
                total += topping.Calories;
            return total;
        }
    }
    
    public override string ToString() => $"{Name} - {TotalCalories:F2} Calories.";
}

class Program //основна програма
{
    static void Main()
    {
        try
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];
            Pizza pizza = new(pizzaName);

            string[] doughInput = Console.ReadLine().Split();
            string flourType = doughInput[1];
            string bakingTechnique = doughInput[2];
            double doughWeight = double.Parse(doughInput[3]);
            Dough dough = new(flourType, bakingTechnique, doughWeight);
            pizza.Dough = dough;

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] toppingInput = line.Split();
                string toppingType = toppingInput[1];
                double toppingWeight = double.Parse(toppingInput[2]);
                Topping topping = new(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
