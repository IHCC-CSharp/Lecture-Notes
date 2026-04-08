Console.Write("Enter the radius of your circle: ");
double radius = double.Parse(Console.ReadLine());

IShape shape = new Circle(radius);
Console.WriteLine(shape.Describe());

//Use Square if we have time

Console.Write("Enter the side length of your square: ");
double sideLength = double.Parse(Console.ReadLine());

IShape squareShape = new square(sideLength);
Console.WriteLine(squareShape.Describe());