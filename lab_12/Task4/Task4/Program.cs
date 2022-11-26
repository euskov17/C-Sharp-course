using System;
using System.Net.Mime;

class Program
{
    public static int MinDist(List<int> houses, int leftIdx, int rightIdx, int k)
    {
        int ans = 0;
        bool firstResult = true;
        if (k == 1)
        {
            var div = houses[(leftIdx + rightIdx) / 2];
            for (int i = leftIdx; i <= rightIdx; i++)
                ans += Math.Abs(houses[i] - (int)div);
            return ans;
        }   
        for (int i = leftIdx; i < rightIdx; i++)
        {
            if (rightIdx - i < k - 1)
                break;
            if (firstResult) {
                ans = MinDist(houses, leftIdx, i, 1) + MinDist(houses, i + 1, rightIdx, k - 1);
                firstResult = false;
            }
            else
                ans = Math.Min(ans, MinDist(houses, leftIdx, i, 1) + MinDist(houses, i + 1, rightIdx, k - 1));
        }
        return ans;
    }

    public static void Main()
    {
        List<int> houses = new List<int> { 1, 4, 8, 10, 20};
        List<int> houses2 = new List<int> { 2, 3, 5, 12, 18};
        List<int> houses3 = new List<int> { 7, 4, 6, 1};
        List<int> houses4 = new List<int> { 3, 6, 14, 10};
        Console.WriteLine(MinDist(houses, 0, houses.Count - 1, 3));
        Console.WriteLine(MinDist(houses2, 0, houses2.Count - 1, 2));
        Console.WriteLine(MinDist(houses3, 0 , houses3.Count - 1, 1));
        Console.WriteLine(MinDist(houses4, 0 , houses4.Count - 1, 4));
    }
}