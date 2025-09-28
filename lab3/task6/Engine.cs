namespace task6;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
    }

    public Engine(string model, int power, string displacement, string efficienty)
        : this(model, power)
    {
        if (displacement != null) Displacement = displacement;
        if (efficienty != null) Efficiency = efficienty;
    }
}