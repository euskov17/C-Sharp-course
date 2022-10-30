using System;

class Program
{
    public static bool StringsDifference(String s1, String s2)
    {
        if (Math.Abs(s1.Length - s2.Length) > 1)
            return false;
        var longestString = (s1.Length >= s2.Length) ? s1 : s2;
        var shortestString = (s1.Length < s2.Length) ? s1 : s2;
        var longIndex = 0;
        var haveError = false;
        foreach (char s in shortestString)
        {
            if (s != longestString[longIndex])
            {
                if (haveError == true)
                    return false;
                if (longIndex == longestString.Length - 1)
                    return true;
                if (s1.Length != s2.Length)
                    longIndex++;
                haveError = true;
            }
            longIndex++;
        }
        return true;
    }

    public static void Main()
    {
        Console.WriteLine(StringsDifference("qwerty", "qwerty1"));
        Console.WriteLine(StringsDifference("qwerty", "1qwerty"));
        Console.WriteLine(StringsDifference("qwerty", "qw1erty"));
        Console.WriteLine(StringsDifference("qwerty1", "qwerty"));
        Console.WriteLine(StringsDifference("1qwerty", "qwerty"));
        Console.WriteLine(StringsDifference("1qwerty", "qwerty"));
        Console.WriteLine(StringsDifference("qw1erty", "qwerty1"));
        Console.WriteLine(StringsDifference("", "qwerty1"));
        Console.WriteLine(StringsDifference("1qwerty", ""));
        Console.WriteLine(StringsDifference("1qwerty1", "1qwerty1"));
        Console.WriteLine(StringsDifference("qwety", "qweety"));
    }
}