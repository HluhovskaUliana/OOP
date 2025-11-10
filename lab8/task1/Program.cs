using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    protected double fuelQuantity;
    protected double fuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumption = fuelConsumption;
    }
    
    public abstract void Drive(double distance);
    public abstract void Refuel(double liters);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {fuelQuantity:F2}";
    }
}

public class Car : Vehicle
{
    private const double SummerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        double totalConsumption = this.fuelConsumption + SummerConsumption;
        double neededFuel = distance * totalConsumption;

        if (this.fuelQuantity >= neededFuel)
        {
            this.fuelQuantity -= neededFuel;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }
    public override void Refuel(double liters)
    {
        this.fuelQuantity += liters;
    }
}

public class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        double totalConsumption = this.fuelConsumption + SummerConsumption;
        double neededFuel = distance * totalConsumption;

        if (this.fuelQuantity >= neededFuel)
        {
            this.fuelQuantity -= neededFuel;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override void Refuel(double liters)
    {
        this.fuelQuantity += liters * 0.95; 
    }
}

using System;

class Program
{
    static void Main()
    {
        string[] carInput = Console.ReadLine().Split();
        double carFuel = double.Parse(carInput[1]);
        double carConsumption = double.Parse(carInput[2]);
        Vehicle car = new Car(carFuel, carConsumption);

        string[] truckInput = Console.ReadLine().Split();
        double truckFuel = double.Parse(truckInput[1]);
        double truckConsumption = double.Parse(truckInput[2]);
        Vehicle truck = new Truck(truckFuel, truckConsumption);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split();
            string action = command[0];
            string vehicleType = command[1];
            double value = double.Parse(command[2]);

            if (action == "Drive")
            {
                if (vehicleType == "Car")
                    car.Drive(value);
                else if (vehicleType == "Truck")
                    truck.Drive(value);
            }
            else if (action == "Refuel")
            {
                if (vehicleType == "Car")
                    car.Refuel(value);
                else if (vehicleType == "Truck")
                    truck.Refuel(value);
            }
        }
        
        Console.WriteLine(car);   
        Console.WriteLine(truck); 
    }
}