using System;

class Program
{
    
    public delegate double Function (double x);

    public static double Integrate(Function f, double a, double b, int numberOfSplits)
    {
        double result = 0;
        double step = (b - a) / numberOfSplits;
        for (int i = 0; i < numberOfSplits; i++)
            result += f(a + step * i);
        return result * step;
    }

    public static void Main()
    {
        Console.WriteLine(Integrate(Math.Sin, 0, Math.PI, 1000));
        Console.WriteLine(Integrate(Math.Cos, 0, Math.PI, 1000));
        Console.WriteLine(Integrate(Math.Exp, 0, Math.PI, 1000));
        Console.WriteLine(Integrate(x => x, 0, 3, 1000));
        Console.WriteLine(Integrate(Math.Log, 1, 100, 1000));
    }
}