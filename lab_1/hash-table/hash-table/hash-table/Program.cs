using System;
using System.Security.Cryptography.X509Certificates;

class Solution
{   
    public class HashTable
    {
        Dictionary<int, List<(int, string)>> table = new Dictionary<int, List<(int, string)>>();
        Func<int, int> func;
        public HashTable(Func<int, int> hash_function, Dictionary<int, string> dict)
        {
            func = hash_function;
            foreach (var (key, value) in dict)
            {
                var hash_value = func(key);
                if (table.ContainsKey(hash_value)) table[hash_value].Add((key,value));
                else table[hash_value] = new List<(int, string)> { (key, value) };
            }
        }

        public string FindValue(int key)
        {
            return table[func(key)].Find(x => x.Item1 == key).Item2;
        }

    }

    public static int ExampleHashFunction(int key) => (15 * key + 17) % 23;
    public static void Main()
    {
        var MyTable = new Dictionary<int, string>();
        string a = new string("ab");
        string b = new string("");
        var numberOfStrings = 20;
        for (int i = 0; i < numberOfStrings; i++)
        {
            MyTable[i] = b;
            b += a;
        }
        var MyHashTable = new HashTable(ExampleHashFunction, MyTable);
        for (int i = 0; i < numberOfStrings; i++)
            Console.WriteLine(MyHashTable.FindValue(i));
    }
}