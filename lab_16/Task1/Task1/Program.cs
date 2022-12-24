using System;

class Program
{
    public class ZeroEvenOdd
    {
        private int n;
        private static CountdownEvent zeroWritten = new CountdownEvent(1);
        private static CountdownEvent oddNow = new CountdownEvent(1);
        private static CountdownEvent evenNow = new CountdownEvent(1);

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        public void Zero(object printNumber)
        {
            Action<int> act = printNumber as Action<int>;
            act(0);
            zeroWritten.Signal();
            oddNow.Signal();
        }

        public void Even(object printNumber)
        {
            zeroWritten.Wait();
            Action<int> act = printNumber as Action<int>;
            
            int num = 1;
            while (num < n)
            {
                evenNow.Wait();
                act(2 * num++);
                evenNow.Reset();
                oddNow.Signal();
            }
        }

        public void Odd(object printNumber)
        {
            zeroWritten.Wait();
            Action<int> act = printNumber as Action<int>;
            
            int num = 0;
            while (num < n)
            {
                oddNow.Wait();
                act(1 + 2 * num++);
                oddNow.Reset();
                //oddNow.Signal();
                evenNow.Signal();
            }
        }
    }


    public static void Main()
    {
        Action<int> printNumber = (x => Console.Write(x.ToString() + " "));
        
        int n = Convert.ToInt32(Console.ReadLine());
        ZeroEvenOdd zeo = new ZeroEvenOdd(n);
        
        Thread a = new Thread(zeo.Zero);
        Thread b = new Thread(zeo.Even);
        Thread c = new Thread(zeo.Odd);
        
        c.Start(printNumber);
        b.Start(printNumber);
        a.Start(printNumber);

        a.Join();
        b.Join();
        c.Join();
    }
}