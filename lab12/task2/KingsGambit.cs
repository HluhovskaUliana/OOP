using System;
using System.Collections.Generic;

namespace KingsGambit
{
    public interface IDefender
    {
        string Name { get; }
        bool IsAlive { get; }
        void RespondToAttack();
        void TakeHit();
    }

    public class King
    {
        public string Name { get; private set; }

        private List<IDefender> defenders;

        public King(string name)
        {
            Name = name;
            defenders = new List<IDefender>();
        }

        public void AddDefender(IDefender defender)
        {
            defenders.Add(defender);
        }
        
        public void RemoveDefender(string name)
        {
            defenders.RemoveAll(d => d.Name == name);
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {Name} is under attack");
            foreach (var defender in defenders)
            {
                if (defender.IsAlive)
                {
                    defender.RespondToAttack();
                }
            }
        }
        
        public void HitDefender(string name)
        {
            var defender = defenders.Find(d => d.Name == name);
            if (defender != null)
            {
                defender.TakeHit();
                if (!defender.IsAlive)
                {
                    RemoveDefender(name);
                }
            }
        }

    }

    public class RoyalGuard : IDefender
    {
        public string Name { get; private set; }
        public bool IsAlive { get; private set; } = true;

        public RoyalGuard(string name)
        {
            Name = name;
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }

        public void TakeHit()
        {
            IsAlive = false;
        }
    }

    public class Footman : IDefender
    {
        public string Name { get; private set; }
        public bool IsAlive { get; private set; } = true;

        public Footman(string name)
        {
            Name = name;
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }

        public void TakeHit()
        {
            IsAlive = false;
        }
    }

    class KingsGambit
    {
        static void Main()
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);
            
            string[] guards = Console.ReadLine().Split(' ');
            foreach (string guard in guards)
            {
                if (IsValidName(guard)) king.AddDefender(new RoyalGuard(guard));
            }
            
            string[] footmen = Console.ReadLine().Split(' ');
            foreach (string footmanName in footmen)
            {
                if (IsValidName(footmanName)) king.AddDefender(new Footman(footmanName));
            }

            string command;
            int commandCount = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (commandCount >= 100) break;
                commandCount++;

                if (command.StartsWith("Attack King"))
                {
                    king.RespondToAttack();
                }
                else if (command.StartsWith("Kill "))
                {
                    string nameToKill = command.Substring(5);
                    
                    if (nameToKill == king.Name)
                    {
                        Console.WriteLine("You cannot kill the king!");
                        continue;
                    }

                    king.HitDefender(nameToKill);
                }
            }
        }
        static bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

    }
}