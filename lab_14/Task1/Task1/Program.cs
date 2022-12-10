using System;

class Program
{
    public static int result = 0;
    public static void One() { result = 1; }
    public static void Two() { result = 2; }

    public static void Main()
    {
        Thread one = new Thread(One);
        Thread two = new Thread(Two);
        one.Start();
        two.Start();
        Console.WriteLine(result);
        // Печатает, то 0, то 1, то 2
    }
}