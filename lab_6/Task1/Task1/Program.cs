using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

class Program
{
    class Lake: IEnumerable<int>
    {
        private int[] data;

        public Lake(int[] data)
        {
            this.data = data;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] dataSortedCopy = data;
            Array.Sort(dataSortedCopy);
            int i = 0;
            for (i = 0; i < dataSortedCopy.Length; i++)
                if (dataSortedCopy[i] % 2 ==  1)
                    yield return dataSortedCopy[i];
            for (i = dataSortedCopy.Length - 1; i >= 0; i--)
                if (dataSortedCopy[i] % 2 == 0)
                    yield return dataSortedCopy[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static void Main()
    {
        int[] data1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] data2 = { 13, 23, 1, -8, 4, 9 };
        var lake = new Lake(data1);
        var lake2 = new Lake(data2);
        Console.WriteLine("Lake 1");
        foreach (int i in lake)
            Console.Write(i.ToString() + ' ');
        Console.WriteLine("\nLake 2");
        foreach (int i in lake2)
            Console.Write(i.ToString() + ' ');
    }
}