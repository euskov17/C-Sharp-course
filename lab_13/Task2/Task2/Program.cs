using System;

class Program
{
    static Mutex mutex = new Mutex();
    
    public static void foo1()
    {
        for (int i = 0; i < 10; i++)
        {
            mutex.WaitOne();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Foo1 writing line number " + i.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            mutex.ReleaseMutex();
        }
    }
    
    public static void foo2()
    {
        for (int i = 0; i < 10; i++)
        {
            mutex.WaitOne();       
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Foo2 writing line number " + i.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            mutex.ReleaseMutex();
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