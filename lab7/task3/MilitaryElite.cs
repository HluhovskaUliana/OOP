using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization; // Додаємо для коректного парсингу decimal, хоча в простих випадках можна без нього

namespace MilitaryElite
{
    // === 1. Допоміжні Класи та Інтерфейси для Деталей ===

    // IRepair.cs
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }

    // Repair.cs
    public class Repair : IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        // Перевизначення ToString для виведення формату 'Part Name: <partName> Hours Worked: <hoursWorked>'
        public override string ToString() => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }

    // IMission.cs
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }
        void CompleteMission();
    }

    // Mission.cs
    public class Mission : IMission
    {
        public string CodeName { get; }
        public string State { get; private set; } // State має бути writable лише через CompleteMission()

        public Mission(string codeName, string state)
        {
            // Валідація стану місії
            if (state != "inProgress" && state != "Finished")
                throw new ArgumentException("Invalid mission state");
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission() => State = "Finished";

        // Перевизначення ToString для виведення формату 'Code Name: <codeName> State: <state>'
        public override string ToString() => $"Code Name: {CodeName} State: {State}";
    }

    // === 2. Інтерфейси для Солдатів ===

    // ISoldier.cs
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }

    // IPrivate.cs
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }

    // ISpecialisedSoldier.cs
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }

    // ILeutenantGeneral.cs
    // Використовуємо IReadOnlyCollection для дотримання принципів інкапсуляції
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }

    // IEngineer.cs
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }

    // ICommando.cs
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }

    // ISpy.cs
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }

    // === 3. Абстрактні та Конкретні Класи Солдатів ===

    // Soldier.cs (Абстрактний базовий клас)
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

    // Private.cs
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        // Форматування зарплати до двох десяткових знаків
        public override string ToString() => $"{base.ToString()} Salary: {Salary:F2}";
    }

    // SpecialisedSoldier.cs (Абстрактний)
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corps { get; }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            // Валідація роду військ
            if (corps != "Airforces" && corps != "Marines")
                throw new ArgumentException("Invalid corps");
            Corps = corps;
        }
        
        // Перевизначення ToString для додавання Corps (використовується в Engineer/Commando)
        public override string ToString() => $"{base.ToString()}\nCorps: {Corps}";
    }

    // LeutenantGeneral.cs
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private readonly List<IPrivate> _privates = new();
        public IReadOnlyCollection<IPrivate> Privates => _privates.AsReadOnly(); // Використовуємо ReadOnly

        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary, IEnumerable<IPrivate> subordinates)
            : base(id, firstName, lastName, salary)
        {
            // Сортуємо підлеглих для послідовного виведення
            _privates.AddRange(subordinates.OrderByDescending(p => p.Id));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var p in _privates)
            {
                // Додаємо відступи згідно з прикладом
                sb.AppendLine($"  {p.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }

    // Engineer.cs
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> _repairs = new();
        public IReadOnlyCollection<IRepair> Repairs => _repairs.AsReadOnly();

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            _repairs.AddRange(repairs);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var r in _repairs)
            {
                // Додаємо відступи згідно з прикладом
                sb.AppendLine($"  {r.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }

    // Commando.cs
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> _missions = new();
        public IReadOnlyCollection<IMission> Missions => _missions.AsReadOnly();

        public Commando(int id, string firstName, string lastName, decimal salary, string corps, IEnumerable<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            _missions.AddRange(missions);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var m in _missions)
            {
                // Додаємо відступи згідно з прикладом
                sb.AppendLine($"  {m.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }

    // Spy.cs
    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; }

        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        // Перевизначення ToString
        public override string ToString() => $"{base.ToString()}\nCode Number: {CodeNumber}";
    }

    // === 4. Головна Програма (Main Logic) ===
    class Program
    {
        static void Main()
        {
            // Зберігаємо Private солдатів для LeutenantGeneral
            Dictionary<int, IPrivate> privates = new();
            // Зберігаємо всіх солдатів для фінального виведення
            List<ISoldier> army = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                string type = parts[0];
                int id = 0;
                
                try
                {
                    // Спільні дані для більшості солдатів
                    id = int.Parse(parts[1]);
                    string firstName = parts[2];
                    string lastName = parts[3];
                    
                    ISoldier newSoldier = null;

                    switch (type)
                    {
                        case "Private":
                            decimal salary = decimal.Parse(parts[4], CultureInfo.InvariantCulture);
                            var p = new Private(id, firstName, lastName, salary);
                            newSoldier = p;
                            privates[id] = p; // Зберігаємо як IPrivate для LeutenantGeneral
                            break;

                        case "LeutenantGeneral":
                            decimal generalSalary = decimal.Parse(parts[4], CultureInfo.InvariantCulture);
                            var subordinateIds = parts.Skip(5).Select(int.Parse).ToList();
                            
                            // Збираємо список вже існуючих підлеглих
                            var subordinates = subordinateIds
                                .Where(pid => privates.ContainsKey(pid))
                                .Select(pid => privates[pid])
                                .ToList();
                                
                            var general = new LeutenantGeneral(id, firstName, lastName, generalSalary, subordinates);
                            newSoldier = general;
                            privates[id] = general; // Генерал також вважається Private для потенційного вищого чину
                            break;

                        case "Engineer":
                            decimal engSalary = decimal.Parse(parts[4], CultureInfo.InvariantCulture);
                            string engCorps = parts[5];
                            var repairs = new List<IRepair>();
                            
                            // Зчитування ремонтів парами
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string part = parts[i];
                                int hours = int.Parse(parts[i + 1]);
                                repairs.Add(new Repair(part, hours));
                            }
                            
                            var engineer = new Engineer(id, firstName, lastName, engSalary, engCorps, repairs);
                            newSoldier = engineer;
                            privates[id] = engineer;
                            break;

                        case "Commando":
                            decimal commSalary = decimal.Parse(parts[4], CultureInfo.InvariantCulture);
                            string commCorps = parts[5];
                            var missions = new List<IMission>();
                            
                            // Зчитування місій парами
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string code = parts[i];
                                string state = parts[i + 1];
                                try
                                {
                                    missions.Add(new Mission(code, state));
                                }
                                catch (ArgumentException)
                                {
                                }
                            }
                            
                            var commando = new Commando(id, firstName, lastName, commSalary, commCorps, missions);
                            newSoldier = commando;
                            privates[id] = commando;
                            break;

                        case "Spy":
                            int codeNumber = int.Parse(parts[4]);
                            newSoldier = new Spy(id, firstName, lastName, codeNumber);
                            break;
                    }

                    if (newSoldier != null)
                    {
                        army.Add(newSoldier);
                    }
                }
                catch (ArgumentException)
                {
                   // Пропускаємо весь рядок у випадку невірного роду військ [cite: 104]
                }
                catch (Exception)
                {
                    // Обробка інших помилок, як-от некоректний формат чисел
                }
            }

            // Виведення результату
            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}