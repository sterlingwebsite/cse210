using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Fraction f = new Fraction(3, 4);

        // Console.WriteLine("Original top: " + f.GetTop());
        // Console.WriteLine("Original bottom: " + f.GetBottom());

        // f.SetTop(5);
        // f.SetBottom(10);

        // Console.WriteLine("Updated top: " + f.GetTop());
        // Console.WriteLine("Updated bottom " + f.GetBottom());

        // 

        // Console.WriteLine("Fraction 1 created.");
        // Console.WriteLine("Fraction 2 created.");
        // Console.WriteLine("Fraction 3 created.");
    }
}