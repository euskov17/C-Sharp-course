using System;

class Solution{

    public static void Main()
    {
        var x = new
        {
            Items = new List<int> { 1, 2, 3 }.GetEnumerator()
        };
        while (x.Items.MoveNext())
            Console.WriteLine(x.Items.Current);
    }
}