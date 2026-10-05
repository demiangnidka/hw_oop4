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
        River dnipro = new River(30.5238, 50.4547, "Dnipro", "Main river in Ukraine", 120, 2201);
        Mountain hoverla = new Mountain(24.5667, 48.1603, "Hoverla", "The highest mountain in Ukraine", 2061);

        IGeographicObject[] objects = { dnipro, hoverla };
        foreach (IGeographicObject obj in objects)
        {
            obj.GetInfo();
        }
    }
}