using System;
using System.Runtime.InteropServices;

class Program
{
    public class MyCash<T> where T : IDisposable
    {
        int capacity;        
        int count;
        int currentPriority;
        Dictionary<T, int> data;

        public MyCash(int capacity){
            this.capacity = capacity;   
            this.count = 0;
            this.currentPriority = 0;
            this.data = new Dictionary<T, int> ();
        }
        public void CallElement(T elem)
        {
            if (data.ContainsKey(elem))
            {
                data[elem] = currentPriority++;
                return;
            }
            if (count == capacity)
            {
                var key = data.MinBy(x => x.Value).Key;
                data.Remove(key);
                key.Dispose();
                GC.Collect();
            }
            else
                count++;
            data.Add(elem, currentPriority++);
        }

        public void Dispose()
        {
            Console.WriteLine("Call Dispose");
            var keys = data.Keys.ToList();
            data.Clear();
            foreach (var key in keys)
                key.Dispose();
            count = 0;
            GC.Collect();
        }
        
        public List<T> getData()
        {
            return data.Keys.ToList();
        }
    }

    public static void Main()
    {
        var cash = new MyCash<FileStream>(4);
        var random = new Random();
        var cur_indexes = new List<int>();
        
        // check that disposing elements is working
        for (int i = 0; i < 20; i++)
        {
            int index = random.Next(10);
            while (cur_indexes.Contains(index))
                index = random.Next(10);
            if (cur_indexes.Contains(index))
                Console.WriteLine("We have an error");
            cash.CallElement(File.Create(index.ToString() + ".txt", 1024));
            Console.Write("index is " + index.ToString() + ":   ");
            cur_indexes.Clear();
            foreach (var d in cash.getData())
            {
                var s = d.Name.ToString();
                var name = s.Substring(s.Length - 5, 1);
                cur_indexes.Add(int.Parse(name));
                Console.Write(name + ' ');
            }
            Console.WriteLine();
        }

        FileStream[] files = new FileStream[10];
        cash.Dispose();
        
        for (int i = 0; i < 10; i++)
        {
            files[i] = File.Create(i.ToString() + ".txt", 1024);
        }

        // check that recalling is correct
        for (int i = 0; i < 20; i++)
        {
            int index = random.Next(10);
            Console.Write("index = " + index.ToString() + ":  ");
            cash.CallElement(files[index]);
            foreach (var d in cash.getData())
            {
                var s = d.Name.ToString();
                var name = s.Substring(s.Length - 5, 1);
                cur_indexes.Add(int.Parse(name));
                Console.Write(name + ' ');
            }
            Console.WriteLine();
        }
    }
}