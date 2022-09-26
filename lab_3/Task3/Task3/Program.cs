using System;

class Solution
{   
    public static int Gcd(int x, int y)
    {
       if (x == y) return x;
       return Gcd(Math.Abs(y - x), Math.Min(x, y));
    }

    public static string Simplify(string arg)
    {
        string[] args = arg.Split('/');

        var arg1 = int.Parse(args[0]);
        var arg2 = int.Parse(args[1]);
        
        var gcd = Gcd(arg1, arg2);

        arg1 = arg1 / gcd;
        arg2 = arg2 / gcd;

        if (arg2 == 1) return arg1.ToString();
        return arg1.ToString() + "/" + arg2.ToString();
    }

    public static void Main()
    {
        Console.WriteLine(Simplify("4/6"));
        Console.WriteLine(Simplify("8/4"));
        Console.WriteLine(Simplify("100/400"));
    }
}