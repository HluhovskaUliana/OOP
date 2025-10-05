using System;

enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
enum DiscountType
{
    FirstVisit,
    SecondVisit,
    VIP
}

class PriceCalculator
{
    private double pricePerDay;
    private int numberOfDays;
    private Season season;
    private DiscountType discountType;

    public PriceCalculator(double pricePerDay, int numberOfDays, Season season, DiscountType discountType)
    {
        this.pricePerDay = pricePerDay;
        this.numberOfDays = numberOfDays;
        this.season = season;
        this.discountType = discountType;
    }

    public double CalculateTotalPrice()
    {
        double seasonMultiplier = GetSeasonMultiplier(season);
        double basePrice = pricePerDay * numberOfDays * seasonMultiplier;
        double discountMultiplier = GetDiscountMultiplier(discountType);
        double finalPrice = basePrice * (1 - discountMultiplier);
        return Math.Round(finalPrice, 2);

    }

    private double GetSeasonMultiplier(Season season)
    {
        return season switch
        {
            Season.Summer => 4.0,
            Season.Winter => 3.0,
            Season.Spring => 2.0,
            Season.Autumn => 1.0,
            _ => 1.0
        };
    }
    private double GetDiscountMultiplier(DiscountType discount)
    {
        return discount switch
        {
            DiscountType.FirstVisit => 0.00,
            DiscountType.SecondVisit => 0.10,
            DiscountType.VIP => 0.20,
            _ => 0.0
        };
    }
}

class task2
{
    static void Main()
    {
        Console.WriteLine("Enter data (<pricePerDay> <numberOfDays> <season> <discountType>):");
        string input = Console.ReadLine();
        var parts = input.Split();

        double pricePerDay = double.Parse(parts[0]);
        int numberOfDays = int.Parse(parts[1]);
        Season season = Enum.Parse<Season>(parts[2]);
        DiscountType discountType = Enum.Parse<DiscountType>(parts[3]);

        var calculator = new PriceCalculator(pricePerDay, numberOfDays, season, discountType);
        double totalPrice = calculator.CalculateTotalPrice();

        Console.WriteLine($"The total price is: {totalPrice}");

        Console.ReadKey();
    }
}
