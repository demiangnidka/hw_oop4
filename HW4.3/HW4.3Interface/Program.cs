public interface IGeographicObject
{
    double X { get; set; }
    double Y { get; set; }
    string Name { get; set; }
    string Description { get; set; }

    void GetInfo();
}

class River : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double FlowSpeed { get; set; }
    public double Length { get; set; }

    public River(double x, double y, string name, string description, double flowSpeed, double length)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        FlowSpeed = flowSpeed;
        Length = length;
    }
    public void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: \n X: {X}, Y: {Y}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Flow speed: {FlowSpeed}");
        Console.WriteLine($"Length: {Length}");
    }
}

class Mountain : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double HighestPoint { get; set; }

    public Mountain(double x, double y, string name, string description, double highestPoint)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        HighestPoint = highestPoint;
    }
    public void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: \n X: {X}, Y: {Y}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Highest point: {HighestPoint}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<IGeographicObject> geoObjects = new List<IGeographicObject>();

        while (true)
        {
            Console.WriteLine("\n===== Geographic Objects Menu (Interface) =====");
            Console.WriteLine("1. Add River");
            Console.WriteLine("2. Add Mountain");
            Console.WriteLine("3. Show all objects");
            Console.WriteLine("0. Exit");
            Console.Write("Select action: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string riverName = Console.ReadLine();

                    Console.Write("Enter description: ");
                    string riverDesc = Console.ReadLine();

                    double rx;
                    Console.Write("Enter X coordinate: ");
                    while (!double.TryParse(Console.ReadLine(), out rx))
                    {
                        Console.Write("Invalid input! Enter a valid number for X: ");
                    }

                    double ry;
                    Console.Write("Enter Y coordinate: ");
                    while (!double.TryParse(Console.ReadLine(), out ry))
                    {
                        Console.Write("Invalid input! Enter a valid number for Y: ");
                    }

                    double flowSpeed;
                    Console.Write("Enter flow speed (cm/s): ");
                    while (!double.TryParse(Console.ReadLine(), out flowSpeed) || flowSpeed < 0)
                    {
                        Console.Write("Invalid input! Enter a valid positive number for flow speed: ");
                    }

                    double length;
                    Console.Write("Enter length (km): ");
                    while (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
                    {
                        Console.Write("Invalid input! Enter a valid number > 0 for length: ");
                    }

                    geoObjects.Add(new River(rx, ry, riverName, riverDesc, flowSpeed, length));
                    Console.WriteLine($"River '{riverName}' has been added!");
                    break;

                case "2":
                    Console.Write("Enter name: ");
                    string mountainName = Console.ReadLine();

                    Console.Write("Enter description: ");
                    string mountainDesc = Console.ReadLine();

                    double mx;
                    Console.Write("Enter X coordinate: ");
                    while (!double.TryParse(Console.ReadLine(), out mx))
                    {
                        Console.Write("Invalid input! Enter a valid number for X: ");
                    }

                    double my;
                    Console.Write("Enter Y coordinate: ");
                    while (!double.TryParse(Console.ReadLine(), out my))
                    {
                        Console.Write("Invalid input! Enter a valid number for Y: ");
                    }

                    double highestPoint;
                    Console.Write("Enter highest point (m): ");
                    while (!double.TryParse(Console.ReadLine(), out highestPoint))
                    {
                        Console.Write("Invalid input! Enter a valid number for highest point: ");
                    }

                    geoObjects.Add(new Mountain(mx, my, mountainName, mountainDesc, highestPoint));
                    Console.WriteLine($"Mountain '{mountainName}' has been added!");
                    break;

                case "3":
                    if (geoObjects.Count == 0)
                    {
                        Console.WriteLine("The list of geographic objects is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\n----- Information about Geographic Objects -----");
                        foreach (var obj in geoObjects)
                        {
                            obj.GetInfo();
                            Console.WriteLine("--------------------------------");
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("The program has been completed.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}