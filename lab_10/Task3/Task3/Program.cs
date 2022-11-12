using System;
using System.Runtime.CompilerServices;

class Program
{

    public static int EnclosingEnvelopes(List<List<int>> envelops)
    {
        envelops.Sort((x, y) => (x[0].CompareTo(y[0]))); 
        int[] dp = Enumerable.Repeat(1, envelops.Count).ToArray(); 
        for (int i = 0; i < envelops.Count; ++i)
            for (int j = i + 1; j < envelops.Count; ++j)
                if (envelops[i][0] < envelops[j][0] & envelops[i][1] < envelops[j][1])
                    dp[j] = Math.Max(dp[j], dp[i] + 1);
        return dp.Max();
    }


    public static void Main()
    {
        var example1 = new List<List<int>>{ new List<int>{ 5, 4 }, new List<int>{ 6, 4 }, new List<int>{ 6, 7 },new List<int>{ 2, 3}};
        var example2 = new List<List<int>> { new List<int>{ 1, 1 }, new List<int> { 1, 1 } };
        Console.WriteLine(EnclosingEnvelopes(example1));
        Console.WriteLine(EnclosingEnvelopes(example2));
    }
}