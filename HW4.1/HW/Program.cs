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
        Team team = new Team("Elite barbarians");

        Developer dev = new Developer("Artem");
        Manager manager = new Manager("Bogdan");

        dev.FillWorkDay();
        manager.FillWorkDay();

        team.AddWorker(dev);
        team.AddWorker(manager);

        Console.WriteLine("Information:");
        team.ShowTeamInfo();

        Console.WriteLine("Full information:");
        team.ShowDetailedTeamInfo();

    }
}


