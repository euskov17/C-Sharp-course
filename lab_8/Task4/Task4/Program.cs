using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

class Program
{
    public static String MergeStrings(String s1, String s2)
    {
        List<String> words1 = s1.Split().ToList();
        List<String> words2 = s2.Split().ToList();
        var result = new StringBuilder();
        for (int i = 0; i < Math.Min(words1.Count, words2.Count); i++)
        {
            if (words1[i] != words2[i])
                result.Append(words1[i] + ' ');
            result.Append(words2[i] + ' ');
        }
        if (words1.Count > words2.Count)
            result.Append(String.Join(' ', words1.Skip(words2.Count)));
        else
            result.Append(String.Join(' ', words2.Skip(words1.Count)));
        return result.ToString();
    }
    public static void Main()
    {
        var s1 = "Шла Маша по шоссе пешком";
        var s2 = "Шла Саша по горе но зачем";
        Console.WriteLine(MergeStrings(s1, s2));
    }
}



