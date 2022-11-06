using System;

class Program
{

    public static String SearchFileInDirectory(String fName, String root)
    {
        //Console.WriteLine(root, fName);
        try
        {
            var files = Directory.GetFiles(root);
            foreach (var file in files)
                if (file.Contains(fName))
                    return file;
            var dirs = Directory.GetDirectories(root);
            foreach (var dir in dirs) {
                var result = SearchFileInDirectory(fName, dir);
                if (result != "Not Found")
                    return result;
            }
        }
        catch
        {
            return "Not Found";
        }
        return "Not Found";
    }

    public static String SearchFile(String fName)
    {
        return SearchFileInDirectory(fName, Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));
    }


    public static void Main()
    {
        Console.WriteLine(SearchFile("Task4.exe"));
    }
}