using System;
using System.Collections.Generic;

namespace P03_TrafficLights
{
    public enum Signal
    {
        Red,
        Green,
        Yellow
    }

    public class TrafficLight
    {
        private Signal currentSignal;

        public TrafficLight(string initialSignal)
        {
            currentSignal = Enum.Parse<Signal>(initialSignal);
        }

        public void Change()
        {
            currentSignal = currentSignal switch
            {
                Signal.Red => Signal.Green,
                Signal.Green => Signal.Yellow,
                Signal.Yellow => Signal.Red,
                _ => currentSignal
            };
        }

        public override string ToString()
        {
            return currentSignal.ToString();
        }
    }

    public class TrafficLights
    {
        public static void Main()
        {
            string[] initialSignals = Console.ReadLine().Split();
            int changes = int.Parse(Console.ReadLine());

            List<TrafficLight> lights = new List<TrafficLight>();

            foreach (string signal in initialSignals)
            {
                lights.Add(new TrafficLight(signal));
            }

            for (int i = 0; i < changes; i++)
            {
                foreach (var light in lights)
                {
                    light.Change();
                }

                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }
}