using System;

class Solution
{
    public static int WaterAccumulation(List<int> columnsHeights)
    {
        int n = columnsHeights.Count;
        var leftBounds = new int[n];
        var rightBounds = new int[n];
        
        int leftMax = 0;
        int rightMax = 0;
        for (int i = 0; i < n; i++)
        {
            leftBounds[i] = leftMax;
            rightBounds[n - i - 1] = rightMax;
            if (columnsHeights[i] > leftMax) leftMax = columnsHeights[i];
            if (columnsHeights[n - i - 1] > rightMax) rightMax = columnsHeights[n - i - 1];
        }
        
        int result = 0;
        for (int i = 0; i < n; i++)
            result += Math.Max(0, Math.Min(leftBounds[i], rightBounds[i]) - columnsHeights[i]);
        return result;
    }


    public static void Main()
    {
        var lst1 = new List<int>{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
        var lst2 = new List<int> { 4, 2, 0, 3, 2, 5 };
        Console.WriteLine(WaterAccumulation(lst1));
        Console.WriteLine(WaterAccumulation(lst2));
    }
}