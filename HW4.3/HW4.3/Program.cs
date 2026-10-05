abstract class GeographicObject
{
    double X { get; set; }
    double Y { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    public GeographicObject(double x, double y, string name, string description)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
    }
    public virtual void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: \n X: {X}, Y: {Y}");
        Console.WriteLine($"Description: {Description}");
    }

}

class River : GeographicObject
{
    public double FlowSpeed { get; set; }
    public double Length { get; set; }

    public River(double x, double y, string name, string description, double flowSpeed, double length) : base(x, y, name, description)
    {
        FlowSpeed = flowSpeed;
        Length = length;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Flow speed: {FlowSpeed}");
        Console.WriteLine($"Length: {Length}");
    }
}

class Mountain : GeographicObject
{
    public double HighestPoint { get; set; }

    public Mountain(double x, double y, string name, string description, double hightstPoint) : base(x, y, name, description)
    {
        HighestPoint = hightstPoint;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Highest point: {HighestPoint}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        River dnipro = new River(30.5238, 50.4547, "Dnipro", "Main river in Ukraine", 120, 2201);
        Mountain hoverla = new Mountain(24.5667, 48.1603, "Hoverla", "The highest mountain in Ukraine", 2061);

        GeographicObject[] objects = { dnipro, hoverla };
        foreach(GeographicObject obj in objects)
        {
            obj.GetInfo();
        }
    }
}