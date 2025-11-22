using System;
using System.Collections.Generic;
using System.Linq;

public class InfernoIII
{
    public class Exclusion
    {
        public string Type { get; set; }
        public int Parameter { get; set; }
        public string Key => $"{Type};{Parameter}";

        
        public Func<int, int[], bool> GetPredicate()
        {
            if (Type == "Sum Left")
            {
                return (index, gems) =>
                {
                    int leftPower = (index == 0) ? 0 : gems[index - 1]; 
                    int currentPower = gems[index];
                    return (currentPower + leftPower) == Parameter;
                };
            }
            else if (Type == "Sum Right")
            {
                return (index, gems) =>
                {
                    int rightPower = (index == gems.Length - 1) ? 0 : gems[index + 1]; 
                    int currentPower = gems[index];
                    return (currentPower + rightPower) == Parameter;
                };
            }
            else if (Type == "Sum Left Right") 
            {
                return (index, gems) =>
                {
                    int leftPower = (index == 0) ? 0 : gems[index - 1];
                    int rightPower = (index == gems.Length - 1) ? 0 : gems[index + 1]; 
                    int currentPower = gems[index];
                    return (currentPower + leftPower + rightPower) == Parameter;
                };
            }
            return (index, gems) => false;
        }
    }

    public static void Main()
    {
        
        int[] initialGems = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Dictionary<string, Exclusion> exclusions = new Dictionary<string, Exclusion>();

        string commandLine;
        while ((commandLine = Console.ReadLine()) != "Forge")
        {
            string[] parts = commandLine.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            string filterType = parts[1].Trim();
            int filterParam = int.Parse(parts[2].Trim());

            Exclusion currentExclusion = new Exclusion { Type = filterType, Parameter = filterParam };

            if (command == "Exclude") 
            {
                if (!exclusions.ContainsKey(currentExclusion.Key))
                {
                    exclusions.Add(currentExclusion.Key, currentExclusion);
                }
            }
            else if (command == "Reverse") 
            {
                exclusions.Remove(currentExclusion.Key);
            }
        }
        
        List<int> finalGems = new List<int>();

        for (int i = 0; i < initialGems.Length; i++)
        {
            bool isExcluded = false;
            
            foreach (var exclusion in exclusions.Values)
            {
                Func<int, int[], bool> predicate = exclusion.GetPredicate();
                
               
                if (predicate(i, initialGems))
                {
                    isExcluded = true;
                    break;
                }
            }

            if (!isExcluded)
            {
                finalGems.Add(initialGems[i]);
            }
        }
        
        Console.WriteLine(string.Join(" ", finalGems));
        Console.ReadKey();
    }
}