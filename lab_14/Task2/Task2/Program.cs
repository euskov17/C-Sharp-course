using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public class Foo
    {
        private static CountdownEvent first_Finished = new CountdownEvent(1);
        private static CountdownEvent second_Finished = new CountdownEvent(1);
        
        public void first()
        {
            try
            {
                Console.WriteLine("first");
            }
            finally
            {
                first_Finished.Signal();
            }
        }
        public void second() {
            first_Finished.Wait();
            try
            {
                Console.WriteLine("second");
            }
            finally
            {
                second_Finished.Signal();
            }
        }
        public void third() { 
            second_Finished.Wait();
            Console.WriteLine("third");
        }
    }


    public static void Main()
    {
        Foo foo = new Foo();
        //foo.first();
        Thread[] threads = new Thread[3] {new Thread(foo.first), new Thread(foo.second), new Thread(foo.third)};
        String[] orderStart = Console.ReadLine().ToString().Split(' ').ToArray();
        for (int i = 0; i < 3; i++)
        {
            var threadIndex = Convert.ToInt64(orderStart[i]);
            threads[i].Start();
        }
    }
}