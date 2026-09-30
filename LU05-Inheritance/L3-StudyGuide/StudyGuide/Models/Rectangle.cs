namespace StudyGuide.Models;

public class Rectangle(double width, double height) : Shape("Rectangle")
{
    public override double GetArea() => width * height;
}
