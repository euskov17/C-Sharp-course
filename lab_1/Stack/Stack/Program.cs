using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

class Solution
{
    public class Stack
    {
        List<int> listOfItems;
        int minValue;
        public int length;
        public Stack(List<int> list)
        {
            listOfItems = new List<int>(list);
            minValue = listOfItems.Min();
            length = listOfItems.Count();
        }

        public int MinValue() => minValue;

        public void Push(int x)
        {
            listOfItems.Add(x);
            if (x < minValue) minValue = x;
            length++;
        }
    
        public bool IsEmpty() => listOfItems.Count == 0;
        public int Pop() {
            var lastItem = listOfItems.Last();
            listOfItems.RemoveAt(listOfItems.Count - 1);
            length--;
            if (lastItem == minValue)
                if (IsEmpty()) minValue = -1;
                else  minValue = listOfItems.Min();
            return lastItem;
        }

        public void PrintStack() => Console.WriteLine(String.Join(',', listOfItems.Select(x => x.ToString())));

        public int Length() => listOfItems.Count;
    }
    public static void Main() 
    {
        var lst = new List<int> { 1400,512,53,125,61,43,346,345,635,6345,63,5335,34,1,3,534};
        var stack = new Stack(lst);
        for (int i = 0; i < lst.Count; i++)
        {
            while (stack.length > 1)
            {
                var item1 = stack.Pop();
                var item2 = stack.Pop();
                stack.Push((item1 + item2) / 2);
                stack.PrintStack();
                Console.WriteLine(stack.MinValue());
            }
        }
              
    }
}