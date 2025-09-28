using System;
using System.Collections.Generic;
using task6;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of engines: ");
        int engineCount = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();
        
        Console.WriteLine("Enter information about engines: ");
        for (int i = 0; i < engineCount; i++)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            string model = tokens[0];
            int power = int.Parse(tokens[1]);

            if (tokens.Length == 2)
            {
                engines.Add(new Engine(model, power));
            } 
            else if (tokens.Length == 3)
            {
                engines.Add(new Engine(model, power, tokens[2], "n/a"));
            } else if (tokens.Length == 4)
            {
                engines.Add(new Engine(model, power, tokens[2], tokens[3]));
            }
        }
        Console.WriteLine("Enter the number of cars: ");
        int carCount = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        Console.WriteLine("Enter information about cars: ");
        for (int i = 0; i < carCount; i++)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            string carModel = tokens[0];
            string engineModel = tokens[1];
            Engine engine = engines.Find(e => e.Model == engineModel);

            if (tokens.Length == 2)
            {
                cars.Add(new Car(carModel, engine));
            } else if (tokens.Length == 3)
            {
                cars.Add(new Car(carModel, engine, tokens[2], "n/a"));
            } else if (tokens.Length == 4)
            {
                cars.Add(new Car(carModel, engine, tokens[2], tokens[3]));
            }
        }

        Console.WriteLine("---------INFORMATION--ABOUT--CARS----------");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {car.Weight}");
            Console.WriteLine($"  Color: {car.Color}");
            Console.WriteLine("----------------------");
        }

        Console.ReadKey();
    }
}