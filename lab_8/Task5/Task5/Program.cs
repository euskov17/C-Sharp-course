using System;

class Program
{
    public static String sorting(String s)
    {
        char[] chars = s.ToCharArray();
        String res = String.Concat( chars.OrderBy(x => Char.IsNumber(x))
                                         .ThenBy(x => Char.ToLower(x))
                                         .ThenBy(x => Char.IsUpper(x)));
        return res;
    }

    public static void Main()
    {
        Console.WriteLine(sorting("eA2a1E"));
        Console.WriteLine(sorting("Re4r"));
        Console.WriteLine(sorting("6jnM31Q"));
        Console.WriteLine(sorting("846ZIbo"));
    }
}