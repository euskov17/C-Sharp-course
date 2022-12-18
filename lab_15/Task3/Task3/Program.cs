using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;

class Program
{
    static Mutex mutexObj = new Mutex();
    public static int waiting = 0;

    static int CHAIRS = 5;

    static Semaphore haircutChair = new Semaphore(1, 1);
    static Random random = new Random();

    public static void Customer()
    {
        Thread thread = Thread.CurrentThread;
        Console.WriteLine(thread.Name + " is here");
        if (waiting <= CHAIRS)
        {
            Console.WriteLine(thread.Name +  " waits on place number " + waiting++.ToString());
        }
        else
        {
            Console.WriteLine(thread.Name + " left");
            return;
        }
        haircutChair.WaitOne();

        Console.WriteLine("\tHairdresser is working with " + thread.Name);
        Thread.Sleep(random.Next(400));
        waiting--;
        Console.WriteLine("\tHairdresser finished with " + thread.Name);
        haircutChair.Release();
    }

    static void Main()
    {
        int N = 15;
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < N; ++i)
        {
            Thread thr = new Thread(Customer);
            thr.Name = "Customer " + i.ToString();
            Thread.Sleep(random.Next(100));
            threads.Add(thr);
            thr.Start();
        }
        foreach (var thr in threads)
            thr.Join();
    }
}