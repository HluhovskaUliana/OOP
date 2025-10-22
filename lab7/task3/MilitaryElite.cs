using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    // інтерфейси
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }

    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }

    public interface ILeutenantGeneral : IPrivate
    {
        List<IPrivate> Privates { get; }
    }

    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }

    public interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }
    }

    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
    }

    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }

    // класи
    public abstract class Soldier : ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"Name: {FirstName} {LastName} Id: {Id}";
    }

    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString() => $"{base.ToString()} Salary: {Salary:F2}";
    }

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public List<IPrivate> Privates { get; } = new();

        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary) { }

        public override string ToString()
        {
            string result = $"{base.ToString()}\nPrivates:";
            foreach (var p in Privates)
                result += $"\n  {p}";
            return result;
        }
    }

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corps { get; }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            if (corps != "Airforces" && corps != "Marines")
                throw new ArgumentException("Invalid corps");
            Corps = corps;
        }
    }

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; } = new();

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps) { }

        public override string ToString()
        {
            string result = $"{base.ToString()}\nCorps: {Corps}\nRepairs:";
            foreach (var r in Repairs)
                result += $"\n  {r}";
            return result;
        }
    }

    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; } = new();

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps) { }

        public override string ToString()
        {
            string result = $"{base.ToString()}\nCorps: {Corps}\nMissions:";
            foreach (var m in Missions)
                result += $"\n  {m}";
            return result;
        }
    }

    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; }

        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public override string ToString() => $"{base.ToString()}\nCode Number: {CodeNumber}";
    }

    public class Repair
    {
        public string PartName { get; }
        public int HoursWorked { get; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public override string ToString() => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }

    public class Mission
    {
        public string CodeName { get; }
        public string State { get; private set; }

        public Mission(string codeName, string state)
        {
            if (state != "inProgress" && state != "Finished")
                throw new ArgumentException("Invalid mission state");
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission() => State = "Finished";

        public override string ToString() => $"Code Name: {CodeName} State: {State}";
    }

    //основний
    class Program
    {
        static void Main()
        {
            Dictionary<int, IPrivate> privates = new();
            List<ISoldier> army = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split();
                string type = parts[0];
                int id = int.Parse(parts[1]);
                string firstName = parts[2];
                string lastName = parts[3];

                try
                {
                    switch (type)
                    {
                        case "Private":
                            decimal salary = decimal.Parse(parts[4]);
                            var p = new Private(id, firstName, lastName, salary);
                            privates[id] = p;
                            army.Add(p);
                            break;

                        case "LeutenantGeneral":
                            salary = decimal.Parse(parts[4]);
                            var general = new LeutenantGeneral(id, firstName, lastName, salary);
                            for (int i = 5; i < parts.Length; i++)
                            {
                                int pid = int.Parse(parts[i]);
                                if (privates.ContainsKey(pid))
                                    general.Privates.Add(privates[pid]);
                            }
                            army.Add(general);
                            break;

                        case "Engineer":
                            salary = decimal.Parse(parts[4]);
                            string corps = parts[5];
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string part = parts[i];
                                int hours = int.Parse(parts[i + 1]);
                                engineer.Repairs.Add(new Repair(part, hours));
                            }
                            army.Add(engineer);
                            break;

                        case "Commando":
                            salary = decimal.Parse(parts[4]);
                            corps = parts[5];
                            var commando = new Commando(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string code = parts[i];
                                string state = parts[i + 1];
                                try
                                {
                                    commando.Missions.Add(new Mission(code, state));
                                }
                                catch { }
                            }
                            army.Add(commando);
                            break;

                        case "Spy":
                            int codeNumber = int.Parse(parts[4]);
                            army.Add(new Spy(id, firstName, lastName, codeNumber));
                            break;
                    }
                }
                catch
                {
                    // Пропустити некоректні рядки або місії
                }
            }

            foreach (var soldier in army)
                Console.WriteLine(soldier);
            Console.ReadKey();
        }
    }
}