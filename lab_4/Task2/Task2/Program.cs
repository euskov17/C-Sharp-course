using System;

class Program
{
    interface PrintA
    {
        void Print();
    }

    interface PrintB
    {
        void Print();
    }

    public abstract class Printer
    {
        public abstract void Print();
    }

    public sealed class StrongPrinter: Printer, PrintA, PrintB
    {

        public override void Print()
        {
            Console.WriteLine("call Base print");
        }

        void PrintA.Print()
        {
            Console.WriteLine("call A print");
        }
        void PrintB.Print()
        {
            Console.WriteLine("call B print");
        }
    }

    public static void Main()
    {
        var sp = new StrongPrinter();
        sp.Print();
        PrintA printA = sp;
        PrintB printB = sp;
        printA.Print();
        printB.Print();
    }
}