using System;

class Program
{
    public static long LuckyTicket(int n)
    {
        var sums = new long[n * 10];
        for (long i = 0; i < Math.Pow(10, n >> 1); i++)
        {
            long sum = 0;
            long currentValue = i;
            while (currentValue > 0)
            {
                sum += currentValue % 10;
                currentValue /= 10;
            }
            sums[sum] += 1;
        }
        return sums.Sum(x => x * x);
    }
    
    public static void Main()
    {
        Console.WriteLine(LuckyTicket(2));
        Console.WriteLine(LuckyTicket(4));
        Console.WriteLine(LuckyTicket(12));
    }
}