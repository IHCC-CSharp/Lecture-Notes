public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public string Describe()
    {
        return $"The circle has a radius of {Radius} and an area of {GetArea():F2}.";
    }
}