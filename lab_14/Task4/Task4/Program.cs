using System;

class Program
{
    public static double result = 0;
    public static Mutex mutex = new Mutex();
    public static void AggregateFiles(object arg) 
    { 
        String[] fileNames = arg as String[];
        double currentRes = 0;
        foreach (var name in fileNames)
        {
            string[] lines = System.IO.File.ReadAllLines(name);
            int action = Convert.ToInt32(lines[0]);
            var args = lines[1].Split(' ').ToArray();
            var arg1 = Convert.ToDouble(args[0]);
            var arg2 = Convert.ToDouble(args[1]);
            if (action == 1)
                currentRes += arg1 + arg2;
            if (action == 2)
                currentRes += arg1 * arg2;
            if (action == 3)
                currentRes += arg1 * arg1 + arg2 * arg2;
        }
        mutex.WaitOne();
        result += currentRes;
        mutex.ReleaseMutex();
    }

    public static void Main()
    {
        var dataDir = @"C:\\Users\\User\\source\\repos\\C#course\\lab_14\\Task4\\data\";
        string[] files = Directory.GetFiles(dataDir);
        int filesNum = files.Length;

        int numberOfThreads = Convert.ToInt32(Console.ReadLine().ToString());
        List<Thread> threads = new List<Thread>();
        int offset = (int)Math.Floor(filesNum / (double)numberOfThreads);
        var diff = filesNum - offset * numberOfThreads;
        
        if (diff != 0)
            offset += 1;

        var currentPosition = 0;
        for (int i = 0; i < numberOfThreads; i++)
        {
            Thread thread = new Thread(AggregateFiles);
            threads.Add(thread);
            thread.Start(files.Skip(currentPosition).Take(offset).ToArray());
            
            currentPosition += offset;
            
            if (diff == i + 1)
                offset -= 1;
            
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
        
        Console.WriteLine(result);
    }
}