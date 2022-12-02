using System;
using System.Reflection.Metadata;

class Program
{
    public static bool flag = false;

    public class ThreadResults
    {
        public int iters;
        public double pi;
        public ThreadResults(int iters=0, double pi=0)
        {
            this.iters = iters;
            this.pi = pi;
        }
    }

    public static void Pi(object ans)
    {
        ThreadResults res = ans as ThreadResults;
        double pi = 0;
        long denominator = 1;
        bool sign = true;
        int iter = 0;
        while (!flag)
        {
            for (int i = 0; i < 100000; i++)
            {
                if (sign)
                    pi += 1.0 / denominator;
                else
                    pi -= 1.0 / denominator;
                denominator += 2;
                sign = !sign;
            }
            iter++;
        }
        res.iters = iter;
        res.pi = 4 * pi;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<ThreadResults> res = new List<ThreadResults>();
        List<Thread> threads = new List<Thread> ();

        for (int i = 0; i < n; i++)
            res.Add(new ThreadResults());
        
        for (int i = 0; i < n; i++)
        {
            Thread new_thread = new Thread(Pi);
            threads.Add(new_thread);
            new_thread.Start(res[i]);
        }
        while (true)
        {
            String s = Convert.ToString(Console.ReadLine());
            if (s == "stop")
            {
                flag = true;
                break;
            }
        }

        foreach (var thread in threads)
            thread.Join();

        for (int i = 0; i < n; i++)
            Console.WriteLine("iter: " + res[i].iters + " res: " +  res[i].pi);
        
        Console.WriteLine();
        ThreadResults best_result = res.OrderByDescending(x => x.iters).First();
        Console.WriteLine("Best is " + best_result.iters + " res: " + best_result.pi);
    }
}