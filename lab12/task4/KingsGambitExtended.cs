using System;
using System.Collections.Generic;

namespace KingsGambitExtended
{
    public interface IDefender
    {
        string Name { get; }
        bool IsAlive { get; }
        void RespondToAttack();
        void TakeHit();
        event EventHandler<string> OnDeath;
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
            defender.OnDeath += HandleDeath;
            defenders.Add(defender);
        }

        private void HandleDeath(object sender, string name)
        {
            defenders.RemoveAll(d => d.Name == name);
        }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {Name} is under attack!");
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
            }
        }
    }

    public class Footman : IDefender
    {
        public string Name { get; private set; }
        private int hitsTaken = 0;
        public bool IsAlive { get; private set; } = true;

        public event EventHandler<string> OnDeath;

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
            hitsTaken++;
            if (hitsTaken >= 2 && IsAlive)
            {
                IsAlive = false;
                OnDeath?.Invoke(this, Name);
            }
        }
    }

    public class RoyalGuard : IDefender
    {
        public string Name { get; private set; }
        private int hitsTaken = 0;
        public bool IsAlive { get; private set; } = true;

        public event EventHandler<string> OnDeath;

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
            hitsTaken++;
            if (hitsTaken >= 3 && IsAlive)
            {
                IsAlive = false;
                OnDeath?.Invoke(this, Name);
            }
        }
    }

    class KingsGambitExtended
    {
        static void Main()
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            string[] guards = Console.ReadLine().Split();
            foreach (var guard in guards)
            {
                king.AddDefender(new RoyalGuard(guard));
            }

            string[] footmen = Console.ReadLine().Split();
            foreach (var footman in footmen)
            {
                king.AddDefender(new Footman(footman));
            }

            string command;
            int commandCount = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                if (commandCount >= 100) break;
                commandCount++;

                if (command == "Attack King")
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
    }
}