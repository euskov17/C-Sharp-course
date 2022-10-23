using System;
 
class Program
{
    public static void Main()
    {
        string s = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
        IEnumerable<IGrouping<int, String>> modifyString = s.Replace("-", "")
                            .Replace(",", "")
                            .Replace(".", "")
                            .Replace(":", "")
                            .Split(" ")
                            .Where(n => n.Length > 0)
                            .GroupBy((n => n.Length))
                            .OrderBy(n => n.ToList().Count())
                            .Reverse();
        foreach (var l in modifyString) {
            int key  = l.Key;
            List<String> strs = l.ToList();
            Console.WriteLine("Группа: " + key.ToString() + ". Длина: " + strs[0].Length + ". Количество: " + strs.Count);
            foreach (string str in strs)
                Console.WriteLine(str);
         }
    }
}