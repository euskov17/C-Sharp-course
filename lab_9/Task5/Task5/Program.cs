using System;
using System.Text;

class Program
{
    public static string Rational(int a, int b)
    {
        List<int> remain = new List<int>();
        List<int> deviders = new List<int>();
        while (a != 0)
        {
            int dev = (10 * a) / b;
            int rem = (10 * a) % b;
            if (remain.Contains(rem))
            {
                var index = remain.IndexOf(rem);
                if ((index == remain.Count - 1) & (dev != deviders[index])){
                    deviders.Add(dev);
                    index++;
                }
                String start = String.Concat(deviders.Take(index).Select(x => x.ToString()).ToList());
                String finish = String.Concat(deviders.Skip(index).Select(x => x.ToString()).ToList());
                return "0," + start + '(' + finish + ')';
            }
            else
            {
                deviders.Add(dev);
                remain.Add(rem);
            }
            a = rem;
        }
        return "0," + String.Concat(deviders.Select(x => x.ToString()).ToList());
    }

    public static void Main()
    {
        Console.WriteLine(Rational(2, 5));
        Console.WriteLine(Rational(1, 6));
        Console.WriteLine(Rational(1, 3));
        Console.WriteLine(Rational(1, 7));
        Console.WriteLine(Rational(1, 77));
    }
}