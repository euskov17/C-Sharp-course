using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

class Program
{

    public static int m = 5;
    public static int n = 3;
    public static int k = 7;
    public static int p = 3;
    public static int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 }, { 13, 14, 15 } };
    public static int[,] B = { { 1, 2, 3, 4, 5,6,7 }, { 8,9,10,11,12,13,14 }, { 15,16,17,18,19,20,21 }};
    public static int[,] C = new int[m, k]; 
    public static Mutex mutex = new Mutex();
    public static int currentRow = 0, currentColumn = 0;
    
    public static void Multiply()
    {
        while (true)
        {
            Thread.Sleep(100);
            mutex.WaitOne();
            if (currentRow == m - 1 & currentColumn == k)
            {
                mutex.ReleaseMutex();
                break;
            }
            int i = currentRow, j = currentColumn;
            if (currentColumn == k - 1 & currentRow != m-1)
            {
                currentColumn = 0;
                currentRow++;
            }
            else
                currentColumn++;
            mutex.ReleaseMutex();
            for (int l = 0; l < n; l++)
            {
                C[i, j] += A[i, l] * B[l, j];
            }
        }
    }

    public static void Main()
    {
        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < p; i++)
        {
            Thread thr = new Thread(Multiply);
            threads.Add(thr);
            thr.Start();
        }
        foreach (Thread t in threads)
            t.Join();

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < k; j++)
                Console.Write(C[i,j].ToString() + " ");
            Console.WriteLine();
        }
    }
}