public class square : IShape
{
    public double SideLength { get; set; }

    public square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double GetArea()
    {
        return SideLength * SideLength;
    }

    public string Describe()
    {
        return $"The square has a side length of {SideLength} and an area of {GetArea():F2}.";
    }
}