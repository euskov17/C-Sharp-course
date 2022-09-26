using System;
using System.Transactions;

class Solution
{
    public static long ReverseInt(long num)
    {
        long result = 0;
        while (num > 0)
        {
            result = result * 10 + num % 10;
            num /= 10;
        }
        return result;
    }

    public static (long, long) PalSeq(long pal)
    {
        long i = 0;
        while (++i <= pal)
        {
            var val = i;
            long steps = 0;
            while (val < pal)
            {
                val += ReverseInt(val);
                steps++;
            }
            if (val == pal) return (i, steps);
        }
        return (pal, 0);
    }

    public static void Main()
    {
        Console.WriteLine(PalSeq(4884));
        Console.WriteLine(PalSeq(1));
        Console.WriteLine(PalSeq(11));
        Console.WriteLine(PalSeq(3113));
        Console.WriteLine(PalSeq(8836886388));
    }
}