using System;
using Shape;

class Program
{
    static void Main(string[] args)
    {
        List<Shape.Shape> shapes = new List<Shape.Shape>();

        shapes.Add(new Square(3.0, "Green"));
        shapes.Add(new Rectangle(4.0, 6.0, "Blue"));
        shapes.Add(new Circle(5.0, "Red"));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}