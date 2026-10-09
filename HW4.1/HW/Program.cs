public abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string WorkDay { get; set; }

    public Worker(string name)
    {
        Name = name;
        WorkDay = "";
        Position = string.Empty;
    }

    public void Call()
    {
        WorkDay += "The call was made\n";
    }
    public void WriteCode()
    {
        WorkDay += "The code is written\n";
    }

    public void Relax()
    {
        WorkDay += "The rest was taken\n";
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker 
{
    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }

    public Developer(string name) : base(name)
    {
        Position = "Developer";
    }
}

public class Manager : Worker 
{
    public Manager(string name) : base(name)
    {
        Position = "Manager";
    }

    private Random _random = new Random();

    public override void FillWorkDay()
    {
        int firstCallCount = _random.Next(1, 11);
        for(int i = 0; i < firstCallCount; i++)
        {
            Call();
        }

        Relax();

        int secondCallCount = _random.Next(1, 6);
        for(int i = 0; i < secondCallCount; i++)
        {
            Call();
        }
    }
}

public class Team
{
    public string Name { get; set; }

    private List<Worker> _workers = new List<Worker>();

    public Team(string name)
    {
        Name = name;
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
    }

    public void ShowTeamInfo()
    {
        Console.WriteLine($"Team: {Name}");
        Console.WriteLine("Workers:");

        foreach (Worker worker in _workers)
        {
            Console.WriteLine($" - {worker.Name}");
        }
    }

    public void ShowDetailedTeamInfo()
    {
        Console.WriteLine($"Team: {Name}");
        Console.WriteLine("Workers: ");

        foreach (Worker worker in _workers)
        {
            Console.WriteLine($"- {worker.Name} ({worker.Position})");
            Console.WriteLine("WorkDay:");
            Console.WriteLine(worker.WorkDay);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Worker> workers = new List<Worker>();

        while (true)
        {
            Console.WriteLine("\n ====== Menu ======");
            Console.WriteLine("1. Add (Developer)");
            Console.WriteLine("2. Add (manager)");
            Console.WriteLine("3. Show all workers and their day");
            Console.WriteLine("0. Exit");
            Console.Write("Select action: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter developer`s name:");
                    string devName = Console.ReadLine();
                    workers.Add(new Developer(devName));
                    Console.WriteLine($"Developer {devName} has been added");
                    break;

                case "2":
                    Console.Write("Enter manager`s name:");
                    string managerName = Console.ReadLine();
                    workers.Add(new Manager(managerName));
                    Console.WriteLine($"Manager {managerName} has been added");
                    break;

                case "3":
                    if (workers.Count == 0)
                    {
                        Console.WriteLine("The workers list is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\n----- Information about workers -----");
                        foreach (var worker in workers)
                        {
                            worker.FillWorkDay();
                            Console.WriteLine($"Name: {worker.Name}, Position: {worker.Position}");
                            Console.WriteLine($"Workday:\n{worker.WorkDay}");
                            Console.WriteLine("--------------------------------");
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("The program has been completed.");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }
    }
}


