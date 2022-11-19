using System;
using System.Runtime.CompilerServices;

class Program
{
    public static String Permutations(String s) {
        var items = s.ToCharArray();
        List<String> resultStrings = new List<String>();

        int itemsNumber = items.Length;

        var indexes = new int[itemsNumber];
        for (int i = 0; i < itemsNumber; i++)
            indexes[i] = 0;

        resultStrings.Add(String.Join("", items));
        
        for (int i = 1; i < itemsNumber;)
        {
            if (indexes[i] < i)
            {
                if ((i & 1) == 1){
                    var tmp = items[indexes[i]];
                    items[indexes[i]] = items[i];
                    items[i] = tmp;
                }
                else
                {
                    var tmp = items[i];
                    items[i] = items[0];
                    items[0] = tmp;
                }

                resultStrings.Add(String.Join("", items));
                indexes[i]++;
                i = 1;
            }
            else
            {
                indexes[i++] = 0;
            }
        }
        var result = String.Join(" ", resultStrings.Distinct().ToList().OrderBy(x => x).ToList());
        return result;
    }

	public static void Main()
	{
        Console.WriteLine(Permutations("AB"));
        Console.WriteLine(Permutations("CD"));
        Console.WriteLine(Permutations("EF"));
        Console.WriteLine(Permutations("NOT"));
        Console.WriteLine(Permutations("RAM"));
        Console.WriteLine(Permutations("YAW"));
    }
}