using System;

class Program
{
    public static void Main()
    {
        string s = "This dog eats too much vegetables after lunch";
        int n = 3;
        var dict = new Dictionary<string, string>() { { "this", "эта" },
            { "dog", "собака" },{"eats", "ест"}, {"too", "слишком"}, {"much", "много"}, {"vegetables","овощей"}, {"after", "после"}, {"lunch", "ужина"} };
        int i = 0;
        var modifyedByDict = String.Join('\n', s.ToLower()
                       .Split(' ')
                       .Select((st, index) => dict[st].ToUpper())
                       .GroupBy(s => i++ / n)
                       .Select(s => String.Join(' ', s.ToList())));
        Console.WriteLine(modifyedByDict);
    }
}