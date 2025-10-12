using System;
using System.Collections.Generic;

//класи їжі
public abstract class Food
{
    public abstract int HappinessPoints { get; }
}

public class Cram : Food { public override int HappinessPoints => 2; }
public class Lembas : Food { public override int HappinessPoints => 3; }
public class Apple : Food { public override int HappinessPoints => 1; }
public class Melon : Food { public override int HappinessPoints => 1; }
public class HoneyCake : Food { public override int HappinessPoints => 5; }
public class Mushrooms : Food { public override int HappinessPoints => -10; }
public class Other : Food { public override int HappinessPoints => -1; }

//класи настрою
public abstract class Mood
{
    public abstract string Name { get; }
}

public class Angry : Mood { public override string Name => "Angry" ; }
public class Sad : Mood { public override string Name => "Sad"; }
public class Happy : Mood { public override string Name => "Happy"; }
public class JavaScript : Mood { public override string Name => "JavaScript"; }

//шаблони фабрик для створення їжі та настрою
public static class FoodFactory
{
    public static Food CreateFood(string name)
    {
        switch (name.ToLower())
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new Other();
        }
    }
}

public static class MoodFactory
{
    public static Mood CreateMood(int happiness)
    {
        if (happiness <= -5) return new Angry();
        if (happiness >= -5 && happiness <= 0) return new Sad();
        if (happiness >= 1 && happiness <= 15) return new Happy();
        return new JavaScript();
    }
}

//сама програма
class Mordor
{
    static void Mian()
    {
        string input = Console.ReadLine();
        var foods = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        List<Food> foodList = new List<Food>();
        int totalHappiness = 0;
        
        foreach (var foodName in foods)
        {
            Food food = FoodFactory.CreateFood(foodName);
            foodList.Add(food);
            totalHappiness += food.HappinessPoints;
        }
        
        Mood mood = MoodFactory.CreateMood(totalHappiness);
        
        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.Name);
        
        Console.ReadKey();
    }
    
}