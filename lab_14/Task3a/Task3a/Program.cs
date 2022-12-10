using System;

class Program
{
    public static void SleepSort(object arg)
    {
        string s = arg.ToString();
        Thread.Sleep(100 * s.Length);
        Console.WriteLine(s);
    }

    public static void Main() 
    { 
        int n = Convert.ToInt32(Console.ReadLine().ToString());
        List<String> strs = new List<string>();
        for (int i = 0; i < n; i++)
            strs.Add(Console.ReadLine().ToString());
  
        List<Thread> threads = new List<Thread>();

        foreach (string str in strs)
        {
            Thread thread = new Thread(SleepSort);
            threads.Add(thread);
            thread.Start(str);
        }

        foreach (var thread in threads)
            thread.Join();
    }
}