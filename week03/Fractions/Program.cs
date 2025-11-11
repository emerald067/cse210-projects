using System;

class Program
{
    public static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"The fraction is {fraction1.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"The fraction is {fraction2.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"The fraction is {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction3.GetDecimalValue()}");

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"The fraction is {fraction4.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction4.GetDecimalValue()}");
    }
}