using System;
using System.Collections.Generic;

namespace Utopia
{
    public interface IBirthable
    {
        string BirthDate { get;}
    }

    public interface IBuyer //part3
    {
        int BuyFood();
    }

    public class Citizen : IBirthable, IBuyer
    {
        public string Name { get;  }
        public int Age { get;  }
        public string Id { get; }
        public string BirthDate { get;  }

        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public int BuyFood() //part3
        {
            return 10;
        }
    }

    public class Rebel : IBuyer //part3
    {
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int BuyFood()
        {
            return 5;
        }

    }
    public class Pet : IBirthable
    {
        public string Name { get;  }
        public string BirthDate { get;  }

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }

    public class Robot
    {
        public string Model { get;  }
        public string Id { get;  }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1) part1 ");
            Console.WriteLine("2) part2 ");
            Console.WriteLine("3) part3 ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("------------");
                    RunIdChak();
                    break;
                case "2":
                    Console.WriteLine("------------");
                    RunBirthdates();
                    break;
                case "3":
                    Console.WriteLine("------------");
                    RunFoodSystem();
                    break;
            }
            
            Console.ReadKey();
        }

        static void RunIdChak()
        {
            List<string> ids = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                string[] parts = input.Split(' ');
                string id = parts[^1]; 
                ids.Add(id);
            }

            string targetEnding = Console.ReadLine();

            foreach (string id in ids)
            {
                if (id.EndsWith(targetEnding))
                {
                    Console.WriteLine(id);
                }
            }

        }
        static void RunBirthdates()//part2
        {
            List<IBirthable> birthables = new();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;
                
                string[] parts = input.Split(' ');
                
                if (parts[0] == "Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthDate = parts[4];
                    birthables.Add(new Citizen(name, age, id, birthDate));
                } else if (parts[0] == "Pet")
                {
                    string name = parts[1];
                    string birthDate = parts[2];
                    birthables.Add(new Pet(name, birthDate));
                }
            }
            
            string targetMonth = Console.ReadLine();

            foreach (var entity in birthables)
            {
                if (entity.BirthDate.Contains(targetMonth))
                {
                    Console.WriteLine(entity.BirthDate);
                }
            }
        }

        static void RunFoodSystem() //part3
        {
            Dictionary<string, IBuyer> buyers = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split(' ');
                string name = parts[0];
                int age = int.Parse(parts[1]);

                if (parts.Length == 4) 
                {
                    string id = parts[2];
                    string birthDate = parts[3];
                    if (!buyers.ContainsKey(name))
                        buyers[name] = new Citizen(name, age, id, birthDate);
                }
                else if (parts.Length == 3) 
                    
                {
                    string group = parts[2];
                    if (!buyers.ContainsKey(name))
                        buyers[name] = new Rebel(name, age, group);
                }
            }

            int totalFood = 0;
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                    break;

                if (buyers.ContainsKey(name))
                {
                    totalFood += buyers[name].BuyFood();
                }
            }

            Console.WriteLine(totalFood);

        }
    }
}