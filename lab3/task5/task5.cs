using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        DistanceTraveled = 0;
    }
    
    public void Drive(double distance)
    {
        double neededFuel = FuelConsumptionPerKm * distance;
        if (FuelAmount >= neededFuel)
        {
            FuelAmount -= neededFuel;
            DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of cars: ");
        int num = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        Console.WriteLine($"Enter information for the cars: ");
        for (int i = 0; i < num; i++)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            string model = carInfo[0];
            double fuelAmount = double.Parse(carInfo[1], CultureInfo.InvariantCulture);
            double fuelConsumptionPerKm = double.Parse(carInfo[2], CultureInfo.InvariantCulture);
            
            cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKm));
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] parts = command.Split(' ');
            string action = parts[0];
            string model = parts[1];
            double distance = double.Parse(parts[2], CultureInfo.InvariantCulture);
            
            Car car = cars.FirstOrDefault(x => x.Model == model);
            if (car != null && action == "Drive")
            {
                car.Drive(distance);
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
        }

        Console.ReadKey();
    }
}