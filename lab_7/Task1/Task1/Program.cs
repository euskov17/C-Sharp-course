using System;

class Program
{
    public class Element
    {
        public string Name { get; set; } 
    }
    
    public static void Main()
    {
        var elems = new List<Element>() { new Element { Name = "Bob" }, 
                                          new Element { Name = "Tom" }, 
                                          new Element { Name = "Vasya" }, 
                                          new Element { Name = "Artem" },
                                          new Element { Name = "Kristina" } };
        string delimetr = ", ";
        Console.WriteLine(String.Join(delimetr, elems.Skip(3).Select(n => n.Name)));
    }
}