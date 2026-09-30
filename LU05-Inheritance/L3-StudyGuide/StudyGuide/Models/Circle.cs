namespace StudyGuide.Models;

public class Circle(double radius) : Shape("Circle")
{
    public override double GetArea() => Math.PI * radius * radius;
}
