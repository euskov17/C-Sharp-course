using System;
using System.Text;

class Program
{
    public static String stingyFib(int n)
    {
        if (n < 2)
            return  "invalid" ;
        var builder = new StringBuilder("a", 100);
        var builder2 = new StringBuilder("b", 100);
        String prev = new String("b");
        for (int i = 0; i < n; i++)
        {   
            String tmp = builder.ToString();
            builder.Append(prev);
            prev = tmp;
            builder2.Append(' ' + tmp);
        }
        return builder2.ToString();
    }

    public static void Main()
    {
        Console.WriteLine(stingyFib(1));
        Console.WriteLine(stingyFib(2));
        Console.WriteLine(stingyFib(3));
        Console.WriteLine(stingyFib(7));    
    }
}
