using System;

class Program
{
    static int N = 10;
    static int X = 10;
    static int steps = 10;
    static int[] buffer = new int[X];
    static Random random = new Random();
    static int currentIter = 0;
    static Mutex mutex = new Mutex();

    static void bee_task()
    {
        while (steps > 0)
        {
            var time = random.Next(2000);
            Thread.Sleep(time);
            mutex.WaitOne();
            if (currentIter < X)
            {
                buffer[currentIter++] = 1;
            }
            else
            {
                steps--;
                currentIter = 0;
                for (int i = 0; i < X; ++i) {
                    buffer[i] = 0;
                }
            }
            mutex.ReleaseMutex();
        }
    }

    public static void Main()
    {
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < N; i++)
        {
            Task newTask = new Task(bee_task);
            tasks.Add(newTask);
            newTask.Start();
        }
        foreach (var task in tasks)
            task.Wait();
    }
}