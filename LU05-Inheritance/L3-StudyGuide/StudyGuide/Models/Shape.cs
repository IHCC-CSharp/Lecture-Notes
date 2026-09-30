namespace StudyGuide.Models;

public abstract class Shape(string name)
{
    public string Name { get; } = name;
    public abstract double GetArea();
}
