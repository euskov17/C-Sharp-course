using System;
using System.Threading;

class Program
{
    static object first = new object();
    static object second = new object();
    
    static void foo1(object arg)
    {
        lock (first)
        {
            Thread.Sleep(1000);
            lock (second)
            {
                Console.WriteLine("Hello from foo1");
            }
        }
    }
    
    static void foo2(object arg)
    {
        lock (second)
        {
            Thread.Sleep(1000);
            lock (first)
            {
                Console.WriteLine("Hello from foo2");
            }
        }
    }

    static void Main()
    {
        Thread thread1 = new Thread(foo1);
        Thread thread2 = new Thread(foo2);

        thread1.Start();
        thread2.Start();
        
    }
}
