using System;

class Solution
{
    public static int diceRoll(int numberOfRolls, int summary)
    {
        var table = new int[numberOfRolls, summary + 1];
        
        for (int i = 0; i <= summary; i++)
            if (i >= 1 && i <= 6) table[0, i] = 1;
            else table[0, i] = 0;
        
        for (int i = 1; i < numberOfRolls; i++)
            for (int j = 0; j <= summary; j++) 
                for (int k = 1; k <= 6; k++)
                    if (j - k > 0) table[i, j] += table[i - 1, j - k];
        
        return table[numberOfRolls - 1, summary];
    }

    public static void Main()
    {
        Console.WriteLine(diceRoll(2, 6)); 
        Console.WriteLine(diceRoll(2, 2)); 
        Console.WriteLine(diceRoll(1, 3)); 
        Console.WriteLine(diceRoll(2, 5)); 
        Console.WriteLine(diceRoll(3, 4)); 
        Console.WriteLine(diceRoll(4, 18)); 
        Console.WriteLine(diceRoll(6, 20)); 
    }
}