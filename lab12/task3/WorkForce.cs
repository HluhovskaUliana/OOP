using System;
using System.Collections.Generic;

namespace WorkForce
{
    public interface IEmployee
    {
        string Name { get; }
        int WorkHoursPerWeek { get; }
    }

    public class StandardEmployee : IEmployee
    {
        public string Name { get; private set; }
        public int WorkHoursPerWeek => 40;

        public StandardEmployee(string name)
        {
            Name = name;
        }
    }

    public class PartTimeEmployee : IEmployee
    {
        public string Name { get; private set; }
        public int WorkHoursPerWeek => 20;

        public PartTimeEmployee(string name)
        {
            Name = name;
        }
    }

    public class Job
    {
        public string Name { get; private set; }
        public int HoursRequired { get; private set; }
        public IEmployee Employee { get; private set; }

        public event EventHandler<Job> JobDone;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            Name = name;
            HoursRequired = hoursRequired;
            Employee = employee;
        }

        public void Update()
        {
            HoursRequired -= Employee.WorkHoursPerWeek;
            if (HoursRequired <= 0)
            {
                Console.WriteLine($"Job {Name} done!");
                JobDone?.Invoke(this, this);
            }
        }

        public void Status()
        {
            Console.WriteLine($"Job: {Name} Hours Remaining: {HoursRequired}");
        }
    }

    public class JobList
    {
        private List<Job> jobs = new List<Job>();

        public void Add(Job job)
        {
            job.JobDone += OnJobDone;
            jobs.Add(job);
        }

        private void OnJobDone(object sender, Job job)
        {
            jobs.Remove(job);
        }

        public void PassWeek()
        {
            foreach (var job in new List<Job>(jobs))
            {
                job.Update();
            }
        }

        public void PrintStatus()
        {
            foreach (var job in jobs)
            {
                job.Status();
            }
        }
    }
    
    class WorkForce
    {
        static void Main()
        {
            Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();
            JobList jobList = new JobList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] parts = command.Split();

                if (parts[0] == "StandardEmployee")
                {
                    string name = parts[1];
                    employees[name] = new StandardEmployee(name);
                }
                else if (parts[0] == "PartTimeEmployee")
                {
                    string name = parts[1];
                    employees[name] = new PartTimeEmployee(name);
                }
                else if (parts[0] == "Job")
                {
                    string jobName = parts[1];
                    int hours = int.Parse(parts[2]);
                    string employeeName = parts[3];

                    if (employees.ContainsKey(employeeName))
                    {
                        Job job = new Job(jobName, hours, employees[employeeName]);
                        jobList.Add(job);
                    }
                }
                else if (command == "Pass Week")
                {
                    jobList.PassWeek();
                }
                else if (command == "Status")
                {
                    jobList.PrintStatus();
                }
            }
        }
    }

}

