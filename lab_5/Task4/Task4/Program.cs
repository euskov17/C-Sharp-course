using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class Program
{
    public static String ExpressFactors(int num)
    {
        List<int> Factors = new List<int>();
        int d = 2;
        while (d * d <= num)
        {
            if (num % d == 0)
            {
                Factors.Add(d);
                num /= d;
            }
            else
                d++;
        }
        if (num > 1)
            Factors.Add(num);

        var UniqFactors = Factors.Distinct().ToList();

        List<string> ans = new List<string>();
        
        var FactorIter = 0;
        foreach (var fact in UniqFactors)
        {
            var deg = 0;
            while ((FactorIter < Factors.Count) && (Factors[FactorIter] == fact))
            {
                FactorIter++;
                deg++;
            } 
            if (deg == 1)
                ans.Add(fact.ToString());
            else
                ans.Add(fact.ToString() + "^" + deg.ToString());
        }

        return String.Join(" * ", ans);
    }

    public static void Main()
    {
        Console.WriteLine(ExpressFactors(2));
        Console.WriteLine();
        Console.WriteLine(ExpressFactors(4));
        Console.WriteLine();
        Console.WriteLine(ExpressFactors(10));
        Console.WriteLine();
        Console.WriteLine(ExpressFactors(60));
    }
}